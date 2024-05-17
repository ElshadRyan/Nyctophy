using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void StartButtonFPS()
    {
        CSVManager.CreateReport();
        SceneManager.LoadScene("FPSLevel");
    }

    public void QuitButtonFPS()
    {
        Application.Quit();
    }

}
