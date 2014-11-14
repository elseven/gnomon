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
		
		
				
				width = canvas1.width;
				height = canvas1.height;
				
				
				Vector2 bottomLeft = Tools.CenterToBottomLeft (NGUICam, canvas1.transform.position, width, height);
				left = bottomLeft.x;
				bottom = bottomLeft.y;
				right = left + width;
				top = bottom + height;
				Debug.LogWarning ("left " + left + "  top  " + top + "  width  " + width + "  height  " + height);
				Debug.LogWarning ("right " + right + "  bottom  " + bottom);
			
			
			
				//FIXME: GET ACTUAL DATA INSTEAD OF RANDOM
				Vector2[] points = new Vector2[50];
				
				for (int i=0; i<points.Length; i++) {
						points [i].x = 10f;
						points [i].y = Random.Range (0f, height);
				}
				
				points = Tools.MoveToOrigin (points, bottom, left, width, height);

	
				
				VectorLine.SetLine (Color.green, points);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		Vector2 ConvertPoint (Vector2 point)
		{
		
				Vector3 tempPoint = new Vector3 (point.x, point.y, 0f);
	

				point.x = tempPoint.x;
				point.y = tempPoint.y;
		
			
				return point;
		}
		
		
}
