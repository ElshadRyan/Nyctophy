using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject options;
    public GameObject about;
    public GameObject howToPlay;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button howToPlayButton;
    public Button back;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events;
        startButton.onClick.AddListener(StartGame);
        //optionButton.onClick.AddListener(EnableOption);
        //aboutButton.onClick.AddListener(EnableAbout);
        howToPlayButton.onClick.AddListener(EnableHowToPlay);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
            item.onClick.AddListener(Back);

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        CSVManager.CreateReport();
        SceneManager.LoadScene("VRLevel");
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);

    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }

    public void EnableHowToPlay()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void Back()
    {
        options.SetActive(false);
        about.SetActive(false);
        howToPlay.SetActive(false);
    }
}
