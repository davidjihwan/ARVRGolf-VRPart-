using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCounter : MonoBehaviour
{
    private int count = 0;
    public TextMeshProUGUI countText;
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementCount(){
        count += 1;
        countText.text = "Stroke Count: " + count.ToString();
    }

    public void ShowWinText(){
        winText.SetActive(true);
    }
}
