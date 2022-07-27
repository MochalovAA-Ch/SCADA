using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    public class TriangleUIMesh : RectTransformWidget
    {
        public TriangleUIMesh()
        {
            type = WidgetType.TRIANGLE_UI_RENDER;
        }

        public override void GenerateWidget()
        {
            graphic = gameObject.AddComponent<TriangleRenderer>();
        }
    }
}

