using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    [SerializeField] private hyperateSocket HS;
    [SerializeField] private Light lightIntensity;

    private float heartBeat;
    private float maxHeartBeat = 180f;
    private float minHeartBeat = 60f;

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
        lightIntensity.intensity = 1 - ((heartBeat - minHeartBeat) / (maxHeartBeat - minHeartBeat));
    }
}
