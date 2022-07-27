using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SCADA
{
    public class RectUISettings : WidgetUISettings
    {
        public override void CreateUI()
        {
            RectangleUIMesh widget = sourceWidget as RectangleUIMesh;

            uiConstructor.CreateVector2Input( parent, "Размер X", widget.size, MinSize, MaxSize, ChangeSizeX, ChangeSizeY, 0 );
            uiConstructor.CreateColorPickerPanel( parent, widget, 1 );
            uiConstructor.CreateSimpleTextInput( parent, "Скругление углов", widget.CornerAngle.ToString(), ChangeAngle, 2 );
        }

        public void ChangeAngle( string val )
        {
            RectangleUIMesh widget = sourceWidget as RectangleUIMesh;
            int angle = ( int ) widget.size.y;
            int.TryParse( val, out angle );
            widget.ChangeCornerAngle( angle );
        }

        public override void ChangeColor()
        {
            throw new System.NotImplementedException();
        }

    }
}

