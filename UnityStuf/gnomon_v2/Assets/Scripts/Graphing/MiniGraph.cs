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
		
		// Use this for initialization
		void Start ()
		{
				
				canvas1 = gameObject.GetComponent<UISprite> ();
				//VectorLine.SetCamera (Camera.main);
				//VectorLine.SetCamera (this);
				width = canvas1.width;
				height = canvas1.height;
				
				//left = canvas1.worldCorners [0].x;
				left = canvas1.transform.position.x;
				right = left + width;
				
				//top = canvas1.transform.position.y;
				//bottom = top + height;
		
				bottom = canvas1.worldCorners [0].y;
				top = bottom + height;
				
				
				
				Vector3[] points = new Vector3[20];
				
				for (int i=0; i<points.Length; i++) {
						float x = left + i * 4;
						float y = i;
						points [i] = new Vector3 (x, y, 0f);
						Debug.Log ("X " + x + "  Y " + y);
			
				}
				VectorLine.SetCamera (Camera.main);
				Camera cam = VectorLine.GetCamera ();
				cam.transform.position = gameObject.transform.position;
				
				
				
				//VectorLine.MakeLine ("asdf", points,Color.green);
				
				
				
				
				VectorLine.SetLine (Color.green, points);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
