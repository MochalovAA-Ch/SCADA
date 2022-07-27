using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Класс масштабирует рабочую область
public class WorkAreaScaler : MonoBehaviour
{
    [SerializeField]
    RectTransform rightSideArea;
    [SerializeField]
    RectTransform parentCanvas;

    RectTransform rectTransform;

    Vector2 cachaedParentSize;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.sizeDelta = new Vector2 ( parentCanvas.sizeDelta.x - rightSideArea.sizeDelta.x, parentCanvas.sizeDelta.y - rightSideArea.sizeDelta.y );
        cachaedParentSize = parentCanvas.sizeDelta;
    }

    void Update()
    {
        if( cachaedParentSize != parentCanvas.sizeDelta )
        {
            rectTransform.sizeDelta = new Vector2( parentCanvas.sizeDelta.x - rightSideArea.sizeDelta.x, parentCanvas.sizeDelta.y - rightSideArea.sizeDelta.y );
            cachaedParentSize = parentCanvas.sizeDelta;
        }
    }
}
