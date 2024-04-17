using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    [SerializeField] private Transform fusePoint;
    [SerializeField] private interactionSO fuseInteractionSO;

    public void PlaceFuse(interaction interaction)
    {
        if(interaction.GetInteractionSO() == fuseInteractionSO)
        {
            
        }
    }
}
