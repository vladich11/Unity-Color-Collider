using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopController : MonoBehaviour
{

    //Explosion Power
    public static int isExplosionPowerSold = 0;
    public Button buyExplosionButton;
    public Button powerExplosionButton;

    //Teleport Power
    public static int isTeleportPowerSold = 0;
    public Button buyTeleportButton;
    public Button powerTeleportButton;
  
    // Update is called once per frame
    void Update()
    {
        //check is Explosion power is sold.
        if (isExplosionPowerSold == 0)
            powerExplosionButton.gameObject.SetActive(false);
        else if (isExplosionPowerSold == 1)
            powerExplosionButton.gameObject.SetActive(true);

        //check if amount of count is efficient for Explosion power.
        if (LevelManager.coinsAmount >= 10 && isExplosionPowerSold == 0)
            buyExplosionButton.interactable = true;
        else
            buyExplosionButton.interactable = false;

        //check is Teleport power is sold.
        if (isTeleportPowerSold == 0)
            powerTeleportButton.gameObject.SetActive(false);
        else if (isTeleportPowerSold == 1)
            powerTeleportButton.gameObject.SetActive(true);


        //check if amount of count is efficient for Teleport power.
        if (LevelManager.coinsAmount >= 15 && isTeleportPowerSold == 0)
            buyTeleportButton.interactable = true;
        else
            buyTeleportButton.interactable = false;

    }

    //Explosion Buy Button (main panel)
    public void buyExplosionPower()
    {
        LevelManager.coinsAmount -= 1;
        isExplosionPowerSold = 1;
        buyExplosionButton.gameObject.SetActive(false);
    }

    //Explosion Buy Button (main panel)
    public void buyTeleportPower()
    {
        LevelManager.coinsAmount -= 1;
        isTeleportPowerSold = 1;
        buyTeleportButton.gameObject.SetActive(false);
    }
}
