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

		UISprite canvas;
		// Use this for initialization
		void Start ()
		{
				canvas = gameObject.GetComponent<UISprite> ();
		
				width = canvas.width;
				height = canvas.height;
				
				left = canvas.worldCorners [0].x;
				//left = canvas.transform.position.x;
				right = left + width;
				
				//top = canvas.transform.position.y;
				//bottom = top + height;
		
				bottom = canvas.worldCorners [0].y;
				top = bottom + height;
				
				
				
				Vector2[] points = new Vector2[20];
				
				for (int i=0; i<points.Length; i++) {
						float x = i * width / points.Length;
						float y = Random.Range (top * 1.0f, bottom * 1.0f);
						//float y = i * 4;
						
						x += left;
						//y += top;
						points [i] = new Vector2 (x, y);
						Debug.Log ("X " + x + "  Y " + y);
			
				}
				
				
				
				
				VectorLine.SetLine (Color.green, points);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
