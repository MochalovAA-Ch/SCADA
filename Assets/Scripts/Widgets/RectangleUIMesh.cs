using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SCADA
{
    public class RectangleUIMesh : RectTransformWidget
    {
        int cornerAngle = 0;

        public int CornerAngle => cornerAngle;

        public RectangleUIMesh()
        {
            type = WidgetType.RECTANGLE_UI_RENDER;
        }

        public override void GenerateWidget()
        {
            graphic = gameObject.AddComponent<RectRenderer>();
        }

        public void ChangeCornerAngle( int  angle )
        {
            cornerAngle = angle;
            ApplyChanges();
        }


        public override void Serialize( BinaryWriter writer )
        {
            base.Serialize( writer );

            //Угол округления
            writer.Write( cornerAngle );

        }

        public override void Deserialize( BinaryReader reader )
        {
            base.Deserialize( reader );
            cornerAngle = reader.ReadInt32();
        }

    }
}

