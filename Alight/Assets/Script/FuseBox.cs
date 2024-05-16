using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    GameManager gm;
    public LightAfterPlace lighting;
    public Transform anchorPoint;
    public interactionSO fuseInteractionSO;

    private void Start()
    {
        gm = GameManager.instance;
    }

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
            if(lighting != null)
            {
                lighting.LightingSetActive();
            }

            heldObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
            heldObject.GetComponentInChildren<Rigidbody>().freezeRotation = true;
            heldObject.GetComponentInChildren<Rigidbody>().useGravity = false;

            gm.chalengeCount++;
            gm.taskCount++;

            CSVManager.AppendToReportCH("Enter" + ";" + gm.chalengeCount.ToString() + ";" + Mathf.Round(gm.timer).ToString() + "Second");
        }


        
                        
    }

    
}
