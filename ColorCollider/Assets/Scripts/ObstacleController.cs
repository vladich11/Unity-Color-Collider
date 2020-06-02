using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    
    [SerializeField]Rigidbody myRB;

    private void FixedUpdate()
    {
        //move CameraObstacle trigger when game is started 
        if (!LevelManager.LM.isStarted)
            myRB.velocity = Vector3.zero; 
        else if (LevelManager.LM.isStarted)
        {
            myRB.velocity = Vector3.forward * 4f;
        }
        
    }
    //check for enemy too
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" || other.tag == "Enemy")
        {
        
            Destroy(other.gameObject);
        }
    }
}

