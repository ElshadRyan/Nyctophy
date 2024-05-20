using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundVR : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private AudioSource walking;

    // Update is called once per frame
    void Update()
    {
        WalkSound();
    }

    public void WalkSound()
    {
        if(player.velocity == Vector3.zero)
        {
            walking.Play();
        }
    }
}
