using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    GameManager gm;

    [SerializeField] private AudioSource[] horrorSFX;
    private int intervalScarySound = 90;
    private float numToCheckOnce = 0;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        PlayAudio();
    }

    public void PlayAudio()
    {
        if (Mathf.Approximately(0, Mathf.Round(gm.timer) % intervalScarySound))
        {
            if (numToCheckOnce != Mathf.Round(gm.timer))
            {
                horrorSFX[Random.Range(0, horrorSFX.Length)].Play();
                numToCheckOnce = Mathf.Round(gm.timer);
            }
        }
    }
       
}
    

