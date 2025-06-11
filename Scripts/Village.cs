using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class Village : MonoBehaviour
{
    //[SerializeField] private TextAsset talkContent = null;
    [SerializeField] private PlayerController player = null;
    private Vector2 leftBottom = new Vector2(-12, -18);
    private Vector2 rightTop = new Vector2(12, 6);

    public void Init()
    {
        MainManager.Instance.mainCamera.Init(player.transform.gameObject, leftBottom, rightTop);
        StartCoroutine(WaitLoading());
    }
    public void Play()
    {
        MainManager.Instance.SetStartTaskTalk();
    }
    IEnumerator WaitLoading()
    {
        yield return new WaitForSeconds(1f);
        MainManager.Instance.SetLoadingPage(false);
        MainManager.Instance.GameStart();
    }
}
