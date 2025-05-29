using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool hasKey = false;
    public bool hasVegetable = false;
    public bool hasReturnedHome = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        // 每幀更新 UI 上任務狀態
        UIManager.instance.UpdateTasks(hasKey, hasVegetable, hasReturnedHome);

        //Vector2 pos = GameObject.FindGameObjectWithTag("Player").transform.position;

        //if (pos.x < 7f && pos.y < -15f && hasKey && hasVegetable && hasReturnedHome)
        //{
        //    UIManager.instance.ShowWinMessage();
        //    enabled = false; // 停止執行後續 Update（可選）
        //}
    }
}
