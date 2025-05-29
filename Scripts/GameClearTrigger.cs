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
                // �i�H�[�W����X��������Φ^�D�e��
                Debug.Log("PASS!!!");
                Time.timeScale = 0f; // ����C��
            }
            else
            {
                UIManager.instance.ShowMessage("SOMETHING FORGET!");
            }
        }
    }
}
