using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomTool : MonoBehaviour
{
    public Camera ItemCamera;

    public Camera ZoomCamera;

    public Image ZoomImage;

    public Vector3 UITargetV3;
    public Vector3 CameraV3;

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            UITargetV3 = Input.mousePosition;
            ImageFollowMouse();
            ZoomCameraFollowMouse();
        }

    }

    public void ImageFollowMouse()
    {
        ZoomImage.rectTransform.position = UITargetV3;
    }

    public void ZoomCameraFollowMouse()
    {
        //��Ϊ���ֻ��X��Y�ᣬ����Ҫ��������Z��
        CameraV3 = UITargetV3;
        CameraV3.z = ZoomCamera.transform.position.z;
        //��������Ļ����ת������������
        ZoomCamera.transform.position = ItemCamera.ScreenToWorldPoint(CameraV3);
    }

    public void FixedUpdate()
    {
        
    }
}
