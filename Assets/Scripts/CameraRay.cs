using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;

    public float screenW;
    public float screenH;
    public Vector2 screenV2;
    // Start is called before the first frame update
    void Start()
    {
        screenW = Screen.width / 2;
        screenH = Screen.height / 2;
        screenV2 = new Vector2(screenW, screenH);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(screenV2);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.transform.gameObject.tag == "Item")
                {
                    Cursor.visible = true;
                    //GameManager.instance.GMLoadScene(hitInfo.transform.gameObject.GetComponent<Item>().SceneName);
                    //Debug.Log(hitInfo.collider.gameObject+" and "+ hitInfo.collider.gameObject.GetComponent<Item>());

                    //GameManager.instance.ItemSelected = hitInfo.collider.gameObject.GetComponent<Item>();
                    GameManager.instance.SelectItemNum = hitInfo.collider.gameObject.GetComponent<Item>().ItemNum;
                    GameManager.instance.SelectItemName = hitInfo.collider.gameObject.GetComponent<Item>().ItemName;
                    GameManager.instance.SelectItemInfo = hitInfo.collider.gameObject.GetComponent<Item>().ItemInfo;
                    GameManager.instance.LookItem();
                    //GameManager.instance.GMLoadScene();
                }
            }
        }
    }
}
