using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;



public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text task1Text;
    public Text task2Text;
    public Text task3Text;
    public TMP_Text messageText;

    void Awake()
    {
        messageText.text = "";
        messageText.gameObject.SetActive(false);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateTasks(bool key, bool veg, bool home)
    {
        task1Text.text = (key ? "V" : "X") + " �߰_�_��";
        task2Text.text = (veg ? "V" : "X") + " �R�����n����";
        task3Text.text = (home ? "V" : "X") + " �^��a���f";
    }

    public void ShowMessage(string msg)
    {
        messageText.text = msg;
        messageText.gameObject.SetActive(true);
        CancelInvoke("ClearMessage");
        Invoke("ClearMessage", 2.5f);
    }

    void ClearMessage()
    {
        messageText.text = "";
        messageText.gameObject.SetActive(false);
    }


    IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        messageText.gameObject.SetActive(false);
    }
    public void ShowWinMessage()
    {
        messageText.text = "PASS!!!";
        messageText.gameObject.SetActive(true);
    }

}
