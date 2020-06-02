using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public static int isShielded = 0;
    public GameObject Shield;

    //Shield trigger when picked by player,toggle shield on.
    private void OnTriggerEnter(Collider other) { 
        if (other.tag == "Player") {
            ToggleVisibilityActive(Shield);
             isShielded = 1;
             Destroy(gameObject);
        }
    }

    //Method to toggle shield on
    public void ToggleVisibilityActive(GameObject Shield)
    {
            Shield.active=true;        
    }

    //Method to toggle shield off
    public void ToggleVisibilityOff(GameObject Shield)
    {
        Shield.active = false;
    }
}

