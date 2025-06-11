using UnityEngine;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    [SerializeField] private Button startBtn = null;
    [SerializeField] private Button quitBtn = null;

    #region Mono
    private void Awake()
    {
        startBtn.onClick.AddListener(PlayGame);
        quitBtn.onClick.AddListener(QuitGame);
    }
    #endregion

    private void PlayGame()
    {
        Debug.Log("[HomePage] Start!!");
        MainManager.Instance.SetLoadingPage(true);
        MainManager.Instance.SetHomePage(false);
        MainManager.Instance.SwichMap(MainManager.Map_Type.Village);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
