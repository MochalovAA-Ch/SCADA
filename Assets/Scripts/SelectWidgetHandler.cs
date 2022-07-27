using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SCADA
{
    public class SelectWidgetHandler : MonoBehaviour
    {
        [SerializeField]
        WidgetEventChannelSO selectWidgetChannelSO;
        [SerializeField]
        GameObject panel;
        [SerializeField]
        Text text;


        Widget selectetWidget;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            selectWidgetChannelSO.OnEventRaised += SelectWidget;
        }
       

        void SelectWidget( Widget widget )
        {
            selectetWidget = widget;
            panel.SetActive( true );
            text.text = widget.gameObject.name;
        }

        public void DeleteWidget()
        {
            if ( selectetWidget != null )
            {
                Destroy( selectetWidget.gameObject );
                selectetWidget = null;
                panel.SetActive( false );
            }
        }

        public void ShowWidgetSettings()
        {
            if ( selectetWidget != null )
                selectetWidget.ShowWidgetUISettings();
        }

        public void CleanScene()
        {
            Widget[] widgets = GameObject.FindObjectsOfType<Widget>( true );

            for ( int i = 0; i < widgets.Length; i++ )
            {
                Destroy( widgets[i].gameObject );
            }

            selectetWidget = null;
            panel.SetActive( false );
        }
    }
}


