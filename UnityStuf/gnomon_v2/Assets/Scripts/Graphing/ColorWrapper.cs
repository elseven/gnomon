using UnityEngine;
using System.Collections;

public class ColorWrapper
{

		private Color colorValue;
		private string bbColorName;
	
		public Color ColorValue {
				get {
						return colorValue;
				}
	
		}

		public string BBColorName {
				get {
						return bbColorName;
				}
		}
		
		
		public ColorWrapper (Color color)
		{
				colorValue = color;
				
				string hexString = ColorToHex (colorValue);
				bbColorName = "[" + hexString + "]";
		}
		

		
		string ColorToHex (Color32 color)
		{
				string hex = color.r.ToString ("X2") + color.g.ToString ("X2") + color.b.ToString ("X2");
				return hex;
		}
	
		Color HexToColor (string hex)
		{
				byte r = byte.Parse (hex.Substring (0, 2), System.Globalization.NumberStyles.HexNumber);
				byte g = byte.Parse (hex.Substring (2, 2), System.Globalization.NumberStyles.HexNumber);
				byte b = byte.Parse (hex.Substring (4, 2), System.Globalization.NumberStyles.HexNumber);
				return new Color32 (r, g, b, 255);
		}
		
		
}
