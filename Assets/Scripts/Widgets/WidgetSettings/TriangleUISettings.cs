using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SCADA
{
    public class TriangleUISettings : WidgetUISettings
    {
        public override void CreateUI()
        {
            TriangleUIMesh widget = sourceWidget as TriangleUIMesh;
            int rowCount = 0;

            uiConstructor.CreateVector2Input( parent, "Размер", widget.size, MinSize, MaxSize, ChangeSizeX, ChangeSizeY, rowCount++ );
            uiConstructor.CreateColorPickerPanel( parent, widget, rowCount++ );
        }

        public override void ChangeColor()
        {
            throw new System.NotImplementedException();
        }
    }
}

