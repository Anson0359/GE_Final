using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance = new MainManager();
    public static MainManager Instance { get { return instance; } }

    public enum Map_Type
    {
        Home,
        MAP_1,
        MAP_2, 
        MAP_3
    }

    //[SerializeField] private GameObject homePage = null;
    [SerializeField] private GameObject loadingPage = null;
    [SerializeField] private GameObject setingUI = null;
    [SerializeField] private List<GameObject> mapPrefabList = new List<GameObject>();

    private Map_Type nowMap = Map_Type.MAP_1;



    /// <summary>
    /// 開關Loading頁面
    /// </summary>
    /// <param name="active">開 / 關</param>
    public void SetLoadingPage(bool active)
    {
        loadingPage.SetActive(active);
    }

    public void SetSetingUI(bool active)
    {
        setingUI.SetActive(active);
    }

    public bool IsOpenSetingUI()
    {
        return setingUI.activeInHierarchy;
    }



    public void SwichMap(Map_Type type)
    {
        if(nowMap == type)
        {
            Debug.LogWarning($"Same map can't switch , maptype = {type}");
            return;
        }

        switch(type)
        {
            case Map_Type.MAP_1:
                break;
            case Map_Type.MAP_2:
                break;
            case Map_Type.MAP_3:
                break;
        }
    }
    
}
