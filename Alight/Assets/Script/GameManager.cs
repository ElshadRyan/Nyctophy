using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;
    public float interval = 5f;
    public float cheatInterval = 2f;
    public float numToCheckOnce;
    public hyperateSocket hyperate;
    public GameObject debugMode;    

    public static GameManager instance;
    public bool startTheChalenge = false;
    public int chalengeCount = 0;
    public int taskCount = 0;
    public int nextChalenge = 0;
    public float heart;
    public bool genIsCompleted, fuseIsCompleted, lampsIsCompleted = false;
    public GameObject[] lightbulbSocket, fuseSocket;
    public GameObject lightbulb, fuse, fuseSpawnPoint, lightbulbSpawnPoint;

    public TextMeshProUGUI taskText;
    public string[] taskWord;

    bool isOpen = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        taskText.text = taskWord[0];
    }
    private void Update()
    {
        CheckingIfTaskIsComplete();
        TextTask();
        Heartbeat();
        DebugMode();
        CheatKode();
    }

    void CheatKode()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(nextChalenge == 0)
                {
                    startTheChalenge = true;
                    genIsCompleted = true;
                    nextChalenge++;
                }
                else if (nextChalenge == 1)
                {
                    fuseIsCompleted = true;
                    nextChalenge++;
                }
                
            }
        }
    }
    public void DebugMode()
    {
        
        if(Input.GetKeyDown(KeyCode.F3))
        {
            if(!isOpen)
            {
                debugMode.SetActive(true);
                isOpen = true;
            }
            else
            {
                debugMode.SetActive(false);
                isOpen = false;
            }
        }
    }
    public void Heartbeat()
    {
        heart = hyperate.heartBeat;
        timer += Time.deltaTime;

        if(Mathf.Approximately(0, Mathf.Round(timer)%interval))
        {
            if (numToCheckOnce != Mathf.Round(timer))
            {
                CSVManager.AppendToReportHB(heart.ToString());
                numToCheckOnce = Mathf.Round(timer);
            }
        }

        
    }

    public void TextTask()
    {
        if(nextChalenge == 1)
        {
            taskText.text = taskWord[1] + " " + taskCount.ToString() + "/" + fuseSocket.Length.ToString();
        }
        else if(nextChalenge == 2)
        {
            taskText.text = taskWord[2] + " " + taskCount.ToString() + "/" + lightbulbSocket.Length.ToString();
        }        
    }
    public void GeneratorChalengeIsCompleted()
    {

        if(genIsCompleted)
        {
            if (fuseSpawnPoint.transform.childCount < 1)
            {
                Instantiate(fuse, fuseSpawnPoint.transform.position, fuseSpawnPoint.transform.rotation, fuseSpawnPoint.transform);
            }
        }
    }

    public void FuseIsCompleted()
    {
        if (fuseIsCompleted)
        {
            if (lightbulbSpawnPoint.transform.childCount < 1)
            {
                Instantiate(lightbulb, lightbulbSpawnPoint.transform.position, lightbulbSpawnPoint.transform.rotation, lightbulbSpawnPoint.transform);
            }
        }
    }
    
    public void CheckingIfTaskIsComplete()
    {
        if (chalengeCount == fuseSocket.Length)
        {
            nextChalenge = 2;
            taskCount = 0;
            fuseIsCompleted = true;
        }
        else if(chalengeCount == fuseSocket.Length + lightbulbSocket.Length)
        {
            lampsIsCompleted = true;
        }
        if(lampsIsCompleted)
        {
            CSVManager.AppendToReportCH("Kelar di detik" + ";" + Mathf.Round(timer).ToString());
            if (CSVManager.isFPS)
            {
                SceneManager.LoadScene("MainMenuFPS");
            }
            else
            {
                SceneManager.LoadScene("MainMenuVR");
            }
        }

        GeneratorChalengeIsCompleted();
        FuseIsCompleted();
    }

    public void AppendTimeWhenTaskCompleted()
    {
        
    }

}
