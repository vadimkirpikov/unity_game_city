using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpenScript : MonoBehaviour
{
    public static bool isOpened, isInteractable = true;
    public GameObject shopMain, obj, parent;

    public void OnClick()
    {
        isInteractable = false;
        isOpened = true;
        shopMain = Instantiate(obj, parent.transform);
    }

    private void Update()
    {
        this.GetComponent<Button>().interactable = isInteractable & !(InfoPrefabScript.isOpened | TutorScript.isOpened | !MarScript.Instance.playerInfo.tutorialIsComleted);
        if (!isOpened)
        {
            Destroy(shopMain);
            isInteractable = true;
        }
    }
}
