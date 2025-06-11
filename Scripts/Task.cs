using System.Collections;
using TMPro;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskText = null;
    [SerializeField] private TextMeshProUGUI countDownTMP = null;

    private int time = 300;

    private void Awake()
    {
        
    }

    public void startTimer()
    {
        StartCoroutine("TimerStart");
    }

    IEnumerator TimerStart()
    {
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
}
