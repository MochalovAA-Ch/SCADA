using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SCADA
{
    public class CircleUIMesh : RectTransformWidget
    {
        public int fillAngle = 360;

        public CircleUIMesh()
        {
            type = WidgetType.CIRCLE_UI_RENDER;
        }

        public override void GenerateWidget()
        {
            graphic = gameObject.AddComponent<CircleRenderer>();
        }

        public override void Deserialize( BinaryReader reader )
        {
            base.Deserialize( reader );
            //”гол заливки
            fillAngle = reader.ReadInt32();
        }

        public override void Serialize( BinaryWriter writer )
        {
            base.Serialize( writer );
            //”гол заливки
            writer.Write( fillAngle );
        }
    }
}

