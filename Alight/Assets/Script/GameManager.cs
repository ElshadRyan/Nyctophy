using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
   

    public static GameManager instance;
    public bool startTheChalenge = false;
    public int chalengeCount = 0;
    public int taskCount = 0;
    public int nextChalenge = 0;
    public bool genIsCompleted, fuseIsCompleted, lampsIsCompleted = false;
    public GameObject[] lightbulbSocket, fuseSocket;
    public GameObject lightbulb, fuse, fuseSpawnPoint, lightbulbSpawnPoint;

    //public TextMeshProUGUI taskText;
    public string[] taskWord;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //taskText.text = taskWord[0];
    }
    private void Update()
    {
        CheckingIfTaskIsComplete();
        TextTask();
    }

    public void TextTask()
    {
        if(nextChalenge == 1)
        {
            //taskText.text = taskWord[1] + " " + taskCount.ToString() + "/" + fuseSocket.Length.ToString();
        }
        else if(nextChalenge == 2)
        {
            //taskText.text = taskWord[2] + " " + taskCount.ToString() + "/" + lightbulbSocket.Length.ToString();
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
            SceneManager.LoadScene("MainMenuFPS");
        }

        GeneratorChalengeIsCompleted();
        FuseIsCompleted();
    }

    public void AppendTimeWhenTaskCompleted()
    {
        
    }

}
