using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    float speed=5f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);
    }
}
