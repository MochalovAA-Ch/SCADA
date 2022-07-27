using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCADA;

namespace SCADA
{
    [CreateAssetMenu( fileName = "WidgetFactory", menuName = "ScriptableObjects/WidgetFactory" )]
    public sealed class WidgetFactory : ScriptableObject
    {
        [SerializeField]
        List<BaseGenerator> figuresGenerator = new List<BaseGenerator>()
    {
        new RectTransformWidgetGenerator( "Triangle", WidgetType.TRIANGLE_UI_RENDER ),
        //new WidgetGenerator( "Rect", WidgetType.RECTANGLE ),
        new RectTransformWidgetGenerator( "Text", WidgetType.TEXT ),
        new RectTransformWidgetGenerator( "Circle", WidgetType.CIRCLE_UI_RENDER ),
        new RectTransformWidgetGenerator( "Rectangle", WidgetType.RECTANGLE_UI_RENDER ),
    };

        public Widget GenerateWidget( WidgetType type )
        {
            BaseGenerator baseGenerator = figuresGenerator.Find( x => x.WidgetType == type );
            if ( baseGenerator != null )
            {
                return baseGenerator.GenerateElement();
            }
            else
            {
                return null;
            }
        }
    }
}

