using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateButton : MonoBehaviour
{
    void Start()
    {
        Button _button = this.GetComponent<Button>();
        if (_button != null)
            _button.onClick.AddListener(() => MainController.Instance.DoTranslate());
    }
}
