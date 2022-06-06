using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static WaitForSeconds waitForMOneSecond = new WaitForSeconds(0.1f);

    public GameObject PlayerPerfab;

    public Vector3 PlayerV3;

    public static GameManager instance { get; private set; }

    public bool LoadedPlayerv3 = false;

    //被选择的物品的信息
    public int SelectItemNum;
    public string SelectItemName;
    public string SelectItemInfo;

    //public Item ItemSelected;

    public GameObject MuseumGroup;

    public GameObject LookItemGroup;

    private void Start()
    {
        Cursor.visible = false;
        instance = this;
        DontDestroyOnLoad(gameObject);
        //StartCoroutine(PlayerV3Watcher());
    }

    //前往检视界面
    public void LookItem()
    {
        LookItemGroup.SetActive(true);
        MuseumGroup.SetActive(false);
        ItemUI.instance.RefreshItemInfo();
    }

    //返回至博物馆
    public void ToMuseum()
    {
        LookItemGroup.SetActive(false);
        MuseumGroup.SetActive(true);
    }

    //public void GMLoadScene()
    //{
    //    if (SelectItemName != "")
    //    {
    //        DIYSceneManager.singleton.LoadScene("ItemShow", "", 0.5f);
    //    }
    //}

    //public void ToMuseum()
    //{
    //    DIYSceneManager.singleton.LoadScene("Museum", "", 0.5f);
    //}

    //public void SavePlayerV3()
    //{
    //    PlayerV3 = PlayerPerfab.transform.position;
    //}

    //public void LoadPlayerV3()
    //{
    //    PlayerPerfab.transform.position = PlayerV3; 
    //}

    //IEnumerator PlayerV3Watcher()
    //{
    //    while (true)
    //    {
    //        if (SceneManager.GetActiveScene().name == "Museum")
    //        {
    //            if (!LoadedPlayerv3)
    //            {
    //                LoadPlayerV3();
    //                LoadedPlayerv3 = true;
    //            }
    //        }
    //        else
    //        {
    //            LoadedPlayerv3 = false;
    //        }
    //        yield return waitForMOneSecond;
    //    }
    //}
}
