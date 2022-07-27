using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SCADA
{
    public class TextUISettings : WidgetUISettings
    {
        public override void CreateUI()
        {
            TextScada widget = sourceWidget as TextScada;
            int rowCount = 0;

            uiConstructor.CreateVector2Input( parent, "Размер", widget.size, MinSize, MaxSize, ChangeSizeX, ChangeSizeY, rowCount++ );
            uiConstructor.CreateSimpleTextInput( parent, "Текст", widget.textVal, ChangeText, rowCount++ );
            uiConstructor.CreateSimpleTextInput( parent, "Размер шрифта", widget.fontSize.ToString(), ChangeFontSize, rowCount++ );
            uiConstructor.CreateColorPickerPanel( parent, sourceWidget, rowCount++ );
        }

        public void ChangeText( string val ) 
        {
            TextScada widget = sourceWidget as TextScada;
            widget.textVal = val;
            Text textField = sourceWidget.GetComponent<Text>();
            textField.text = val;
        }

        public void ChangeFontSize( string val )
        {
            TextScada widget = sourceWidget as TextScada;

            int fontSize = widget.fontSize;
            int.TryParse( val, out fontSize );
            widget.fontSize = fontSize;

            Text textField = sourceWidget.GetComponent<Text>();
            textField.fontSize = fontSize;
        }
        public override void ChangeColor()
        {
            throw new System.NotImplementedException();
        }
    }
}

