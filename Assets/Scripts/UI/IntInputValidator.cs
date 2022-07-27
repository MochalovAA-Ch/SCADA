using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Класс валидации вводимых int значений 
public class IntInputValidator : MonoBehaviour
{
    InputField inputField;

    public int Min, Max;

    private void Awake()
    {
        inputField = GetComponent<InputField>();
        inputField.onValueChanged.AddListener( ValidationSeamField );
    }

    private void OnDestroy()
    {
        inputField.onValueChanged.RemoveAllListeners();
        inputField.onSubmit.RemoveAllListeners();
    }

    void ValidationSeamField( string txt )
    {
        if( Min >= 0)
            if ( txt.Length > 0 && txt[0] == '-' ) inputField.text = txt.Remove( 0, 1 );
    }
}
