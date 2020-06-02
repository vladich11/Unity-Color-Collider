using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : AdManager
{
    //Coins control
    public static int coinsAmount;
    public static int coinsCollectedCurrentLevel;
    //playerData save 
    public static int levelNumber = 0;
    public static int saveCurrentLevel = 0;

    public bool TryAgain;
    public bool isStarted;

    //level manager panels
    public static LevelManager LM;
    public GameObject winPanel;
    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject shopPanel;

    public Text coinsText;

    [SerializeField] Transform Player;
    [SerializeField] Transform EndLine;
    [SerializeField] Slider slider;
    

    float maxDistance;

    private void Update()
    {
        //If game started show coin text
        if (isStarted == true)
        {
            string Scene = SceneManager.GetActiveScene().name;
            coinsText.text =  coinsAmount.ToString();
        }
        //slider controls
        if (Player != null)//check if player exist 
        {
            if (Player.position.z <= maxDistance && Player.position.z <= EndLine.position.z)//if player is between start and end note : start pos is player
            {
                float distance = 1 - (getDistance() / maxDistance);
                setProgress(distance);
                
            }
        }
    }

    void Start()
    {
        maxDistance = getDistance();
        LevelManager.LM = this;
    }

    //Open mainPanel startPanel method
    public void StartGame()
    {
        isStarted = true;
        startPanel.SetActive(false);
    }

    //Close shop method
    public void backShop()
    {
        shopPanel.SetActive(false);
    }

    //Open Shop method
    public void startShop()
    {
        shopPanel.SetActive(true);
    }

    //Open same scene again
    public void tryAgain()
    {
        //coins control
        coinsAmount -= coinsCollectedCurrentLevel;
        coinsCollectedCurrentLevel = 0;

        //load currct scene
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    //Open next scene(+1)
    public void nextLevel()
    {
        //restart count of currect level coins
        coinsCollectedCurrentLevel = 0;
        levelNumber += 1;
        saveCurrentLevel = levelNumber;
        SceneManager.LoadScene(levelNumber);
        //Adshower();
    }

    //Save player data method
    public void SavePlayer()
    {
        saveSystem.savePlayer(this);
    }

    //Load player data metod
    public void LoadPlayer()
    {
        PlayerData data = saveSystem.loadPlayer();
        //level number and coins reload
        coinsAmount = data.coins;
        levelNumber = data.level;
        //powers load
        ShopController.isExplosionPowerSold = data.isExplosionPowerSold;
        ShopController.isTeleportPowerSold = data.isTeleportPowerSold;
        SceneManager.LoadScene(levelNumber, LoadSceneMode.Single);
    }

    //Check Player distance from finish line
    float getDistance()
    {
        if (Player != null)
            return Vector3.Distance(Player.position, EndLine.position);
        else return 0;
    }

    //Set the progress the player made on the slider UI.
    void setProgress(float p)
    {
        slider.value = p;
    }
}
