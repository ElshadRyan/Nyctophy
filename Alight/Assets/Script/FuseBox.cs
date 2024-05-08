using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{

    public LightAfterPlace lighting;
    public Transform anchorPoint;
    public interactionSO fuseInteractionSO;

    public void PlaceObject(GameObject heldObject)
    {

        if (heldObject.GetComponent<interaction>().GetInteractionSO() == fuseInteractionSO)
        {
            lighting = heldObject.GetComponent<LightAfterPlace>();

            heldObject.layer = 0;
            heldObject.transform.parent = anchorPoint.transform;

            heldObject.transform.parent.position = anchorPoint.transform.position;
            heldObject.transform.position = heldObject.transform.parent.position;

            heldObject.transform.parent.rotation = anchorPoint.transform.rotation;
            heldObject.transform.rotation = heldObject.transform.parent.rotation;
            heldObject.GetComponent<interaction>().canInteract = false;
            lighting.LightingSetActive();

            heldObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
            heldObject.GetComponentInChildren<Rigidbody>().freezeRotation = true;
            heldObject.GetComponentInChildren<Rigidbody>().useGravity = false;
            

        }
        
                        
    }

    
}
