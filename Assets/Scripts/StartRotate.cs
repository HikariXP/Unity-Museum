using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRotate : MonoBehaviour
{
    public static WaitForEndOfFrame wait = new WaitForEndOfFrame();

    public float rotateSpeed = 1f;


    void Start()
    {
        StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        while (true)
        {
            gameObject.transform.Rotate(0, rotateSpeed, 0, Space.Self);
            yield return wait;
        }
    }
}
