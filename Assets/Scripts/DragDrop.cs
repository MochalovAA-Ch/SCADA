using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace SCADA
{
    public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField]
        WidgetType widgetType;
        [SerializeField]
        WidgetGeneratorRefs widgetGenRefs;

        RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag( PointerEventData eventData )
        {
            Instantiate( this.gameObject, transform.parent );
        }

        //Функция дропа виджета на рабочую область
        public void OnEndDrag( PointerEventData eventData )
        {

            Widget widget = widgetGenRefs.WidgetFactory.GenerateWidget( widgetType );

            if( widget == null )
            {
                Debug.LogError( "Не найден объект типа " + widgetType );
            }


            if( IsInDropArea() )
            {
                widget.SetWidgetUISettingsFactory( widgetGenRefs.WidgetSettingsUIFactory, widgetGenRefs.AreaToDrop );
                widget.selectWidgetChannelSO = widgetGenRefs.SelectedWidgetChannelSO;


                if ( widget is RectTransformWidget )
                {
                    widget.SetParent( widgetGenRefs.AreaToDrop.transform );
                    widget.SetPosition( eventData.position );
                }
                else
                {
                    Vector3 worldPos = Vector3.zero;
                    RectTransformUtility.ScreenPointToWorldPointInRectangle( widgetGenRefs.AreaToDrop, eventData.position, Camera.main, out worldPos );

                    widget.SetPosition( worldPos );
                }
            }

            Destroy( this.gameObject );
        }

        
        ///Драпаем ли мы элемент в рабочую область
        bool IsInDropArea()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData( EventSystem.current );
            eventDataCurrentPosition.position = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll( eventDataCurrentPosition, results );

            bool isInDropArea = false;
            foreach ( var rect in results )
            {
                RectTransform rectTransform = rect.gameObject.GetComponent<RectTransform>();
                if ( rectTransform != null )
                {
                    if ( rectTransform == widgetGenRefs.AreaToDrop )
                    {
                        isInDropArea = true;
                        break;
                    }
                }
            }
            return isInDropArea;
        }


        public void OnDrag( PointerEventData eventData )
        {
            rectTransform.anchoredPosition += eventData.delta;
        }
    }
}

