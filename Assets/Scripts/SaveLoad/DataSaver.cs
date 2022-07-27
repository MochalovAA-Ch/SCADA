using UnityEngine;
using System.IO;
using System;

namespace SCADA
{
    public class DataSaver : MonoBehaviour
    {
        [SerializeField]
        WidgetGeneratorRefs widgetGenRefs;

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

            string path = GetPath();
            using ( BinaryReader binaryReader = new BinaryReader( new FileStream( path + "GameState.dat", FileMode.Open ) ) )
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

                }

            }
        }

        string GetPath()
        {
            string path = Application.dataPath;
            if ( Application.platform == RuntimePlatform.OSXPlayer )
            {
                path += "/../../";
            }
            else if ( Application.platform == RuntimePlatform.WindowsPlayer )
            {
                path += "/../";
            }
            else if ( Application.platform == RuntimePlatform.WindowsEditor )
            {
                path = "";
                string[] paths = Application.dataPath.Split( '/' );
                for ( int i = 0; i < paths.Length - 1; i++ )
                {
                    path += paths[i] + "/";
                }
            }
            return path;
        }

        void FindSavedObjects()
        {
            Widget[] widgets = GameObject.FindObjectsOfType<Widget>();



            string path = GetPath();
            using ( BinaryWriter binaryWriter = new BinaryWriter( new FileStream(path + "GameState.dat", FileMode.Create ) ) )
            {
                for ( int widgetIndex = 0; widgetIndex < widgets.Length; widgetIndex++ )
                {
                    widgets[widgetIndex].Serialize( binaryWriter );
                }
            }
        }
    }
}



