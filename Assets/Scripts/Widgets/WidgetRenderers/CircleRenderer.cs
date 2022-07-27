using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SCADA;

public class CircleRenderer : MaskableGraphic
{

    [SerializeField]
    Texture m_Texture;
    // make it such that unity will trigger our ui element to redraw whenever we change the texture in the inspector
    public Texture texture
    {
        get
        {
            return m_Texture;
        }
        set
        {
            if ( m_Texture == value )
                return;

            m_Texture = value;
            SetVerticesDirty();
            SetMaterialDirty();
        }
    }
    public override Texture mainTexture
    {
        get
        {
            return m_Texture == null ? s_WhiteTexture : m_Texture;
        }
    }

    protected override void OnPopulateMesh( VertexHelper vh )
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        CircleUIMesh circle = GetComponent<CircleUIMesh>();

        float size = Mathf.Min(  rectTransform.sizeDelta.x, rectTransform.sizeDelta.y ) / 2;

        vh.Clear();

        int sides = 32;
        float angle = Mathf.Clamp( (float)circle.fillAngle, 0, 360 ) / (float)sides;
        Vector3 startVector = Vector3.up* size;
        AddVert( vh, Vector3.zero );
        int vertsCount = 1;
        AddVert( vh, startVector );
        vertsCount++;
        for ( int i = 0; i < sides; i++ )
        {
            startVector = Quaternion.Euler( 0, 0, angle ) * startVector;
            AddVert( vh, startVector );
            vertsCount++;
            

            //if( i > 0 )
            {
                vh.AddTriangle( 0, vertsCount - 2, vertsCount - 1 );
            }
        }
        /*AddVert( vh, startVector );
        vh.AddTriangle( 0, vertsCount - 2, vertsCount - 1 );*/

        //vh.AddTriangle( 0, vertsCount - 1, 1 );


    }

    protected override void OnRectTransformDimensionsChange()
    {
        /* base.OnRectTransformDimensionsChange();
         SetVerticesDirty();
         SetMaterialDirty();*/
    }

    void AddVert( VertexHelper vh, Vector3 pos )
    {

        UIVertex vert = UIVertex.simpleVert;
        vert.color = this.color;
        vert.position = pos;

        vh.AddVert( vert );
    }
}
