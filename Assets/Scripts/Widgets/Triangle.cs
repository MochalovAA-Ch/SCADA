using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCADA
{
    public class Triangle : MeshWidget
    {
        public Triangle()
        {
            type = WidgetType.TRIANGLE_MESH;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void ChangeSize(Vector2 size )
        {

        }

        public override void ChangeColor( Color color)
        {

        }

        public override void GenerateWidget()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            data.vertices = new Vector3[]
            {
           new Vector3( -1, 0, 0 ),
           new Vector3( 0, 1, 0),
           new Vector3( 1,0, 0)
            };

            data.triangles = new int[]
            {
            0,1,2
            };

            mesh.Clear();

            mesh.vertices = data.vertices;
            mesh.triangles = data.triangles;
        }
    }
}

