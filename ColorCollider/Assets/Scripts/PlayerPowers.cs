using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    //Explosion power
    public GameObject Player;
    public ParticleSystem Boom;
    public float explosionPower = 10f;
    public float explosionRadius = 5f;
    public float upForce=1f;

    //Teleport Power
    public float TpMeterTransform=5f;

    //Explosion power
    public void explosion()
    {
        Boom.Play();
        
        Vector3 explosionPosition = Player.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb!=null)
            rb.AddExplosionForce(explosionPower,explosionPosition, explosionRadius,upForce, ForceMode.Impulse);
        }
        
    }

    //Teleport Power
    public void TeleportPlayer()
    {
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + TpMeterTransform);
    }
}
