using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMainScript : MonoBehaviour
{
    public void OnClickUpgradeMar()
    {
        if (MarScript.Instance.playerInfo.gems>=5)
        {
            Yandex.Instance.ShowFullScreenAdvertisment();
            MarScript.Instance.playerInfo.gems -= 5;
            MarScript.Instance.playerInfo.promoutionPerClick++;
        }
    }
    public void PlusGems()
    {
        Yandex.Instance.ShowRewardedVideo();
        MarScript.Instance.playerInfo.gems += 10;

    }

    public void OnClickClose()
    {
        ShopOpenScript.isOpened = false;
    }
}
