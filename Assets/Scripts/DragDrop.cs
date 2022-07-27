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

        //������� ����� ������� �� ������� �������
        public void OnEndDrag( PointerEventData eventData )
        {

            Widget widget = widgetGenRefs.WidgetFactory.GenerateWidget( widgetType );

            if( widget == null )
            {
                Debug.LogError( "�� ������ ������ ���� " + widgetType );
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

        
        ///������� �� �� ������� � ������� �������
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

