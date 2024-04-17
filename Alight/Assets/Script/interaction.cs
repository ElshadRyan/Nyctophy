using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    [SerializeField] private interactionSO interactionSO;

    public interactionSO GetInteractionSO()
    {
        return interactionSO;
    }
}
