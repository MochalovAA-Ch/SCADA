using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SCADA;

public class RectRenderer : MaskableGraphic
{

    [SerializeField]
    Texture m_Texture;
    RectangleUIMesh rectMesh;

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
        if( rectMesh == null )
        {
           rectMesh = GetComponent<RectangleUIMesh>();
        }


        Vector2 size = rectTransform.sizeDelta/2;
        vh.Clear();

        int angle = rectMesh.CornerAngle;
        AddVert( vh, Vector3.zero );

        if ( angle == 0 )
        {
            AddVert( vh, new Vector3( -size.x, size.y, 0.0f ) );
            AddVert( vh, new Vector3( -size.x, -size.y, 0.0f ) );
            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
            AddVert( vh, new Vector3( size.x, -size.y, 0.0f ) );
            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
            AddVert( vh, new Vector3( size.x, size.y, 0.0f ) );
            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
            vh.AddTriangle( 0, 1, vh.currentVertCount - 1 );
        }
        else
        {
            AddLeftTopCorner( vh, angle, size );
            AddLeftBottomCorner( vh, angle, size );
            AddRightBottomCorner( vh, angle, size );
            AddRightTopCorner( vh, angle, size );
            vh.AddTriangle( 0, 1, vh.currentVertCount - 1 );
        }

        
    }
    void AddLeftTopCorner( VertexHelper vh, float angle, Vector3 size )
    {
        float min = Mathf.Min( size.x, size.y );
        float offset = angle / 90;
        float rad = offset * min;

        float x = min * offset - min - Mathf.Cos( angle *Mathf.Deg2Rad);
        float y = min * offset - min - Mathf.Cos( angle *Mathf.Deg2Rad );
        Vector3 center = new Vector3( -size.x - x, size.y+y );

        Vector3 rotationVector =  Vector3.up * rad;
        rotationVector = Quaternion.Euler( 0, 0, 45 - angle/2 ) * rotationVector;
        Vector3 leftCorner = center + rotationVector;

        float deltaY = (size.y - leftCorner.y );

        center += new Vector3( - deltaY, deltaY );
        leftCorner = center + rotationVector;

        AddVert( vh, leftCorner );
        int segmentsCount = 6;
        float segAngle = angle / segmentsCount;

        for( int i = 0; i < segmentsCount; i++ )
        {
            rotationVector = Quaternion.Euler( 0, 0, segAngle ) * rotationVector;
            leftCorner = center + rotationVector;

            AddVert( vh, leftCorner );

            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
        }
    }

    void AddLeftBottomCorner( VertexHelper vh, float angle, Vector3 size )
    {
        float min = Mathf.Min( size.x, size.y );
        float offset = angle / 90;
        float rad = offset * min;

        float x = min * offset - min - Mathf.Cos( angle * Mathf.Deg2Rad );
        float y = min * offset - min - Mathf.Cos( angle * Mathf.Deg2Rad );
        Vector3 center = new Vector3( -size.x - x, -size.y - y );

        Vector3 rotationVector = Vector3.left * rad;
        rotationVector = Quaternion.Euler( 0, 0, 45 - angle / 2 ) * rotationVector;
        Vector3 leftCorner = center + rotationVector;

        float deltaY = ( size.x + leftCorner.x );

        center += new Vector3( -deltaY, -deltaY );
        leftCorner = center + rotationVector;

        AddVert( vh, leftCorner );
        vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );

        int segmentsCount = 6;
        float segAngle = angle / segmentsCount;

        for ( int i = 0; i < segmentsCount; i++ )
        {
            rotationVector = Quaternion.Euler( 0, 0, segAngle ) * rotationVector;
            leftCorner = center + rotationVector;

            AddVert( vh, leftCorner );

            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
        }
    }

    void AddRightBottomCorner( VertexHelper vh, float angle, Vector3 size )
    {
        float min = Mathf.Min( size.x, size.y );
        float offset = angle / 90;
        float rad = offset * min;
        float x = min * offset - min - Mathf.Cos( angle * Mathf.Deg2Rad );
        float y = min * offset - min - Mathf.Cos( angle * Mathf.Deg2Rad );
        Vector3 center = new Vector3( size.x +x, -size.y - y );

        Vector3 rotationVector = Vector3.down * rad;
        rotationVector = Quaternion.Euler( 0, 0, 45 - angle / 2 ) * rotationVector;
        Vector3 leftCorner = center + rotationVector;

        float deltaY = ( size.y + leftCorner.y );

        center += new Vector3( deltaY, -deltaY );
        leftCorner = center + rotationVector;

        AddVert( vh, leftCorner );
        vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );

        int segmentsCount = 6;
        float segAngle = angle / segmentsCount;

        for ( int i = 0; i < segmentsCount; i++ )
        {
            rotationVector = Quaternion.Euler( 0, 0, segAngle ) * rotationVector;
            leftCorner = center + rotationVector;

            AddVert( vh, leftCorner );

            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
        }
    }

    void AddRightTopCorner( VertexHelper vh, float angle, Vector3 size )
    {
        float min = Mathf.Min( size.x, size.y );
        float offset = angle / 90;
        float rad = offset * min;
        float x = min * offset - min - Mathf.Cos( angle * Mathf.Deg2Rad );
        float y = min * offset - min - Mathf.Cos( angle * Mathf.Deg2Rad );
        Vector3 center = new Vector3( size.x + x, size.y + y );

        Vector3 rotationVector = Vector3.right * rad;
        rotationVector = Quaternion.Euler( 0, 0, 45 - angle / 2 ) * rotationVector;
        Vector3 leftCorner = center + rotationVector;

        float deltaY = ( size.x - leftCorner.x );

        center += new Vector3( deltaY, deltaY );
        leftCorner = center + rotationVector;

        AddVert( vh, leftCorner );
        vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );

        int segmentsCount = 6;
        float segAngle = angle / segmentsCount;

        for ( int i = 0; i < segmentsCount; i++ )
        {
            rotationVector = Quaternion.Euler( 0, 0, segAngle ) * rotationVector;
            leftCorner = center + rotationVector;

            AddVert( vh, leftCorner );

            vh.AddTriangle( 0, vh.currentVertCount - 1, vh.currentVertCount - 2 );
        }
    }

    protected override void OnRectTransformDimensionsChange()
    {
         base.OnRectTransformDimensionsChange();
         SetVerticesDirty();
         SetMaterialDirty();
    }

    void AddVert( VertexHelper vh, Vector3 pos )
    {

        UIVertex vert = UIVertex.simpleVert;
        vert.color = this.color;
        vert.position = pos;

        vh.AddVert( vert );
    }
}
