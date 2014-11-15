using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Tools
{


		public static Vector2[] Normalize (Vector2[] points, float graphTop, float max, float min)
		{
				
				
				//shift down to min
				max -= min;
				
				
				for (int i=0; i<points.Length; i++) {
				
				
						//shift down
						points [i].y -= min;
						//scale so values are btwn 0 and 1
						points [i].y /= max;
						//values btwn 0 and graphTop
						points [i].y *= graphTop;
				}
				
				
				return points;
				
			
	
	
		}
		
		
		public static float SingleMax (Vector2[] points)
		{
				float max = float.MinValue;
		
				foreach (Vector2 v in points) {
						if (v.y > max) {
								max = v.y;
						}
					
				}
				return max;

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
		
		
		public static float SuperMax (List<Vector2[]> pointsList)
		{
				float max = float.MinValue;
				foreach (Vector2[] points in pointsList) {
						float tempMax = SingleMax (points);
						if (tempMax > max) {
								max = tempMax;
						}
				}
				
				return max;
		
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
