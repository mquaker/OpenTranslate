using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance = null;

    [SerializeField] LanguageList sourceList = null;
    [SerializeField] LanguageList targetList = null;

    [SerializeField] SourceInput sourceInput = null;
    [SerializeField] ResultInput resultInput = null;

    [SerializeField] TranslateButton transButton = null;



    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }



    public void DoTranslate()
    {
        LANGUAGETYPE _sourceLang = this.sourceList.SelectedLanguage;
        LANGUAGETYPE _targetLang = this.targetList.SelectedLanguage;
        string _inputMessage = this.sourceInput.InputMessage;

        TranslateAPI.Instance.Translate((string result) => this.ShowResult(result), _inputMessage, _sourceLang, _targetLang);
    }

    void ShowResult(string result)
    {
        if (this.resultInput != null)
            this.resultInput.UpdateResult(result);
    }
}
