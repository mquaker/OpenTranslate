using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourceInput : MonoBehaviour
{
    InputField input = null;

    public string InputMessage { get; private set; }



    void Awake()
    {
        this.input = this.GetComponent<InputField>();
        if (this.input != null)
            this.input.onValueChanged.AddListener((string value) => this.OnValueChanged(value));
    }


    void OnValueChanged(string value)
    {
        this.InputMessage = value;
    }
}
