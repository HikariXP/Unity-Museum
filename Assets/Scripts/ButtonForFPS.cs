using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForFPS : MonoBehaviour
{
    public Button MusicStatusButton;
    void Start()
    {
        MusicStatusButton.onClick.AddListener(ChangeMusicStatus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeMusicStatus()
    {
        AllSceneMusic.instance.isPlay = AllSceneMusic.instance.isPlay == true ? false : true;
        AllSceneMusic.instance.OnRefreshMusicStatus();
    }
}
