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
    }

    public void Off()
    {

    }
}
