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
				
				canvas1 = gameObject.GetComponent<UISprite> ();
		
				width = canvas1.width;
				height = canvas1.height;
				
				left = 25f;
		
				right = left + width;
		
				
				bottom = 390f;
				top = bottom + height;
				
				
				
				Vector2[] points = new Vector2[20];
				
				for (int i=0; i<points.Length; i++) {
						float x = left + i * width / points.Length;
						float y = Random.Range (bottom, top);
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
		
			
				return point;
		}
		
		
}
