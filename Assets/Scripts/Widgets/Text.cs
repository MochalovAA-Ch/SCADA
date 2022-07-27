using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


namespace SCADA
{
    public class TextScada : RectTransformWidget
    {

        public string textVal;
        public int fontSize;
        

        public TextScada()
        {
            type = WidgetType.TEXT;
        }

        UnityEngine.UI.Text text;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            text = GetComponent<UnityEngine.UI.Text>();
            
        }

        public override void GenerateWidget()
        {
            graphic = GetComponent<Text>();
            text.text = "DefaultText";
            textVal = text.text;
            fontSize = 14;
            text.font = Font.CreateDynamicFontFromOSFont( Font.GetOSInstalledFontNames()[0], fontSize );
        }

        public void ChangeText( string newText )
        {
            text.text = newText;
        }

        public override void Serialize( BinaryWriter writer )
        {
            base.Serialize( writer );
            writer.Write( textVal );
            writer.Write( fontSize );
        }

        public override void Deserialize( BinaryReader reader )
        {
            base.Deserialize( reader );
            textVal = reader.ReadString();
            fontSize = reader.ReadInt32();

            text.text = textVal;
            text.fontSize = fontSize;

        }

    }
}

