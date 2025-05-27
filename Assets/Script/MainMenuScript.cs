using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject howToPlayCanvas;

    public void StartButtonFPS()
    {
        CSVManager.CreateReport();
        CSVManager.isFPS = true;
        SceneManager.LoadScene("FPSLevel");
    }

    public void QuitButtonFPS()
    {
        Application.Quit();
    }

    public void HowToPlayButton()
    {
        menuCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
    }

    public void Back()
    {
        menuCanvas.SetActive(true);
        howToPlayCanvas.SetActive(false);
    }
    


}
