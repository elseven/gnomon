using UnityEngine;
using System.Collections;

public class Tools
{



		public static Vector2[] MoveToOrigin (Vector2[] points, float bottom, float left, float width, float height)
		{
		
		
				for (int i=0; i<points.Length; i++) {
						float x = left + i * width / points.Length;
						//float y = bottom + i * height / points.Length;
						float y = bottom + points [i].y;
						points [i] = new Vector2 (x, y);
				}
				
				return points;
		}
		
		public static Vector2 CenterToBottomLeft (Camera cam, Vector2 worldCenter, float canvasWidth, float canvasHeight)
		{
				//Center
				Vector2 centerPoint = cam.WorldToScreenPoint (worldCenter);
		
				float left = 0f;
				float bottom = 0f;
		
				//bottom left
				left = centerPoint.x - canvasWidth / 2.0f;
				bottom = centerPoint.y - canvasHeight / 2.0f;
		
		
		
		
				/*	right = left + canvasWidth;
				top = bottom + canvasHeight;*/
				
				return new Vector2 (left, bottom);
		}
		



}
