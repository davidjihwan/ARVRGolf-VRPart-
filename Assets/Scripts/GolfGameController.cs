using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger);
        if (triggerRight > 0.8f){
            HandTracker.rightControllerHandClicked = true;
        } else {
            HandTracker.rightControllerHandClicked = false;
        }
        
    }
}
