using UnityEngine;

public class GameClearTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.hasKey && GameManager.instance.hasVegetable && GameManager.instance.hasReturnedHome)
            {
                UIManager.instance.ShowWinMessage();
                // 可以加上延遲幾秒後關閉或回主畫面
                Debug.Log("PASS!!!");
                Time.timeScale = 0f; // 停止遊戲
            }
            else
            {
                UIManager.instance.ShowMessage("SOMETHING FORGET!");
            }
        }
    }
}
