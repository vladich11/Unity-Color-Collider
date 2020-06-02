using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
public class AdManager : MonoBehaviour
{
    private string adid = "3299084";
    private string videoad = "video";
    private string rewarded_videoad = "rewardedVideo";
   
    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(adid, true);
    }

    public void Adshower()
    {
        if (Monetization.IsReady(videoad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }
    }
    public void AdRewardedshower()
    {
        if (Monetization.IsReady(rewarded_videoad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewarded_videoad) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
                LevelManager.coinsAmount += 5;
            }
        }
    }
    
}
