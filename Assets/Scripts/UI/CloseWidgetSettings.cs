using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///����� �������� ���� ��������
public class CloseWidgetSettings : MonoBehaviour
{
    public void CloseWidget()
    {
        if ( gameObject.transform.parent.GetComponent<RectTransform>() != null )
        {
            Destroy( gameObject.transform.parent.gameObject );
        }
    }
}
