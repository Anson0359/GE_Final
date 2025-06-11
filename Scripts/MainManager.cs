using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
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
    [SerializeField] public CameraFollow mainCamera = null;

    [Header("UI")]
    [SerializeField] private HomePage homePage = null;
    [SerializeField] private Task taskUI = null;
    [SerializeField] private GameObject loadingPage = null;

    [Header("Map Prefab List")]
    [SerializeField] private List<GameObject> mapPrefabList = new List<GameObject>();
    private GameObject nowMapObj = null;

    [Header("對話檔案")]
    [SerializeField] private TextAsset startTask = null;

    private Map_Type nowMap = Map_Type.None;
    private bool isStart = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        SetHomePage(true);
        taskUI.Init();
    }

    public void SetHomePage(bool active)
    {
        homePage.transform.gameObject.SetActive(active);
    }

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
            case Map_Type.None:
                SetHomePage(true);
                RemoveNowMap();
                nowMapObj = null;
                break;
            case Map_Type.Village:
                newMap = Instantiate(mapPrefabList[(int)Map_Type.Village], NGUIRoot);
                OpenVillage(newMap);
                break;
            case Map_Type.Shoping:
                newMap = Instantiate(mapPrefabList[(int)Map_Type.Shoping], NGUIRoot);
                OpenShoping(newMap);
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
            Debug.LogError($"[MainManager] CreateMap {Map_Type.Shoping.ToString()} failed");
            return;
        }
        RemoveNowMap();
        Shoping shoping = obj.GetComponent<Shoping>();
        shoping.Init();
        nowMapObj = obj;
    }
    
    public void SetStartTaskTalk()
    {
        taskUI.gameObject.SetActive(true);
        if (startTask)
            taskUI.ShowTalk(startTask);
    }

    public void GameStart()
    {
        if (isStart)
            return;
        isStart = true;

        nowMapObj.GetComponent<Village>()?.Play();
    }

    public void GameReset()
    {
        isStart = false; ;
    }
}
