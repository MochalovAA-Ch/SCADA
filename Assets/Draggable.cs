
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Класс перемещения объектов rectTransform внутри своего родителя
public class Draggable : MonoBehaviour, IDragHandler
{
    RectTransform rectTransform;
    RectTransform rectParent;
    public void OnDrag( PointerEventData eventData )
    {
        if ( rectParent == null )
        {
            rectTransform = GetComponent<RectTransform>();
            rectParent = rectTransform.parent.GetComponent<RectTransform>();
        }

        float x = eventData.position.x - rectParent.rect.width / 2;
        float y = eventData.position.y - rectParent.rect.height / 2;
        rectTransform.anchoredPosition = new Vector2( x, y );
    }
}
