using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbOn : MonoBehaviour
{
    [SerializeField] private GameObject light;

    

    public void LightOn()
    {        
        light.gameObject.SetActive(true);        
    }

    public void LightOff()
    {
        light.gameObject.SetActive(false);
    }

}
