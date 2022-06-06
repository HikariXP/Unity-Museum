using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public static ItemUI instance { get; private set; }

    public Text ItemName;

    public Text ItemInfoTextObject;

    public Button BackButton;

    public Button ZoomButton;

    public Button ResetRotateButton;

    public Button ChangeMusicButton;

    

    public float RotateSpeed;

    public bool isZoom = false;

    public GameObject ZoomToolGameObject;

    public GameObject ItemGroupGameObject;

    public List<GameObject> ItemList = new List<GameObject>();

    public Vector3 RawInputV3;
    //public Item ItemSelected;

    public void Start()
    {
        ChangeMusicButton.onClick.AddListener(ChangeMusicStatus);
        instance = this;
        BackButton.onClick.AddListener(BackToMuseum);
        ZoomButton.onClick.AddListener(ChangeZoomStatus);
        ResetRotateButton.onClick.AddListener(OnInitRotate);
        ZoomToolGameObject.SetActive(isZoom);
        //if (ItemList.Count > 0)
        //{
        //    foreach (GameObject go in ItemList)
        //    {
        //        go.SetActive(false);
        //    }
        //}
    }

    public void Update()
    {
        RawInputV3 = Input.mousePosition;
        ItemRotate();
    }

    //刷新物体介绍相关数据
    public void RefreshItemInfo()
    {
        if (ItemList[GameManager.instance.SelectItemNum] != null)
        {
            ItemList[GameManager.instance.SelectItemNum].SetActive(true);
            ItemName.text = GameManager.instance.SelectItemName;
            ItemInfoTextObject.text = GameManager.instance.SelectItemInfo;
        }
        else
        {
            Debug.LogWarning("ItemList[Index] doesn't exisit.");
        }
    }

    //返回至博物馆
    private void BackToMuseum()
    {
        if (ItemList[GameManager.instance.SelectItemNum] != null)
        {
            ItemList[GameManager.instance.SelectItemNum].SetActive(false);
        }
        ZoomToolGameObject.SetActive(false);
        isZoom = false;
        GameManager.instance.ToMuseum();
        Cursor.visible = false;
    }


    //放大镜状态切换
    public void ChangeZoomStatus()
    {
        isZoom = isZoom == true ? false : true;
        ZoomToolGameObject.SetActive(isZoom);
    }

    //物体旋转
    public void ItemRotate()
    {
        if (ItemGroupGameObject !=null)
        {
            float h = 0;
            float w = 0;
            if (Input.GetMouseButton(0))
            {
                h = -Input.GetAxis("Mouse X");
                w = -Input.GetAxis("Mouse Y");
            }
            ItemGroupGameObject.transform.Rotate(0, h, 0,Space.World);
            ItemGroupGameObject.transform.Rotate(-w, 0, 0,Space.World);

        }
    }

    public void OnInitRotate()
    {
        ItemGroupGameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void ChangeMusicStatus()
    {
        AllSceneMusic.instance.isPlay = AllSceneMusic.instance.isPlay == true ? false : true;
        AllSceneMusic.instance.OnRefreshMusicStatus();
    }
}
