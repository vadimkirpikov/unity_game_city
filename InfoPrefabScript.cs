using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPrefabScript : MonoBehaviour
{
    public static int currentIndex, currentPromoution;
    public int[] mas = { 0, 1, 3, 5, 10, 30, 50 };
    public static bool isOpened;
    public Image mainImage;
    public Text txt, textOfBuild;
    private void Start()
    {
        
    }

    public void OnClickClose()
    {
        isOpened = false;
    }
    private void Update()
    {
        mainImage.sprite = MarScript.Instance.masOfSprites[MarScript.Instance.playerInfo.masOfNumbers[currentIndex]];
        if (Yandex.Instance.lang=="ru")
        {
            txt.text = "+ " + mas[MarScript.Instance.playerInfo.masOfNumbers[currentIndex]].ToString() + " в минуту";
            textOfBuild.text = "Построить";
        }
        else
        {
            txt.text = "+ " + mas[MarScript.Instance.playerInfo.masOfNumbers[currentIndex]].ToString() + " per minute";
            textOfBuild.text = "Build";
        }
    }
}
