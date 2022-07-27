using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    public class WidgetGeneratorRefs : MonoBehaviour
    {
        [SerializeField]
        WidgetFactory widgetFactory;
        public WidgetFactory WidgetFactory => widgetFactory;


        [SerializeField]
        WidgetSettingsUIFactory widgetUIFactoty;
        public WidgetSettingsUIFactory WidgetSettingsUIFactory => widgetUIFactoty;

        [SerializeField]
        RectTransform areaToDrop;
        public RectTransform AreaToDrop => areaToDrop;

        [SerializeField]
        WidgetEventChannelSO selectedWidgetChannelSO;
        public WidgetEventChannelSO SelectedWidgetChannelSO => selectedWidgetChannelSO;

    }
}
