using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerInfo
{
    public int[] masOfNumbers;
    public int coins;
    public int gems;
    public string time;
    public int people;
    public int promotionPerMinute;
    public int promoutionPerClick = 1;
    public int tutoriaPlace = 0;
    public bool tutorialIsComleted;
}

public class MarScript : MonoBehaviour
{
    public GameObject coin, obj, obj2, tutorPrefab;
    public Transform parent;
    public string totalData;

    public static MarScript Instance;
    public PlayerInfo playerInfo;
    public Sprite[] masOfSprites;
    public static int random;
    public float timer;
    private int timeBeforeSave;

    public Text textCoins, textPeople, textGems;

    public void clearPlayerInfo()
    {
        playerInfo.promotionPerMinute = 0;
        playerInfo.promoutionPerClick = 1;
        playerInfo.coins = 0;
        playerInfo.gems = 0;
        playerInfo.tutoriaPlace = 0;
        playerInfo.tutorialIsComleted = false;
        playerInfo.people = 0;
        playerInfo.time = "";
        for (int i=0; i < playerInfo.masOfNumbers.Length; i++)
        {
            playerInfo.masOfNumbers[i] = 0;
        }
    }
    public void InstantiatingFirstPart()
    {
        TutorScript.isOpened = true;
        
        if (Yandex.Instance.lang == "ru")
        {
            TutorScript.txt = "Привет, мэр моего города! Меня зовут Боб, я буду твоим помошником в начале игры. Для начала давай заработаем 100 монет для строительства первого домика. Нажимай на мэрию";
        }
        else
        {
            TutorScript.txt = "Hello mayor of my city! My name is Bob, I will be your assistant at the beginning of the game. First, let's earn 100 coins to build the first house. Click on City Hall";
        }
        obj2 = Instantiate(tutorPrefab, parent);
        playerInfo.tutoriaPlace++;
    }
    
    public void InstaniatingSecondPart()
    {
        TutorScript.isOpened = true;
        if (Yandex.Instance.lang=="ru")
        {
            TutorScript.txt = "Отлично, теперь давай построим хижину на одном из участков, выбери участок и купи постройку";
        }
        else
        {
            TutorScript.txt = "Great, now let's build a hut on one of the plots, choose a plot and buy a building";
        }
        obj2 = Instantiate(tutorPrefab, parent);
        playerInfo.tutoriaPlace++;
    }

    public void InstantiatingThirdPart()
    {
        TutorScript.isOpened = true;
        if (Yandex.Instance.lang=="ru")
        {
            TutorScript.txt = "Отлично, постройки заселяют жители, чем больше жителей, тем прогрессивнее ваш город. Также постройки приносят определённое количество монет в минуту. Когда монеты появятся в банке, ты сможешь их забрать!";
        }
        else
        {
           TutorScript.txt = "Great, the buildings are inhabited by residents, the more residents, the more progressive your city is. Buildings also bring a certain number of coins per minute. When the coins appear in the bank, you can pick them up!";
        }

        obj2 = Instantiate(tutorPrefab, parent);
        playerInfo.tutoriaPlace++;
    }

    public void InstantiatingFourthPart()
    {
        TutorScript.isOpened = true;
        if (Yandex.Instance.lang=="ru")
        {
            TutorScript.txt = "Также в игре есть магазин, в котором ты можешь приобрести различные улучшения. Кристаллы выпадают из мэрии с некоторым шансом. Обучение завершено. Вперёд, построй город своей мечты!";
        }
        else
        {
           TutorScript.txt = "There is also a shop in the game where you can purchase various upgrades. Crystals drop from City Hall with some chance. Training completed. Go ahead, build the city of your dreams!";
        }
        obj2 = Instantiate(tutorPrefab, parent);
        playerInfo.tutorialIsComleted = true;
    }
    private void Start()
    {
        timeBeforeSave = 0;
        playerInfo = JsonUtility.FromJson<PlayerInfo>(Yandex.Instance.loadData);
        if (playerInfo.tutoriaPlace == 0 && !playerInfo.tutorialIsComleted)
        {
            Invoke("InstantiatingFirstPart", 1.5f);
        }
        else if (playerInfo.tutoriaPlace == 1 & !playerInfo.tutorialIsComleted & playerInfo.coins >= 100)
        {
            InstaniatingSecondPart();
        }
        if (Instance == null)
            Instance = this;
    }

    public void OnClick()
    {
        random = UnityEngine.Random.Range(0, 50);
        if (random == 49) playerInfo.gems++;
        else playerInfo.coins += playerInfo.promoutionPerClick;
        obj = Instantiate(coin, parent);
        Destroy(obj, 0.5f);
        if (playerInfo.coins >= 100 & playerInfo.tutoriaPlace==1 & !playerInfo.tutorialIsComleted)
        {
            InstaniatingSecondPart();
        }
    }

    private void Update()
    {
        textCoins.text = playerInfo.coins.ToString();
        textGems.text = playerInfo.gems.ToString();
        textPeople.text = playerInfo.people.ToString();
        if (!TutorScript.isOpened)
        {
            Destroy(obj2);
        }
        if (playerInfo.tutoriaPlace==4 & !playerInfo.tutorialIsComleted)
        {
            InstantiatingFourthPart();
        }
    }
    private void FixedUpdate()
    {

        timer += Time.deltaTime;
        if ((int)timer > timeBeforeSave)
        {
            timeBeforeSave = (int)timer;
            totalData = JsonUtility.ToJson(playerInfo);
            if (totalData!=Yandex.Instance.jsonString)
            {
                Yandex.Instance.Save();
            }
        }
        if ((int)timer%180==0)
        {
            Yandex.Instance.canBeCalled = true;
        }
        else
        {
            Yandex.Instance.canBeCalled = false;
        }
    }
}
