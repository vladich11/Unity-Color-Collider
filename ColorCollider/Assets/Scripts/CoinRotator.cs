using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [SerializeField]float speed = 3f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed,0,Space.World);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            LevelManager.coinsCollectedCurrentLevel++;
            LevelManager.coinsAmount += 1;
            Destroy(gameObject);
        }
    }
    

}
