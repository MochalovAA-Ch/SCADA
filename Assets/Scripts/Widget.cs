using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace SCADA
{
    public enum WidgetType
    {
        TRIANGLE_MESH,
        RECTANGLE_MESH,
        CIRCLE_MESH,
        TRIANGLE_UI_RENDER,
        RECTANGLE_UI_RENDER,
        CIRCLE_UI_RENDER,
        TEXT
    }

    public class WidgetData
    {
        public Vector3[] vertices;
        public int[] triangles;
    }

    public abstract class Widget : MonoBehaviour
    {
        public Widget()
        {
            color = Color.white;
        }

        

        public static Widget selectedWidget;
        public WidgetType type;
        public WidgetEventChannelSO selectWidgetChannelSO;

        protected Color color;
        protected WidgetUISettings settings;
        protected WidgetSettingsUIFactory settingsUIFactory;
        protected Transform widgetSettingsParent;

        public Vector2 size;
        public Vector3 position;
        public abstract void ChangeSize( Vector2 size );
        public abstract void ChangeColor( Color color );
        public abstract void GenerateWidget();

        public abstract void SetPosition( Vector3 position );

        public abstract void SetParent( Transform parent );

        public void SetWidgetUISettingsFactory( WidgetSettingsUIFactory settingsFactory, Transform widgetSettingsParent )
        {
            this.settingsUIFactory = settingsFactory;
            this.widgetSettingsParent = widgetSettingsParent;
        }

        public void ShowWidgetUISettings()
        {
            if( WidgetUISettings.Count == 0 )
            {
                settings = settingsUIFactory.GenerateWidgetUISettings( type, widgetSettingsParent, this );
                settings.CreateUI();
            }
        }

        public void SelectWidget()
        {
            selectWidgetChannelSO.RaiseEvent( this );
        }

        public Color GetColor()
        {
            return color;
        }

        public abstract void Serialize(BinaryWriter writer );

        public abstract void Deserialize( BinaryReader reader );

    }
}

