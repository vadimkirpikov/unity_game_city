using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankScript : MonoBehaviour
{
    public static float time;
    public static bool moneyIsHere;
    public int index;
    public string timer;
    private void Start()
    {
    }

    public int SearchPoint(string timer)
    {
        for (int i = 0; i < timer.Length; i++)
        {
            if (timer[i] == '.')
            {
                return i;
            }

        }
        return 0;
    }

    public float SubString(string st, int pos1, int pos2)
    {
        string res = "";
        float result = 0;
        float step = 0;
        for(int i = pos1; i < pos2; i++)
        {
            res += st[i];
        }
        for (int i=res.Length-1; i>=0; i--)
        {
            result += ((int)(res[i]) - 48) * MathF.Pow(10, step++);
        }
        return result;
    }

    public float SumTime(string str)
    {
        return SubString(str, 0, 2) * 24 * 60 + SubString(str, 3, 5) *720*60 + SubString(str, 11, 13)*60+SubString(str, 14, 16);
       
    }
    public void OnClick()
    {

        MarScript.Instance.playerInfo.coins +=(int)time * MarScript.Instance.playerInfo.promotionPerMinute;
        MarScript.Instance.playerInfo.time = DateTime.Now.ToString();
    }

    private void Update()
    {
        if (MarScript.Instance.playerInfo.promotionPerMinute > 0)
        {
            timer = DateTime.Now.ToString();
            time = SumTime(timer) - SumTime(MarScript.Instance.playerInfo.time);
            this.GetComponent<Button>().interactable = (int)time >= 1;

        }
        else
        {
            this.GetComponent<Button>().interactable = false;
        }


    }
}
