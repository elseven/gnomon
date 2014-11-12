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
				
				
				left = canvas.transform.position.x;
				right = left + width;
				
				top = canvas.transform.position.y;
				bottom = top + height;
				
				
				Vector2[] points = new Vector2[20];
				
				
				
				VectorLine.SetLine (Color.green, points);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
