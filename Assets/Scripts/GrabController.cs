using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public bool canGrab = false;
    public bool grabbed = false;
    public bool isPutter = false;
    Collider otherCollider = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrab && HandTracker.rightControllerHandClicked && !OtherInUse()){
            //TODO:
            if (isPutter){
                HandTracker.putterGrabbed = true;
            } else {
                HandTracker.ballGrabbed = true;
            }

            if (isPutter){
                transform.position = otherCollider.transform.position;
            }
            transform.position = otherCollider.transform.position;
            transform.rotation = otherCollider.transform.rotation * Quaternion.Euler(180f,0f,0f);
            this.GetComponent<Rigidbody>().useGravity = false;
        } else {   
            this.GetComponent<Rigidbody>().useGravity = true;
            if (isPutter){
                HandTracker.putterGrabbed = false;
            } else {
                HandTracker.ballGrabbed = false;
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Controller")){
            canGrab = true;
            otherCollider = other;
        }
    } 

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Controller")){
            canGrab = false;
            otherCollider = null;
        }
    }

    bool OtherInUse(){
        if (isPutter){
            return HandTracker.ballGrabbed;
        } else {
            return HandTracker.putterGrabbed;
        }
    }
}
