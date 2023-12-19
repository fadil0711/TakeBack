using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject HtpPanel;
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        HtpPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonClicked(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void HtpButtonClicked()
    {
        MenuPanel.SetActive(false);
        HtpPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    public void SettingsButtonClicked()
    {
        MenuPanel.SetActive(false);
        HtpPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
    public void CreditsButtonClicked()
    {
        MenuPanel.SetActive(false);
        HtpPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }
    public void QuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Yeay!!");
    }
    public void OkebuttonClicked()
    {
        MenuPanel.SetActive(true);
        HtpPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
}
