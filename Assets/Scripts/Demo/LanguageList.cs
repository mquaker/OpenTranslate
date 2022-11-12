using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageList : MonoBehaviour
{
    Dropdown dropdown = null;

    public LANGUAGETYPE SelectedLanguage { get; private set; }

    void Awake()
    {
        this.dropdown = this.GetComponent<Dropdown>();
        if (this.dropdown != null)
        {
            this.dropdown.onValueChanged.AddListener((int idx) => this.OnValueChanged(idx));

            this.dropdown.options.Clear();
            for (int _i = 0; _i < (int)LANGUAGETYPE.COUNT; _i++)
            {
                Dropdown.OptionData _data = new Dropdown.OptionData();
                _data.text = ((LANGUAGETYPE)_i).ToString();

                this.dropdown.options.Add(_data);
            }

            this.SelectedLanguage = (LANGUAGETYPE)this.dropdown.value;
        }
    }


    void OnValueChanged(int index)
    {
        this.SelectedLanguage = (LANGUAGETYPE)index;
    }
}
