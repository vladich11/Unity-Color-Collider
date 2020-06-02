using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotator : MonoBehaviour
{
   
    [SerializeField] float speed = 3f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed, 0, 0, Space.World);

    }
  
}
