using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    //[CreateAssetMenu( fileName = "WidgetGenerator", menuName = "ScriptableObjects/WidgetGenerator" )]
    public class MeshWidgetGenerator : BaseGenerator
    {
        private MeshWidgetGenerator() { }
        public MeshWidgetGenerator( string name, WidgetType figureType )
        {
            this.figureName = name;
            this.type = figureType;
        }

        public override Widget GenerateElement()
        {
            GameObject go = new GameObject( figureName );
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();

            Widget figure = null;

            switch ( type )
            {
                case WidgetType.TRIANGLE_MESH:
                    figure = go.AddComponent<Triangle>();
                    break;

                case WidgetType.RECTANGLE_MESH:

                    break;

                case WidgetType.CIRCLE_MESH:

                    break;
            }

            return figure;
        }
    }
}


