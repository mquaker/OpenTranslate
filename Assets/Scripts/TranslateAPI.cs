/*
 * https://developers.kakao.com/docs/restapi/translation
 * RestAPI 사용
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public enum LANGUAGETYPE
{
    English,
    Korean,
    Japanese,
    Chinese,
    Vietnamese,
    Indonesian,
    Arabic,
    Bangla,
    German,
    Spanish,
    French,
    Hindi,
    Italian,
    Malaysia,
    Nederlands,
    Portuguese,
    Russian,
    Thai,
    Turkish,

    COUNT
}

public class TranslateAPI : MonoBehaviour
{
    [SerializeField] string API_KEY = "12186811f92cc488b5da7dd5a5550fbd";
    [SerializeField] string API_URL = "https://kapi.kakao.com/v1/translation/translate";

    public static TranslateAPI Instance = null;



    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Translate(System.Action<string> result, string source, LANGUAGETYPE source_lang, LANGUAGETYPE target_lang)
    {
        StartCoroutine(
            this.DoTranslate(result, source, this.GetCountryCode(source_lang), this.GetCountryCode(target_lang))
        );
    }

    public void Translate(string source, LANGUAGETYPE source_lang, LANGUAGETYPE target_lang)
    {
        StartCoroutine(
            this.DoTranslate( (string result) => this.TranslateDone(result),
            source,
            this.GetCountryCode(source_lang),
            this.GetCountryCode(target_lang) )
        );
    }


    IEnumerator DoTranslate(System.Action<string> result, string source, string source_lang, string target_lang)
    {
        WWWForm _data = new WWWForm();
        _data.AddField("src_lang", source_lang);
        _data.AddField("target_lang", target_lang);
        _data.AddField("query", source);

        UnityWebRequest _request = UnityWebRequest.Post(this.API_URL, _data);
        _request.SetRequestHeader("Authorization", string.Format("KakaoAK {0}", this.API_KEY));
        yield return _request.SendWebRequest();

        // 네트워크 에러가 났는지 체크
        if (_request.isNetworkError || _request.isHttpError)
        {
            Debug.Log(_request.error);
        }
        else
        {
            // 응답으로 받은 데이터를 JSON에 담아 필요한 데이터를 파싱한다.
            string _jsonData = _request.downloadHandler.text;
            JSONNode _jsonNode = JSON.Parse(_jsonData);

            string _result = _jsonNode["translated_text"][0][0];

            // 처리가 완료된 결과물을 넘긴다.
            result(_result);
        }
    }

    void TranslateDone(string result)
    {
        Debug.Log(result);
    }



    string GetCountryCode(LANGUAGETYPE lang)
    {
        string _code = "en";

        switch (lang)
        {
            case LANGUAGETYPE.Korean: _code = "kr"; break;
            case LANGUAGETYPE.Japanese: _code = "jp"; break;
            case LANGUAGETYPE.Chinese: _code = "cn"; break;
            case LANGUAGETYPE.Vietnamese: _code = "vi"; break;
            case LANGUAGETYPE.Indonesian: _code = "id"; break;
            case LANGUAGETYPE.Arabic: _code = "ar"; break;
            case LANGUAGETYPE.Bangla: _code = "bn"; break;
            case LANGUAGETYPE.German: _code = "de"; break;
            case LANGUAGETYPE.Spanish: _code = "es"; break;
            case LANGUAGETYPE.French: _code = "fr"; break;
            case LANGUAGETYPE.Hindi: _code = "hi"; break;
            case LANGUAGETYPE.Italian: _code = "it"; break;
            case LANGUAGETYPE.Malaysia: _code = "ms"; break;
            case LANGUAGETYPE.Nederlands: _code = "nl"; break;
            case LANGUAGETYPE.Portuguese: _code = "pt"; break;
            case LANGUAGETYPE.Russian: _code = "ru"; break;
            case LANGUAGETYPE.Thai: _code = "th"; break;
            case LANGUAGETYPE.Turkish: _code = "tr"; break;

        }

        return _code;
    }
}
