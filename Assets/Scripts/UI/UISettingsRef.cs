using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    //C����� �� ����������������� WidgetUISettings, ��� ��� �������� �� ������ �������
    public class UISettingsRef : MonoBehaviour
    {
        protected WidgetUISettings settingsRef;
        public void SetRef( WidgetUISettings settingsRef ) { this.settingsRef = settingsRef; }
    }
}

