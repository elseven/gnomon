using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Tools
{
		public static ColorPicker cp = new ColorPicker ();
		public static Color LIGHT_BLUE = new Color (51 / 255f, 181 / 255f, 229 / 255f);
		private static int panelWidth = 450;
		private static int panelHeight = 800;
		
		
	
		#region NORMALIZATION STUFF
		private static Vector2[] MoveToOrigin (Vector2[] points, Vector2 bottomLeft, float width, float height)
		{
		
				//width /= panelWidth;
				
				for (int i=0; i<points.Length; i++) {
						float x = bottomLeft.x + i * width / points.Length;
						//float y = bottom + i * height / points.Length;
						float y = bottomLeft.y + points [i].y;
						points [i] = new Vector2 (x, y);
				}
		
				return points;
		}
	
	
		private static Vector2[] Normalize (Vector2[] points, float graphTop, float max, float min)
		{
		
		
				for (int i=0; i<points.Length; i++) {
						points [i].y *= (graphTop / max);
						
				}
		
		
				return points;
		
		
		
		
		}
	
	
		public static Vector2[] Map (Camera nguicam, Vector3 worldBottomLeft, Vector3 worldTopRight, Vector2[] rawPoints)
		{
		
				Vector2[] points;
				
				//TO WORLD POINTS AND WIDTHS
				Vector2 bottomLeft = nguicam.WorldToScreenPoint (worldBottomLeft);
				Vector2 topRight = nguicam.WorldToScreenPoint (worldTopRight);
				float width = Mathf.Abs (topRight.x - bottomLeft.x);
				float height = Mathf.Abs (topRight.y - bottomLeft.y);
				
				float min = Tools.SingleMin (rawPoints);
				float max = Tools.SingleMax (rawPoints);
				
				points = Tools.Normalize (rawPoints, height, max, min);
				points = Tools.MoveToOrigin (points, bottomLeft, width, height);
		
				if (SharedVariables.DebugGraphs) {
						string pstring = "Minigraph_" + worldBottomLeft.y;
						foreach (Vector2 p in rawPoints) {
								pstring += p.y + "\n";
						}
						Debug.LogError (pstring);
				}
				

				
				return points;
		}
	
		public static List<Vector2[]> Map (Camera nguicam, Vector3 worldBottomLeft, Vector3 worldTopRight, List<Vector2[]> rawPointsList)
		{
		
				List<Vector2[]> pointsList = new List<Vector2[]> ();
		
				//TO WORLD POINTS AND WIDTHS
				Vector2 bottomLeft = nguicam.WorldToScreenPoint (worldBottomLeft);
				Vector2 topRight = nguicam.WorldToScreenPoint (worldTopRight);
				float width = Mathf.Abs (topRight.x - bottomLeft.x);
				float height = Mathf.Abs (topRight.y - bottomLeft.y);
		
				float min = Tools.SuperMax (rawPointsList);
				float max = Tools.SuperMax (rawPointsList);
				
				for (int i=0; i<rawPointsList.Count; i++) {
						Vector2[] tempPoints = Tools.Normalize (rawPointsList [i], height, max, min);
						pointsList.Add (MoveToOrigin (tempPoints, bottomLeft, width, height));
				}
				
		
		
		
				return pointsList;
		}
	
		
		
	
		#endregion
	
		
		#region MAX/MIN STUFF
		
		public static float SingleMax (Vector2[] points)
		{
				float max = SimpleMax (points);
				
				
				
				max = BetterMax (max);
				
				//Debug.LogError ("single = " + max);
				
				
				return max;

		}
		
		
		
		public static float SuperMax (List<Vector2[]> pointsList)
		{
		
				string superstring = "Supermax:\n";
				float max = float.MinValue;
				superstring += "list length: " + pointsList.Count + "\n";
				foreach (Vector2[] points in pointsList) {
				
						float tempMax = SimpleMax (points);
						superstring += "tempmax = " + tempMax + "\n";		
						if (tempMax > max) {
								//Debug.LogError ("setting max to = " + tempMax);
								max = tempMax;
						}
						superstring += "max is = " + max;
				}
				
				superstring += "*****prebetter**** = " + max + "\n";
				max = BetterMax (max);
				superstring += "after better = " + max + "\n";
				superstring += "calc normal = " + SingleMax (pointsList [0]);
				
				
				
				Debug.Log (superstring);
				return max;
		
		}
		
	
		
		
		
		
		private static float SimpleMax (Vector2[] points)
		{
				float max = float.MinValue;
		
				foreach (Vector2 v in points) {
						if (v.y > max) {
								max = v.y;
						}
				}
		
				//max = BetterMax (max);
				return max;
			
		}
		
		private static float BetterMax (float max)
		{
			
				int betterAsInt = Mathf.CeilToInt (max);
				float better = betterAsInt + 0f;
				
				
				/*
				if (betterAsInt < 10) {
						return 10;
				} else if (betterAsInt < 25) {
						return 25;
				} else if (betterAsInt < 50) {
						return 50;
				} else if (betterAsInt < 100) {
						return 100;
				}*/
				
				int numDigits = CalculateDigits (betterAsInt);
				
				//float quarterValue = 0.5f * Mathf.Pow (10f, numDigits - 1);
				float quarterValue = 2 * Mathf.Pow (10f, numDigits - 1);
				float roundedToQuarter = quarterValue;
				
				//Debug.LogWarning ("first: " + roundedToQuarter);
				while (roundedToQuarter<=better) {
						roundedToQuarter += quarterValue;
						//Debug.LogWarning ("then: " + roundedToQuarter);
				}
				
				
				
				better = roundedToQuarter;
		
			
				return better;
		}
		
		
		

		public static float SuperMin (List<Vector2[]> pointsList)
		{
				float min = float.MaxValue;
				foreach (Vector2[] points in pointsList) {
						float tempMin = SingleMin (points);
						if (tempMin < min) {
								min = tempMin;
						}
				}
		
				return min;
		
		}
				
						
		public static float SingleMin (Vector2[] points)
		{
		
				float min = float.MaxValue;
				foreach (Vector2 v in points) {
			
						if (v.y < min) {
								min = v.y;
						}
				}
				return min;
		
		}						

	
		private static int CalculateDigits (int value)
		{
		
				int numDigits = 1;
		
				int div = value / 10;
		
				while (div>=1) {
						numDigits++;
						div /= 10;
				}
		
		
				if (SharedVariables.DebugGraphs) {
						Debug.LogWarning ("value= " + value + " #digits= " + numDigits);
				}
		
		
		
		
				return numDigits;
		}
		
		#endregion
		

		#region GRAPH STUFF
		public static string MakeTitle (List<string> rawTitles)
		{
				string formatted = "";
				for (int i=0; i<rawTitles.Count; i++) {
						
						formatted += FormatName (rawTitles [i], i);
				}
				return formatted;
		}
		public static string FormatName (string raw, int index)
		{
				ColorWrapper cw = cp.GetColorWrapperAt (index);
				string formatted = cw.BBColorName + raw + "   ";
				
				return formatted;
		
		}

		#endregion
}
