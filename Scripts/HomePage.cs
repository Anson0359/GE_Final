using UnityEngine;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    [SerializeField] private Button startBtn = null;
    [SerializeField] private Button settingBtn = null;
    [SerializeField] private Button quitBtn = null;

    #region Mono
    private void Awake()
    {
        startBtn.onClick.AddListener(PlayGame);
        settingBtn.onClick.AddListener(OpenSettingUI);
        quitBtn.onClick.AddListener(QuitGame);
    }
    #endregion

    private void PlayGame()
    {

    }

    private void OpenSettingUI()
    {
        MainManager.Instance.SetSettingUI(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
