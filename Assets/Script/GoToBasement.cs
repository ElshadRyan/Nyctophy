using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBasement : MonoBehaviour
{
    GameManager gm;
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        if(gm.genIsCompleted)
        {
            canvas.gameObject.SetActive(false);
        }

    }

}
