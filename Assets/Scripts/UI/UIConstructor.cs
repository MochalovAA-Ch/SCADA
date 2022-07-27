using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SCADA
{
    ///ScriptableObject класс-конструктор различных UI элементов
    [CreateAssetMenu( fileName = "UIConstructor", menuName = "ScriptableObjects/UIConstructor" )]
    public class UIConstructor : ScriptableObject
    {
        [SerializeField]
        int RowHeight;
        [SerializeField]
        int TopOffset;


        [SerializeField]
        GameObject TextInputPanelPrefab;
        [SerializeField]
        GameObject IntInputPanelPrefab;
        [SerializeField]
        GameObject Vector2InputPanelPrefab;
        [SerializeField]
        GameObject ColorPickerPanel;



        public GameObject CreateSimpleTextInput( Transform parent, string name, string value, UnityAction<string> onValueConfirmAction, int row )
        {
            GameObject textInputPanel = Instantiate( TextInputPanelPrefab, parent );
            Text text = textInputPanel.GetComponentInChildren<Text>();
            text.text = name;
            InputField textInput = textInputPanel.GetComponentInChildren<InputField>();
            textInput.text = value;
            textInput.onValueChanged.AddListener( onValueConfirmAction );

            SetRow( textInputPanel, row );

            return textInputPanel;
        }


        void AddIntInputValidator( int min, int max, InputField inputField)
        {
            IntInputValidator inputValidator = inputField.gameObject.AddComponent<IntInputValidator>();
            inputValidator.Min = min;
            inputValidator.Max = max;
        }

        public GameObject CreateVector2Input( Transform parent, string name, Vector2 value, Vector2 minVal, Vector2 maxVal, UnityAction<string> onValueConfirmActionX, UnityAction<string> onValueConfirmActionY, int row )
        {
            GameObject textInputPanel = Instantiate( Vector2InputPanelPrefab, parent );
            Text text = textInputPanel.GetComponentInChildren<Text>();
            text.text = name;
            InputField[] textInput = textInputPanel.GetComponentsInChildren<InputField>();
            textInput[0].text = value.x.ToString();
            textInput[1].text = value.y.ToString();
            textInput[0].onSubmit.AddListener( onValueConfirmActionX );
            textInput[1].onSubmit.AddListener( onValueConfirmActionY );
            AddIntInputValidator((int) minVal.x, (int) maxVal.x, textInput[0] );
            AddIntInputValidator( ( int ) minVal.x, ( int ) maxVal.x, textInput[1] );

            SetRow( textInputPanel, row );

            return textInputPanel;
        }

        public GameObject CreateColorPickerPanel( Transform parent,  Widget widget, int row )
        {
            GameObject colorPickerPanel = Instantiate( ColorPickerPanel, parent );

            colorPickerPanel.GetComponentInChildren<ColorPicker>().SetRefs( widget,GameObject.FindObjectOfType<FlexibleColorPicker>( true )  );

            if( widget is RectTransformWidget )
            {
                RectTransformWidget rectWidget = widget as RectTransformWidget;
                Image[] images = colorPickerPanel.gameObject.GetComponentsInChildren<Image>();
                images[1].color = rectWidget.GetColor();
            }

            SetRow( colorPickerPanel, row );

            return colorPickerPanel;
        }

        public GameObject CreateIntInput( Transform parent, string name, int value, int min, int max, UnityAction<string> onValueConfirmAction, int row )
        {
            GameObject textInputPanel = Instantiate( IntInputPanelPrefab, parent );
            Text text = textInputPanel.GetComponentInChildren<Text>();
            text.text = name;
            InputField textInput = textInputPanel.GetComponentInChildren<InputField>();
            textInput.text = value.ToString();
            textInput.onSubmit.AddListener( onValueConfirmAction );
            AddIntInputValidator( min, max, textInput );

            SetRow( textInputPanel, row );

            return textInputPanel;
        }

        private void SetRow( GameObject uiPanel, int row )
        {
            RectTransform rect = uiPanel.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2( rect.anchoredPosition.x, rect.anchoredPosition.y - TopOffset - row * RowHeight );
        }

    }
}

