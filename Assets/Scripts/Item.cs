using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //�����Ӧ��ģ����ţ����ڼ����Ӧ��Ҫ�ļ�����ģ��
    public int ItemNum;
    [Header("��Ʒ����")]
    [Tooltip("����д��Ʒ������")]
    public string ItemName;
    [Header("��Ʒ����")]
    [Tooltip("����д��Ʒ�Ľ���")]
    public string ItemInfo;

    private void Awake()
    {
        gameObject.tag = "Item";
    }
}
