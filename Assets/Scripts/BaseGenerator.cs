using UnityEngine;

namespace SCADA
{
    public class BaseGenerator //: ScriptableObject
    {
        [SerializeField]
        protected WidgetType type;

        [SerializeField]
        protected string figureName;

        public WidgetType WidgetType => type;

        public virtual Widget GenerateElement()
        {
            throw new System.NotImplementedException();
        }
    }
}

