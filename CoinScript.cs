using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public Sprite coin, gem;

    private void Start()
    {
        GetComponent<Image>().sprite = MarScript.random == 49 ? gem : coin;
    }
    void Update()
    {
        this.transform.localPosition += new Vector3(0f, 100f*Time.deltaTime, 0f);
    }
}
