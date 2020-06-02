using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float SphereSize = 0.2f;
    public int SphereInRow = 3;
    [SerializeField]float explosionForce;
    [SerializeField] float explosionRadius;
    [SerializeField]
    float explosionUpwards;

 
    [SerializeField]
    public Color newColor;

    float spheresPivotDistance;
    Vector3 spheresPivot;
    // Start is called before the first frame update
    void Start()
    {
        //calculate pivot distance
        spheresPivotDistance = SphereSize * SphereInRow / 2;
        //use this value to create pivot vector
        spheresPivot = new Vector3(spheresPivotDistance, spheresPivotDistance, spheresPivotDistance);

    }

 
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"&& ShieldPower.isShielded==0)
        {
            Explode();
         
        }
    }
    public void Explode() {
        Destroy(this.gameObject);
        //loop 3 times to create 5x5x5 Piece in x,y,z coordinations
        for (int x = 0; x < SphereInRow; x++)
            for (int y = 0; y < SphereInRow; y++)
                for (int z = 0; z < SphereInRow; z++)
                {
                    {
                        {
                            CreatePiece(x, y, z);
                        }
                    }
                }
        //get explosion position
        Vector3 explosionPos=transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach(Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpwards);
            }
        }

    }
    void CreatePiece(int x,int y ,int z)
    {
        //create piece
        GameObject piece;

        
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //set piece poition and scale
        piece.transform.position = transform.position+new Vector3(SphereSize*x, SphereSize*y, SphereSize*z)- spheresPivot;
        piece.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);

        var cubeRenderer = piece.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", newColor);

        //add rigidbody and set mass 
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = SphereSize;

    }
}
