using UnityEngine;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowFullScreenAd();

    [DllImport("__Internal")]
    private static extern void ShowVideo();

    [DllImport("__Internal")]
    private static extern void SaveExtern(string value);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [DllImport("__Internal")]
    private static extern string GetLang();


    public static Yandex Instance;
    public float timer;
    public bool canBeCalled;
    public string lang, totalData, jsonString = "A", loadData;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        LoadExtern();
        ShowFullScreenAdvertisment();
        lang = GetLang();
    }
    public void Save()
    {
        jsonString = JsonUtility.ToJson(MarScript.Instance.playerInfo);
        SaveExtern(jsonString);
        SetToLeaderboard(MarScript.Instance.playerInfo.people);
    }

    public void ShowFullScreenAdvertisment()
    {
        ShowFullScreenAd();
    }
    public void SetPlayerInfo(string value)
    {
        loadData = value;
    }

    public void ShowRewardedVideo()
    {
        ShowVideo();
    }


}
