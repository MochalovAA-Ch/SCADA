using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SCADA
{
    ///Фабрика окна настроек виджетов
    [CreateAssetMenu( fileName = "WidgetSettingsUIFactory", menuName = "ScriptableObjects/WidgetSettingsUIFactory" )]
    public sealed class WidgetSettingsUIFactory : ScriptableObject
    {
        [SerializeField]
        GameObject UIContainerPrefab;
        [SerializeField]
        UIConstructor uiConstructor;

        public WidgetUISettings GenerateWidgetUISettings( WidgetType widgetType, Transform parent, Widget sourceWidget )
        {
            WidgetUISettings widgetUISettings = null;
            GameObject uiContainer = Instantiate( UIContainerPrefab, parent );

            switch ( widgetType )
            {
                case WidgetType.TEXT:
                    widgetUISettings = uiContainer.AddComponent<TextUISettings>();
                    break;

                case WidgetType.RECTANGLE_UI_RENDER:
                    widgetUISettings = uiContainer.AddComponent<RectUISettings>();
                    break;

                case WidgetType.CIRCLE_UI_RENDER:
                    widgetUISettings = uiContainer.AddComponent<CircleUISettings>();
                    break;
                case WidgetType.TRIANGLE_UI_RENDER:
                    widgetUISettings = uiContainer.AddComponent<TriangleUISettings>();
                    break;

            }

            widgetUISettings.SetReferences( sourceWidget, uiContainer.transform, uiConstructor );
            return widgetUISettings;
        }
    }
}
