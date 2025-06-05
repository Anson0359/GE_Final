using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button closeBtn = null;

    private void Awake()
    {
        closeBtn.onClick.AddListener(CloseUI);
    }

    private void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
