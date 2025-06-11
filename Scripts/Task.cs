using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [Header("Task")]
    [SerializeField] private Text taskText1 = null;
    [SerializeField] private Text taskText2 = null;
    [SerializeField] private Text taskText3 = null;

    [Header("�˼�")]
    [SerializeField] private TextMeshProUGUI countDownTMP = null;

    [Header("���")]
    [SerializeField] private GameObject talk = null;
    [SerializeField] private Text nameText = null;
    [SerializeField] private Text talkContent = null;
    [SerializeField] private TextAsset textAsset = null;
    [SerializeField] private float delayTime = 1f;

    private int time = 300;
    private string[] lines;
    private int currentLine = 0;

    public void Init()
    {
        talk.SetActive(false);
        countDownTMP.gameObject.SetActive(false);
        taskText1.gameObject.SetActive(false);
        taskText2.gameObject.SetActive(false);
        taskText3.gameObject.SetActive(false);
    }
    public void startTimer()
    {
        StartCoroutine(TimerStart());
    }

    public void ShowTalk(TextAsset  content)
    {
        this.textAsset = content;
        lines = textAsset.text.Split('\n');
        StartCoroutine(ShowDialogue());
    }

    private void SetTask()
    {
        taskText1.gameObject.SetActive(true);
        taskText2.gameObject.SetActive(true);
        taskText3.gameObject.SetActive(true);
        taskText1.text = "�R�Ťߵ�";
        taskText2.text = "�R���L"; 
        taskText3.text = "�R����";
        StartCoroutine(TimerStart());
        
    }

    IEnumerator TimerStart()
    {
        countDownTMP.gameObject.SetActive(true);
        while (time > 0)
        {
            string sec = "";
            if(time % 60 > 9)
            {
                sec = (time % 60).ToString("N0");
            }
            else
            {
                sec = "0" + (time % 60).ToString("N0");
            }
            countDownTMP.text = $"{(time / 60).ToString("N0")}:{sec}";
            yield return new WaitForSeconds(1f);
            time--;
        }
    }

    IEnumerator ShowDialogue()
    {
        talk.gameObject.SetActive (true);
        while (currentLine + 1 < lines.Length)
        {
            nameText.text = lines[currentLine].Trim();
            talkContent.text = lines[currentLine + 1].Trim();
            currentLine += 2;
            yield return new WaitForSeconds(delayTime);
        }

        nameText.text = ""; // ������M�ũΰ���U�@�q
        talkContent.text = ""; // ������M�ũΰ���U�@�q
        talk.gameObject.SetActive (false);
        SetTask();
    }
}
