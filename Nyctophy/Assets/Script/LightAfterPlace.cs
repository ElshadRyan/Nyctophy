using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAfterPlace : MonoBehaviour
{
    [SerializeField] private GameObject lighting;
    public void LightingSetActive()
    {
        lighting.SetActive(true);
    }
}
