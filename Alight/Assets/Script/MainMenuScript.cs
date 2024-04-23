using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void StartButtonFPS()
    {
        SceneManager.LoadScene("FPSLevel");
    }

    public void QuitButtonFPS()
    {
        Application.Quit();
    }

}
