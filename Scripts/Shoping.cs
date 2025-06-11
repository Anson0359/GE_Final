using Unity.VisualScripting;
using UnityEngine;

public class Shoping : MonoBehaviour
{
    [SerializeField] private PlayerController player = null;
    [SerializeField] private Vector2 leftBottom = Vector2.zero;
    [SerializeField] private Vector2 rightTop = Vector2.zero;

    public void Init()
    {
        MainManager.Instance.mainCamera.Init(player.transform.gameObject, leftBottom, rightTop);
    }
}
