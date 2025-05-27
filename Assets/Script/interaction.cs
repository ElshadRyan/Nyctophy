using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    [SerializeField] private interactionSO interactionSO;
    public bool canInteract = true;
    public interactionSO GetInteractionSO()
    {
        return interactionSO;
    }

    
}
