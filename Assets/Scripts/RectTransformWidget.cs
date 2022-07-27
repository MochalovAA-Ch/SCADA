using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

namespace SCADA
{
    ///Виджет основанный на компонентах RectTransform и MaskableGraphics
    public class RectTransformWidget : Widget, IPointerClickHandler, IDragHandler
    {
        protected MaskableGraphic graphic;

        protected RectTransform rectTransform;
        protected RectTransform rectParent;

        public RectTransformWidget()
        {
            size = new Vector2( 100, 100 );
        }

        private void Awake()
        {
            if ( rectTransform == null )
                rectTransform = GetComponent<RectTransform>();
        }
        public override void ChangeColor( Color color)
        {
            this.color = color;
            if( graphic != null )
            {
                graphic.color = color;
            }
        }

        public override void SetParent( Transform parent )
        {
            transform.SetParent( parent );
            rectParent = parent.GetComponent<RectTransform>();
        }

        //Функция генерации виджета, переопределяется в наследниках
        public override void GenerateWidget()
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeSize( Vector2 size)
        {
            this.size = size;
            rectTransform.sizeDelta = this.size;
            ApplyChanges();
        }

        public override void SetPosition( Vector3 position )
        {
            SetPosition( position );
        }

        public  void OnPointerClick( PointerEventData eventData )
        {
            SelectWidget();
        }

        public void OnDrag( PointerEventData eventData )
        {
            SetPosition( eventData.position );
        }

        void SetPosition( Vector2 position )
        {
            float x = position.x - rectParent.rect.width / 2;
            float y = position.y - rectParent.rect.height / 2;

            x = Mathf.Clamp( x, ( -rectParent.rect.width + rectTransform.rect.width ) / 2, ( rectParent.rect.width - rectTransform.rect.width ) / 2 );
            y = Mathf.Clamp( y, ( -rectParent.rect.height + rectTransform.rect.height ) / 2, ( rectParent.rect.height - rectTransform.rect.height ) / 2 );

            rectTransform.anchoredPosition = new Vector2( x, y );

            this.position = rectTransform.anchoredPosition;

        }

        //Функция для вызова перерисовки MaaskableGraphic, пока только так
        public void ApplyChanges()
        {
            graphic.color = Color.black;
            graphic.color = Color.white;
            graphic.color = color;
        }

        public override void Serialize( BinaryWriter writer )
        {
            //Тип
            writer.Write( ( byte ) type );
            //Позиция
            writer.Write( position.x );
            writer.Write( position.y );
            writer.Write( position.z );
            //Размер
            writer.Write( size.x );
            writer.Write( size.y );
            //Цвет
            writer.Write( color.r );
            writer.Write( color.g );
            writer.Write( color.b );

            //throw new System.NotImplementedException();
        }

        public override void Deserialize( BinaryReader reader )
        {
            //Тип не считываем, считывается выше по стеку вызовов
            //byte type = reader.ReadByte();

            //Позиция
            position.x = reader.ReadSingle();
            position.y = reader.ReadSingle();
            position.z = reader.ReadSingle();

            //Размер
            size.x = reader.ReadSingle();
            size.y = reader.ReadSingle();

            //Цвет
            color.r = reader.ReadSingle();
            color.g = reader.ReadSingle();
            color.b = reader.ReadSingle();

            rectTransform.anchoredPosition = position;
            rectTransform.sizeDelta = size;
            graphic.color = color;


            //throw new System.NotImplementedException();
        }
    }
}

