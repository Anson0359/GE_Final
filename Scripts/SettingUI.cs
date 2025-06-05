using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button closeBtn = null;

    #region Mono
    private void Awake()
    {
        closeBtn.onClick.AddListener(CloseUI);
    }
    #endregion


    private void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
