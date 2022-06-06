using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUi : MonoBehaviour
{
    public GameObject StartGameObject;

    public Button StartButton;

    public Button HelpButton;

    public Button CloseHelpPanelButton;

    public Button ExitButton;

    public Button ChangeMusicButton;

    public GameObject HelpPanel;
    // Start is called before the first frame update
    void Start()
    {
        ChangeMusicButton.onClick.AddListener(ChangeMusicStatus);
        StartButton.onClick.AddListener(OnStart);
        HelpButton.onClick.AddListener(OnOpenHelp);
        CloseHelpPanelButton.onClick.AddListener(OnCloseHelpPanel);
        ExitButton.onClick.AddListener(OnExit);
    }

    public void OnStart()
    {
        SceneManager.LoadScene("Museum");
    }

    public void OnOpenHelp()
    {
        StartGameObject.SetActive(false);
        HelpPanel.SetActive(true);
    }

    public void OnCloseHelpPanel()
    {
        HelpPanel.SetActive(false);
        StartGameObject.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void ChangeMusicStatus()
    {
        AllSceneMusic.instance.isPlay = AllSceneMusic.instance.isPlay == true ? false : true;
        AllSceneMusic.instance.OnRefreshMusicStatus();
    }
}
