using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildScript : MonoBehaviour
{
    public int index, promotion;
    public GameObject obj, info, parent;
    public void OnClick()
    {
        InfoPrefabScript.currentIndex = index;
        InfoPrefabScript.isOpened = true;
        info = Instantiate(obj, parent.transform);
    }
    private void Update()
    {
        if (!InfoPrefabScript.isOpened | TutorScript.isOpened) {
            Destroy(info);
        }
        this.GetComponent<Button>().interactable = !(InfoPrefabScript.isOpened | TutorScript.isOpened);
        this.GetComponent<Image>().sprite = MarScript.Instance.masOfSprites[MarScript.Instance.playerInfo.masOfNumbers[index]];
    }
}
