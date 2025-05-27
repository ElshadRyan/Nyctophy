using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMode : MonoBehaviour
{
    GameManager gm;
    public TextMeshProUGUI debugHB, debugTime;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        GantiTeks();
    }

    void GantiTeks()
    {
        debugHB.text = gm.heart.ToString();
        debugTime.text = Mathf.Round(gm.timer).ToString();
    }
}
