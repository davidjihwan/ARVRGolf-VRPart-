using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoleCollisionController : MonoBehaviour
{
    public GameObject textCounter;
    // Start is called before the first frame update
    void Start()
    {
        textCounter = GameObject.FindWithTag("Counter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name.Contains("Hole")){
            this.gameObject.SetActive(false);
            textCounter.GetComponent<TextCounter>().ShowWinText();
            //TODO: win sequence
        }
        else if (other.gameObject.CompareTag("Sensor")){
            textCounter.GetComponent<TextCounter>().IncrementCount();
        }
    }

    // void OnTriggerExit(Collider other){
    //     if (other.gameObject.name.Contains("Putter")){
    //         textCounter.GetComponent<TextCounter>().IncrementCount();
    //     }
    // }
}
