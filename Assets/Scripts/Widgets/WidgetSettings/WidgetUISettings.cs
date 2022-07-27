using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    ///ќбщий абстрактный класс дл€ всех окон настроек
    public abstract class WidgetUISettings : MonoBehaviour
    {
        protected Vector2 MinSize = new Vector2( 10, 10 );
        protected Vector2 MaxSize = new Vector2( 999, 999 );

        private static  int count = 0;  // оличество открытых окон настроек
        public static int Count => count;

        protected Widget sourceWidget;
        protected UIConstructor uiConstructor;
        protected Transform parent;

        private void Awake()
        {
            count++;
            if ( GetComponent<Draggable>() == null )
                gameObject.AddComponent<Draggable>();
        }

        private void OnDestroy()
        {
            count--;
        }

        public void SetSourceWidget( Widget widget)
        {
            sourceWidget = widget;
        }

        public void SetReferences( Widget sourceWidget, Transform parent, UIConstructor uiConstructor )
        {
            this.parent = parent;
            this.sourceWidget = sourceWidget;
            this.uiConstructor = uiConstructor;
        }

        public void SetParent( Transform parent)
        {
            this.parent = parent;
        }

        public void ChangeSizeX( string val )
        {
            int sizeX = ( int ) sourceWidget.size.x;
            int.TryParse( val, out sizeX );
            sourceWidget.ChangeSize( new Vector2( sizeX, sourceWidget.size.y ) );
        }

        public void ChangeSizeY( string val )
        {
            int sizeY = ( int ) sourceWidget.size.y;
            int.TryParse( val, out sizeY );
            sourceWidget.ChangeSize( new Vector2( sourceWidget.size.x, sizeY ) );
        }

        public abstract void ChangeColor();

        public abstract void CreateUI();
    }
}
