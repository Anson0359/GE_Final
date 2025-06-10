using System;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance = new MainManager();
    public static MainManager Instance { get { return instance; } }

    public enum Map_Type
    {
        HomePage = 0,
        Village = 1,
        MAP_2 = 2, 
        MAP_3 = 3
    }

    [SerializeField] private Transform cavasRoot = null;
    [SerializeField] private Transform NGUIRoot = null;
    [SerializeField] private GameObject loadingPage = null;
    [SerializeField] private GameObject settingUI = null;
    [SerializeField] private List<GameObject> mapPrefabList = new List<GameObject>();
    private GameObject nowMapObj = null;

    private Map_Type nowMap = Map_Type.HomePage;
    

    private void Awake()
    {
        nowMapObj = Instantiate(mapPrefabList[(int)Map_Type.HomePage]);
        //HomePage obj = nowMapObj.GetComponent<HomePage>();
    }



    /// <summary>
    /// 開關Loading頁面
    /// </summary>
    /// <param name="active">開 / 關</param>
    public void SetLoadingPage(bool active)
    {
        loadingPage.SetActive(active);
    }

    public void SetSettingUI(bool active)
    {
        settingUI.SetActive(active);
    }

    //public bool IsOpenSettingUI()
    //{
    //    return settingUI.activeInHierarchy;
    //}



    public void SwichMap(Map_Type type)
    {
        if(nowMap == type)
        {
            Debug.LogWarning($"Same map can't switch , maptype = {type}");
            return;
        }

        GameObject newMap = null;
        switch (type)
        {
            case Map_Type.HomePage:
                newMap = Instantiate(mapPrefabList[(int)Map_Type.HomePage], cavasRoot);
                if (newMap == null)
                {
                    Debug.LogError($"[MainManager] CreateMap {Map_Type.HomePage.ToString()} failed");
                    return;
                }
                RemoveNowMap();
                nowMapObj = newMap;
                break;
            case Map_Type.Village:
                newMap = Instantiate(mapPrefabList[(int)Map_Type.Village], NGUIRoot);
                if (newMap == null)
                {
                    Debug.LogError($"[MainManager] CreateMap {Map_Type.Village.ToString()} failed");
                    return;
                }
                RemoveNowMap();
                nowMapObj = newMap;
                break;
            case Map_Type.MAP_2:

                break;
            case Map_Type.MAP_3:

                break;
        }
        nowMapObj = newMap;
    }
    
    private void RemoveNowMap()
    {
        if( nowMapObj != null)
        {
            Destroy(nowMapObj);
        }
    }
    
}
