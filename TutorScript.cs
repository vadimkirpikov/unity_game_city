using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorScript : MonoBehaviour
{
    [SerializeField] private Text maintext, partText;
    [SerializeField] private Button closeButton;
    public static string txt = "Привет, мэр моего города! Меня зовут Боб, я буду твоим помошником в начале игры. Для начала давай заработаем 100 монет для строительства первого домика. Нажимай на мэрию";
    private string textOfTutorial;
    private int index = 0;
    public static bool isOpened;

    private void AppendText(char x)
    {
        textOfTutorial += x;
    }

    private void Start()
    {
        index = 0;
        closeButton.interactable = false;
        StartCoroutine(AppendingText());
    }
    public void OnClickClose()
    {
        isOpened = false;
        if (MarScript.Instance.playerInfo.tutoriaPlace == 3)
        {
            MarScript.Instance.playerInfo.tutoriaPlace++;
        }
    }

    IEnumerator AppendingText()
    {
        
        while (index<txt.Length)
        {
            yield return new WaitForSeconds(0.1f);
            AppendText(txt[index++]);
        }
        closeButton.interactable = true;
    }

   

    private void Update()
    {
        InfoPrefabScript.isOpened = !isOpened;
        maintext.text = textOfTutorial;
        partText.text = (MarScript.Instance.playerInfo.tutoriaPlace).ToString()+"/4";
    }
}
