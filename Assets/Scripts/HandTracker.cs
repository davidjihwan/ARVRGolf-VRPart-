using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public static bool leftControllerHandClicked;
    public static bool rightControllerHandClicked;
    public static bool putterGrabbed;
    public static bool ballGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        leftControllerHandClicked = false;
        rightControllerHandClicked = false;
        putterGrabbed = false;
        ballGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
