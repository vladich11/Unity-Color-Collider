using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int level;
    public int coins;
    public int isExplosionPowerSold;
    public int isTeleportPowerSold;

    //Receive data from levelmanager to save it.
    public PlayerData(LevelManager levelManager)
    {
        level = LevelManager.saveCurrentLevel;
        coins = LevelManager.coinsAmount;
        isExplosionPowerSold = ShopController.isExplosionPowerSold;
        isTeleportPowerSold = ShopController.isTeleportPowerSold;
    }
}
