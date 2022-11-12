using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultInput : MonoBehaviour
{
    Text text = null;


    void Awake()
    {
        this.text = this.GetComponentInChildren<Text>();
    }


    public void UpdateResult(string result)
    {
        if (this.text != null)
            this.text.text = result;
    }
}
