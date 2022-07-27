using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SCADA;

public class TriangleRenderer : MaskableGraphic
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
        Triangle triangle = GetComponent<Triangle>();

        Vector2 size = rectTransform.sizeDelta;

        vh.Clear();

        AddVert( vh, new Vector3( -size.x/2, -size.y/2, 0 ) );
        AddVert( vh, new Vector3( 0, size.y/2, 0 ) );
        AddVert( vh, new Vector3( size.x/2, -size.y/2, 0 ) );

        vh.AddTriangle( 0, 1, 2 );
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
