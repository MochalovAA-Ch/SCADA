using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    //Cсылка на инстанциированный WidgetUISettings, для его контроля из других модулей
    public class UISettingsRef : MonoBehaviour
    {
        protected WidgetUISettings settingsRef;
        public void SetRef( WidgetUISettings settingsRef ) { this.settingsRef = settingsRef; }
    }
}

