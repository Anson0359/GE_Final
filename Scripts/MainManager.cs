using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class MainManager : MonoBehaviour
{
    private static MainManager instance = new MainManager();
    public static MainManager Instance { get { return instance; } }

    public enum Map_Type
    {
        Village,
        Shoping,
        None
    }

    [Header("Root")]
    [SerializeField] private Transform cavasRoot = null;
    [SerializeField] private Transform NGUIRoot = null;

    [Header("Camera")]
    [SerializeField] private CameraFollow mainCamera = null;

    [Header("UI")]
    [SerializeField] private HomePage homePage = null;
    [SerializeField] private Task taskUI = null;
    [SerializeField] private GameObject loadingPage = null;

    [Header("Map Prefab List")]
    [SerializeField] private List<GameObject> mapPrefabList = new List<GameObject>();
    private GameObject nowMapObj = null;

    private Map_Type nowMap = Map_Type.None;


    /// <summary>
    /// 開關Loading頁面
    /// </summary>
    /// <param name="active">開 / 關</param>
    public void SetLoadingPage(bool active)
    {
        loadingPage.SetActive(active);
    }

    public void SwichMap(Map_Type type)
    {
        if(nowMap == type)
        {
            Debug.LogWarning($"Same map can't switch , mapType = {type}");
            return;
        }

        GameObject newMap = null;
        switch (type)
        {
            case Map_Type.Village:
                newMap = Instantiate(mapPrefabList[(int)Map_Type.Village], NGUIRoot);
                OpenVillage(newMap);
                break;
            case Map_Type.Shoping:

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

    private void OpenVillage(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError($"[MainManager] CreateMap {Map_Type.Village.ToString()} failed");
            return;
        }
        RemoveNowMap();
        Village village = obj.GetComponent<Village>();
        village.Init();
        nowMapObj = obj;
    }

    private void OpenShoping(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError($"[MainManager] CreateMap {Map_Type.Village.ToString()} failed");
            return;
        }
        RemoveNowMap();
        Village village = obj.GetComponent<Village>();
        village.Init();
        nowMapObj = obj;
    }
    
}
