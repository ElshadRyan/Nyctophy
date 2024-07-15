using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pickPlaceText;
    public GameObject player;
    public Transform holdPos;
    //if you copy from below this point, you are legally required to like the video
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 5f; //how far the player can pickup the object from
    //private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    private GameObject heldObj; //object which we pick up
    private Rigidbody heldObjRb; //rigidbody of object we pick up
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    private bool isOpen = false;
    private RaycastHit hit;
    GameManager gm;
    



    //Reference to script which includes mouse movement of player (looking around)
    //we want to disable the player looking around when rotating the object
    //example below 
    //MouseLookScript mouseLookScript;
    void Start()
    {
        gm = GameManager.instance;
        LayerNumber = LayerMask.NameToLayer("HoldLayer"); //if your holdLayer is named differently make sure to change this ""

        //mouseLookScript = player.GetComponent<MouseLookScript>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                if (hit.transform.gameObject.tag == "Door")
                {
                    OpenDoor(hit.transform.gameObject);
                }
                else if(hit.transform.gameObject.tag == "Lever")
                {
                    Lever(hit.transform.gameObject);
                }
                else if (hit.transform.gameObject.tag == "FuseBox")
                {
                    Placing(hit.transform.gameObject);
                }
                else                   
                {
                    PickUpObj();
                }
            }
            else
            {
                PickUpObj();
            }
            
        }
        TextPopUP();


    }

    private void TextPopUP()
    {
        player Playercs = player.GetComponent<player>();

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if(hit.transform.gameObject.tag == "PickUpInteract")
            {
                interaction interaction = hit.transform.gameObject.GetComponentInParent<interaction>();
                if(interaction.canInteract)
                {
                    pickPlaceText.gameObject.SetActive(true);
                    pickPlaceText.text = "Left click to interact";
                }
                
            }
            else if(hit.transform.gameObject.tag == "FuseBox" && heldObj != null)
            {
                pickPlaceText.gameObject.SetActive(true);
                pickPlaceText.text = "Left click to place object";
            }
            else if(hit.transform.gameObject.tag == "Lever")
            {
                if(!Playercs.canMove)
                {
                    pickPlaceText.gameObject.SetActive(true);
                    pickPlaceText.text = "Spam Space to turn the lever";
                }
                else if(gm.nextChalenge == 0)
                {
                    pickPlaceText.gameObject.SetActive(true);
                    pickPlaceText.text = "Left click to interact";
                }
                else
                {

                }
            }
            else
            {
                pickPlaceText.gameObject.SetActive(false);
            }
        }
    }

    void PickUpObj()
    {
        if (heldObj == null) //if currently not holding anything
        {
            //perform raycast to check if player is looking at object within pickuprange
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                //make sure pickup tag is attached                
                if (hit.transform.GetComponentInParent<interaction>() && hit.transform.GetComponentInParent<interaction>().canInteract)
                {
                    //pass in object hit into the PickUpObject function
                    GameObject parentGameObject = hit.transform.parent.gameObject;
                    PickUpObject(parentGameObject, hit.transform.gameObject);
                }
            }
        }
        else
        {
            if (canDrop == true)
            {
                StopClipping(); //prevents object from clipping through walls
                DropObject();
            }                                                                 
        }
        
        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            //RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
            {
                StopClipping();
                //ThrowObject();
            }

        }
    }

    void Placing(GameObject gameObject)
    {
        if(heldObj != null)
        {
            if(heldObj.GetComponent<interaction>())
            {                
                FuseBox fuseBox = gameObject.GetComponentInParent<FuseBox>();

                if(heldObj.GetComponent<interaction>().GetInteractionSO() == fuseBox.fuseInteractionSO)
                {
                    if(fuseBox.anchorPoint.childCount < 1)
                    {
                        Debug.Log("Masuk");
                        fuseBox.PlaceObject(heldObj);
                        heldObj = null;
                    }
                }
                else
                {
                    DropObject();
                }
            }
        }
    }

    void PickUpObject(GameObject pickUpObj, GameObject children)
    {
        if (pickUpObj.GetComponentInChildren<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponentInChildren<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObj.transform.parent = holdPos.transform; //parent object to holdposition
            children.transform.position = heldObj.transform.position;

            heldObj.transform.position = holdPos.transform.position;
            heldObj.transform.rotation = holdPos.transform.rotation;
            children.transform.position = heldObj.transform.position;
            children.transform.rotation = heldObj.transform.rotation;

            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponentInChildren<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject()
    {
        //re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponentInChildren<Collider>(), player.GetComponentInChildren<Collider>(), false);
        heldObj.GetComponentInChildren<Rigidbody>().freezeRotation = false;
        heldObj.GetComponentInChildren<Rigidbody>().useGravity = true;

        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object

        
    }
    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }
    /*void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))//hold R key to rotate, change this to whatever key you want
        {
            canDrop = false; //make sure throwing can't occur during rotating

            //disable player being able to look around
            //mouseLookScript.verticalSensitivity = 0f;
            //mouseLookScript.lateralSensitivity = 0f;

            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
            //re-enable player being able to look around
            //mouseLookScript.verticalSensitivity = originalvalue;
            //mouseLookScript.lateralSensitivity = originalvalue;
            canDrop = true;
        }
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }*/
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the cliprange
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }

    void OpenDoor(GameObject door)
    {

        Animator animator = door.GetComponentInParent<Animator>();
        if (!isOpen)
        {
            animator.SetBool("IsOpen",true);
            isOpen = true;
        }
        else
        {
            animator.SetBool("IsOpen", false);
            isOpen = false;
        }


    }

    void Lever(GameObject lever)
    {
        player Playercs = player.GetComponent<player>();
        Lever Levercs = lever.GetComponentInParent<Lever>();

        if(!Levercs.done)
        {
            Levercs.player = Playercs;

            Playercs.canMove = false;
            Levercs.start = true;
        }
        

    }
}
