using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SCADA;

[CreateAssetMenu( menuName = "ScriptableObjects/Events/Widget Event Channel" )]
public class WidgetEventChannelSO : ScriptableObject
{

    public UnityAction<Widget> OnEventRaised;
    public void RaiseEvent( Widget param )
    {
        if ( OnEventRaised != null )
            OnEventRaised.Invoke( param );
    }
}
