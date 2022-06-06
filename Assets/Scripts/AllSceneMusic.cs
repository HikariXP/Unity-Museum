using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSceneMusic : MonoBehaviour
{
    public static AllSceneMusic instance { get; private set; }
    public AudioSource bgmAudioSource;
    public bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        isPlay = true;
        bgmAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause()
    {
        isPlay = false;
    }

    public void OnPlay()
    {
        isPlay = true;
    }

    public void OnRefreshMusicStatus()
    {
        if (isPlay)
        {
            bgmAudioSource.Play();
        }
        else
        {
            bgmAudioSource.Pause();
        }
    }
}
