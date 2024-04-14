using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBuildScript : MonoBehaviour
{
    public int number, cost, promotion, people;

    public void OnClick()
    {
        if (MarScript.Instance.playerInfo.coins>=cost)
        {
            MarScript.Instance.playerInfo.masOfNumbers[InfoPrefabScript.currentIndex] = number;
            MarScript.Instance.playerInfo.coins -= cost;
            MarScript.Instance.playerInfo.promotionPerMinute += promotion;
            MarScript.Instance.playerInfo.people += people;
            if (MarScript.Instance.playerInfo.tutoriaPlace==2)
            {
                MarScript.Instance.InstantiatingThirdPart();
            }
        }
    }
    private void Update()
    {
        if (number <= MarScript.Instance.playerInfo.masOfNumbers[InfoPrefabScript.currentIndex])
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
}
