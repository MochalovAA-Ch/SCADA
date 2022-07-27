using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


namespace SCADA
{
    public class MeshWidget : Widget
    {
        protected Mesh mesh;
        public WidgetData data;

        public MeshWidget()
        {
            data = new WidgetData();
        }

        public override void ChangeColor( Color color)
        {
            throw new System.NotImplementedException();
        }

        public override void GenerateWidget()
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeSize(Vector2 size )
        {
            throw new System.NotImplementedException();
        }

        public override void SetParent( Transform parent )
        {
            throw new System.NotImplementedException();
        }

        public override void SetPosition( Vector3 position )
        {
            transform.position = position;
        }

        public override void Deserialize( BinaryReader reader )
        {
            throw new System.NotImplementedException();
        }

        public override void Serialize( BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }

}

