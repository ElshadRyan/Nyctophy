using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLeverLogic : MonoBehaviour
{

    GameManager gm;
    private void Start()
    {
        gm = GameManager.instance;
    }

    public void On()
    {
        gm.startTheChalenge = true;
        gm.genIsCompleted = true;
        gm.nextChalenge++;
        CSVManager.AppendToReportCH("Enter" + ";" + gm.chalengeCount.ToString() + ";" + Mathf.Round(gm.timer).ToString() + "Second");

    }

    public void Off()
    {
        gm.startTheChalenge = false;
        gm.genIsCompleted = false;
        gm.nextChalenge--;
        CSVManager.AppendToReportCH("Enter" + ";" + gm.chalengeCount.ToString() + ";" + Mathf.Round(gm.timer).ToString() + "Second");

    }
}
