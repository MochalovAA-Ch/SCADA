using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using SCADA;

public class ColorPicker : MonoBehaviour, IPointerDownHandler
{ 

    FlexibleColorPicker colorPicker;
    Widget sourceWidget;

    Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetRefs( Widget widget, FlexibleColorPicker colorPicker )
    {
        sourceWidget = widget;
        this.colorPicker = colorPicker;
    }

    void ChangeColor( Color color)
    {
        img.color = color;
        sourceWidget.ChangeColor( color );
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        if( !colorPicker.gameObject.activeInHierarchy )
        {
            colorPicker.gameObject.SetActive( true );
            
            colorPicker.SetColor( sourceWidget.GetColor() );
            colorPicker.onColorChange.AddListener( ChangeColor );
        }

    }

}
