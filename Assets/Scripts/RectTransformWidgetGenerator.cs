using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    public class RectTransformWidgetGenerator : BaseGenerator
    {
        private RectTransformWidgetGenerator() { }
        public RectTransformWidgetGenerator( string name, WidgetType figureType )
        {
            this.figureName = name;
            this.type = figureType;
        }

        public override Widget GenerateElement()
        {
            GameObject go = new GameObject( figureName );
            go.AddComponent<RectTransform>();

            Widget widget = null;

            switch ( type )
            {
                case WidgetType.TEXT:
                    go.AddComponent<UnityEngine.UI.Text>();
                    widget = go.AddComponent<SCADA.TextScada>();
                    break;
                case WidgetType.TRIANGLE_UI_RENDER:
                    go.AddComponent<CanvasRenderer>();
                    widget = go.AddComponent<TriangleUIMesh>();
                    break;
                case WidgetType.CIRCLE_UI_RENDER:
                    go.AddComponent<CanvasRenderer>();
                    widget = go.AddComponent<CircleUIMesh>();
                    break;
                case WidgetType.RECTANGLE_UI_RENDER:
                    go.AddComponent<CanvasRenderer>();
                    widget = go.AddComponent<RectangleUIMesh>();
                    break;
            }

            if( widget != null )
                widget.GenerateWidget();

            return widget;
        }
    }
}
