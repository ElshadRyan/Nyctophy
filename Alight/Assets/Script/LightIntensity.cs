using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    GameManager gm;
    [SerializeField] private Light lightIntensity;
    [SerializeField] private bool playerLamps;


    private float maxHeartBeat = 180f;
    private float minHeartBeat = 60f;

    void Start()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        IntensityLight();

        
    }

   

    void IntensityLight()
    {
        if(gm.startTheChalenge)
        {
            lightIntensity.intensity = 1 - ((gm.heart - minHeartBeat) / (maxHeartBeat - minHeartBeat));
        }
        else if(playerLamps)
        {
            lightIntensity.intensity = 1;
        }    
        else if(!playerLamps)
        {
            lightIntensity.intensity = 0;
        }
        
    }
}
