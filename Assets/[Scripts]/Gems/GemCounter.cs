using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{
    Text counterText;
    void Start()
    {
        counterText = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(counterText.text != Bluegem.totalGems.ToString())
        {
            counterText.text = Bluegem.totalGems.ToString();
        }
    }
}
