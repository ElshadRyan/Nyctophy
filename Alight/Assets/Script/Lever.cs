using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    GameManager gm;
    public bool start = false;
    public bool finish = false;
    public bool fail = false;
    public bool isMoving = false;
    public GameObject lever;
    public player player;

    float addAngle = 10f;
    float minAngle = 10f;
    float currAnggle;
    private void Start()
    {
        gm = GameManager.instance;
    }
    void Update()
    {
        if(start)
        {
            LeverOpen();
        }
        else if(finish || fail)
        {
            FinishedLever();
        }
    }

    void LeverOpen()
    {
        Vector3 rotationAngles = lever.transform.eulerAngles;

        if (currAnggle >= 90)
        {
            finish = true;
            start = false;
        }
        else if (currAnggle <= 0)
        {
            if (isMoving)
            {
                fail = true;
                start = false;
            }
        }
        if(!finish && !fail)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currAnggle += addAngle;
                lever.transform.rotation = Quaternion.Euler(currAnggle, rotationAngles.y, rotationAngles.z);

            }
            else if (currAnggle > 0)
            {
                currAnggle -= minAngle * Time.deltaTime;
                lever.transform.rotation = Quaternion.Euler(currAnggle, rotationAngles.y, rotationAngles.z);
                isMoving = true;
            }
        }
                        
    }
    public void FinishedLever()
    {
        player.canMove = true;
        isMoving = false;

        if(finish)
        {
            gm.startTheChalenge = true;
            Debug.Log("yeyyy");
            finish = false;
        } 
        
        if(fail)
        {
            Debug.Log("yahhh");
            fail = false;
        }
    }
}
