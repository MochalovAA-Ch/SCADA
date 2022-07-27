using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SCADA
{
    public class CircleUISettings : WidgetUISettings
    {
        int minFill = 0;
        int maxFill = 360;
        public override void CreateUI()
        {
            CircleUIMesh widget = sourceWidget as CircleUIMesh;

            int rowCount = 0;

            uiConstructor.CreateVector2Input( parent, "Размер", widget.size, MinSize, MaxSize, ChangeSizeX, ChangeSizeY, rowCount++ );
            uiConstructor.CreateColorPickerPanel( parent, widget, rowCount++ );
            uiConstructor.CreateIntInput( parent, "Заполнение, градусы", 360, minFill, maxFill, ChangeFillAngle, rowCount++ );
            //uiConstructor.CreateSimpleTextInput( parent, "Текст", widget.DefaultText, ChangeText, 0 );
            //uiConstructor.CreateSimpleTextInput( parent, "Размер шрифта", widget.DefaultFontSize.ToString(), ChangeFontSize, 1 );
        }

        public void ChangeFillAngle( string val ) 
        {
            CircleUIMesh widget = sourceWidget as CircleUIMesh;
            int angle = widget.fillAngle;
            int.TryParse( val, out angle );
            widget.fillAngle =angle;
            widget.ApplyChanges();
            /*widget.DefaultText = val;

            Text textField = sourceWidget.GetComponent<Text>();
            textField.text = val;*/
        }

        public override void ChangeColor()
        {
            throw new System.NotImplementedException();
        }
    }
}

