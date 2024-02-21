using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    [SerializeField] private hyperateSocket HS;
    [SerializeField] private Light lightIntensity;

    private int heartBeat;


    void Start()
    {
        
    }

    void Update()
    {
        TakingHeartBeat();
        IntensityLight();
    }

    void TakingHeartBeat()
    {
        heartBeat = HS.heartBeat;
        Debug.Log(heartBeat);
    }

    void IntensityLight()
    {
        if(heartBeat < 100)
        {
            lightIntensity.intensity = .8f;
        }
        else
        {
            lightIntensity.intensity = .5f;
        }
    }
}
