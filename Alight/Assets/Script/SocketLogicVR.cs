using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketLogicVR : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    public void On()
    {
        gm.chalengeCount++;
        gm.taskCount++;
        CSVManager.AppendToReportCH("Enter" + ";" + gm.chalengeCount.ToString() + ";" + Mathf.Round(gm.timer).ToString() + "Second");
    }

    public void Off()
    {
        gm.chalengeCount--;
        gm.taskCount--;
        CSVManager.AppendToReportCH("Out" + ";" + gm.chalengeCount.ToString() + ";" + Mathf.Round(gm.timer).ToString() + "Second");
        Debug.Log("Sumber Masalah!!!");

    }
}
