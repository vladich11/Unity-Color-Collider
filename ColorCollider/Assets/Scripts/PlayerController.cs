using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//was levelmnaher
public class PlayerController : ShieldPower
{
    Rigidbody myRB;
    public Rigidbody cameraRB;
    public Camera myCamera;
    public float lerpSpeed;
    private bool _dragging;
    private Vector3 _mouseStartPos, _PlayerStartPos;

    public float ballSpeed;
    public float cameraSpeed;
    public GameObject Coin;
    public float minBallDistance;
    public float maxBallDistance;
    public float currentBallDistance;
   
    [SerializeField]
    private float Timer = 5f;
   
    //Conffeti Control
    public Transform confetti;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        //Conffeti Control
        confetti.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.LM.isStarted)
            return;
        BallCameraDistance();
        ForwardMovement();

        if (Input.GetMouseButtonDown(0))
        {
            _dragging = true;
            Plane plane = new Plane(Vector3.up, 0);
            float dist;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out dist))
            {
                _mouseStartPos = ray.GetPoint(dist);
                _PlayerStartPos = gameObject.transform.position;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _dragging = false;
        }
        if (_dragging)
            if (currentBallDistance > minBallDistance)//Dont allow go lower than cam
            {
                {
                    Plane plane = new Plane(Vector3.up, 0);
                    Vector3 move = new Vector3();
                    float dist;

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (plane.Raycast(ray, out dist))
                    {
                        Vector3 mousePos = ray.GetPoint(dist);
                        move = mousePos - _mouseStartPos;
                        transform.position = Vector3.MoveTowards(transform.position, _PlayerStartPos + move, 17 * Time.deltaTime);
                    }
                    //Dont allow to move beyond platform(-9<x<9)
                    if (gameObject.transform.position.x < 9.5f)
                    {
                        move.x = 9.5f;
                        transform.position = Vector3.MoveTowards(transform.position, _PlayerStartPos + move, 20 * Time.deltaTime);
                    }
                    if (gameObject.transform.position.x > -9.5f)
                    {
                        move.x = -9.5f;
                        transform.position = Vector3.MoveTowards(transform.position, _PlayerStartPos + move, 20 * Time.deltaTime);
                    }
                }
            }

    }

    private void FixedUpdate()
    {
        if (!LevelManager.LM.isStarted)
            return;
        CameraMovement();
        TimerCountDown();


    }

    //Timer count down when shield is picked up by player.
    void TimerCountDown()
    {
        if (Timer >= 0.0f && isShielded == 1)
        {
            Timer -= Time.deltaTime;
        }
        if (0.5f<Timer&& Timer < 1.5f){
            //Get the Renderer component from the new cube
            var cubeRenderer = Shield.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
        else if (Timer <= 0.0f)
        {
            isShielded = 0;
            ToggleVisibilityOff(Shield);
        }
    }

    //Move ball forward(Z axis)
    void ForwardMovement()
    {
        myRB.velocity = Vector3.forward * ballSpeed;//moving the ball f   
    }

    //Move camera forward(Z axis)
    void CameraMovement()
    {
        
        if (currentBallDistance < maxBallDistance)
        {
            cameraRB.velocity = Vector3.forward * cameraSpeed;
        }
        else
        {
            cameraRB.velocity = Vector3.forward * cameraSpeed*2f;
        }
    }

    //which distance the ball allowed to move
    void BallCameraDistance()
    {
        currentBallDistance = Vector3.Distance(new Vector3(0, 0, myCamera.transform.position.z), new Vector3(0, 0, transform.position.z));
    }

    //Finish game trigger when hit obstacle.
    private void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.tag == "Enemy" && ShieldPower.isShielded == 0)
        {
            Destroy(this.gameObject);
            LevelManager.LM.gameOverPanel.SetActive(true);

            cameraRB.velocity = Vector3.zero;
            LevelManager.LM.isStarted = false;
        }
        
    }  

    //Finish line trigger for end game.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            //Confetti Control
            confetti.GetComponent<ParticleSystem>().enableEmission = true;

            //was without LevelManager.
            LevelManager.saveCurrentLevel = LevelManager.levelNumber;
            LevelManager.LM.winPanel.SetActive(true);
            cameraRB.velocity = Vector3.zero;
            LevelManager.LM.isStarted = false;
            Destroy(this.gameObject);
        }
       
    }
   
}
