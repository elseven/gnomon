using UnityEngine;
using System.Collections;
using Vectrosity;


public class MiniGraph : MonoBehaviour
{


		float left;
		float right;
		float top;
		float bottom;
		float width;
		float height;

		UISprite canvas1;
		VectorLine vl;
		Camera cam;
		public Camera NGUICam;
		// Use this for initialization
		void Start ()
		{
		
				VectorLine.SetCamera (Camera.main);
				cam = VectorLine.GetCamera ();
				//cam.transform.position = new Vector3 (0f, 0f, 0f);
				canvas1 = gameObject.GetComponent<UISprite> ();
		
				/*
				width = canvas1.width;
				height = canvas1.height;
				
				left = 25f;
		
				right = left + width;
		
				
				bottom = 390f;
				top = bottom + height;
				*/
				
				width = canvas1.width;
				height = canvas1.height;
				
				Debug.Log ("position " + gameObject.transform.position);
				Vector2 temp = NGUICam.ScreenToWorldPoint (canvas1.transform.position);
				temp = cam.WorldToScreenPoint (temp);
				left = temp.x;
				top = temp.y;
				float tmp = left + Screen.width / 2.0f;
				Debug.Log ("tmpcheck? " + tmp);
				
				//BOTTOM OF LINE IS IN MIDDLE OF GRAPH
				//top = Screen.height / 2.0f + canvas1.transform.localPosition.y - height;
				
				//LINE TOO HIGH
				//top = Screen.height / 2.0f + canvas1.transform.localPosition.y;
				
				
				//WORKS FOR TOP GRAPH ONLY
				//top = Screen.height / 2.0f + canvas1.transform.localPosition.y - 1.5 * height;
				
				
				tmp = top;
				Debug.Log ("tmpcheck2? " + tmp);
				right = left + width;
				bottom = top + height;
				/*
				top = canvas1.worldCorners [1].y * Screen.height;
				bottom = canvas1.worldCorners [0].y * Screen.height;
				*/
				Debug.LogWarning ("left " + left + "  top  " + top + "  width  " + width + "  height  " + height);
				Debug.LogWarning ("right " + right + "  bottom  " + bottom);
			
				//Debug.LogWarning ("NEW: " + "left " + left + "  top  " + top + "  width  " + width + "  height  " + height);
		
				
				
				Vector2[] points = new Vector2[40];
				
				for (int i=0; i<points.Length; i++) {
						float x = left + i * width / points.Length;
						float y = bottom + i * height / points.Length;
						points [i] = new Vector2 (x, y);
						
				
						points [i] = ConvertPoint (points [i]);
						//Debug.Log ("X " + x + "  Y " + y);
			
				}
			
				//left = cam.WorldToScreenPoint (new Vector3 (left, 0, 0)).x;
				//top = cam.WorldToScreenPoint (new Vector3 (0, top, 0)).y;
				//cam.rect = new Rect (0, 0, 1, height / width);
			
				//cam.transform.position = gameObject.transform.position;
		
				
				
				//VectorLine.MakeLine ("asdf", points,Color.green);
				
				
				
				
				VectorLine.SetLine (Color.green, points);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		Vector2 ConvertPoint (Vector2 point)
		{
		
				Vector3 tempPoint = new Vector3 (point.x, point.y, 0f);
	
				//tempPoint = NGUICam.ViewportToWorldPoint (tempPoint);
				//Debug.LogError ("world point  " + tempPoint.x + "  " + tempPoint.y);
				//tempPoint = cam.WorldToViewportPoint (tempPoint);
				point.x = tempPoint.x;
				point.y = tempPoint.y;
				//point.x -= cam.rect.width / 2;
				//point.y -= cam.rect.height / 2;
			
				return point;
		}
		
		
}
