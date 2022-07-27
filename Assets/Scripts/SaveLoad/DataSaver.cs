using UnityEngine;
using System.IO;
using System;

namespace SCADA
{
    public class DataSaver : MonoBehaviour
    {
        [SerializeField]
        WidgetGeneratorRefs widgetGenRefs;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SaveData()
        {
            FindSavedObjects();
        }

        public void LoadData()
        {
            Widget[] figures = GameObject.FindObjectsOfType<Widget>();

            for ( int i = 0; i < figures.Length; i++ )
            {
                Destroy( figures[i].gameObject );
            }
            figures = null;

            //Widget figure = new Widget();
            using ( BinaryReader binaryReader = new BinaryReader( new FileStream( @"D:\GameState.dat", FileMode.Open ) ) )
            {
                while ( binaryReader.BaseStream.Position != binaryReader.BaseStream.Length )
                {
                    byte type = binaryReader.ReadByte();

                    Widget widget = widgetGenRefs.WidgetFactory.GenerateWidget((WidgetType)type );
                    widget.SetWidgetUISettingsFactory( widgetGenRefs.WidgetSettingsUIFactory, widgetGenRefs.AreaToDrop );
                    widget.selectWidgetChannelSO = widgetGenRefs.SelectedWidgetChannelSO;


                    if ( widget is RectTransformWidget )
                    {
                        widget.SetParent( widgetGenRefs.AreaToDrop.transform );
                    }
                    

                    widget.Deserialize( binaryReader );

                   


                    
                    //widget.GenerateWidget

                    /*WidgetData data = new WidgetData();
                    byte figureType = binaryReader.ReadByte();
                    int verticesCount = binaryReader.ReadInt32();

                    //data.figureType = ( WidgetType ) figureType;

                    data.vertices = new Vector3[verticesCount];
                    for ( int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++ )
                    {
                        data.vertices[vertexIndex].x = binaryReader.ReadSingle();
                        data.vertices[vertexIndex].y = binaryReader.ReadSingle();
                        data.vertices[vertexIndex].z = binaryReader.ReadSingle();
                    }

                    int trianglesCount = binaryReader.ReadInt32();
                    data.triangles = new int[trianglesCount];
                    for ( int triangleIndex = 0; triangleIndex < trianglesCount; triangleIndex++ )
                    {
                        data.triangles[triangleIndex] = binaryReader.ReadInt32();
                    }*/

                    //Widget figure = figureGenerator.GenerateWidget( data.figureType );
                    //figure.data = data;
                    //figure.UpdateMesh();
                }

                //figureSeializer.Serialize( test[0], binaryWriter );
            }
        }
        void FindSavedObjects()
        {
            Widget[] widgets = GameObject.FindObjectsOfType<Widget>();

            using ( BinaryWriter binaryWriter = new BinaryWriter( new FileStream( @"D:\GameState.dat", FileMode.Create ) ) )
            {
                for ( int widgetIndex = 0; widgetIndex < widgets.Length; widgetIndex++ )
                {
                    widgets[widgetIndex].Serialize( binaryWriter );
                    //byte t = ( byte ) figures[figureIndex].data.figureType;
                    //binaryWriter.Write( t );
                    //int vertexCount = figures[figureIndex].data.vertices.Length;
                    //binaryWriter.Write( vertexCount );
                    //for ( int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++ )
                    {
                       // binaryWriter.Write( figures[figureIndex].data.vertices[vertexIndex].x );
                       // binaryWriter.Write( figures[figureIndex].data.vertices[vertexIndex].y );
                       // binaryWriter.Write( figures[figureIndex].data.vertices[vertexIndex].z );
                    }

                    //int trianglesCount = figures[figureIndex].data.triangles.Length;
                    //binaryWriter.Write( trianglesCount );
                    /*for ( int triangleIndex = 0; triangleIndex < trianglesCount; triangleIndex++ )
                    {
                        binaryWriter.Write( figures[figureIndex].data.triangles[triangleIndex] );
                    }*/

                    //Widget figure = figureGenerator.GenerateWidget(figures[figureIndex].data.figureType);
                }
            }
        }
    }
}



