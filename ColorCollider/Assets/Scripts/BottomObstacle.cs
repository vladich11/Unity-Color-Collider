using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomObstacle : MonoBehaviour
{
    //check for enemy too
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" || other.tag == "Enemy")
        {

            Destroy(other.gameObject);
        }
    }
}
