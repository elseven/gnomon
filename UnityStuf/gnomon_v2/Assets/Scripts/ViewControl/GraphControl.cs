using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;
public class GraphControl : MonoBehaviour
{


		public List<Vector2[]> pointsList = new List<Vector2[]> ();
		float left;
		float right;
		float top;
		float bottom;
		float width;
		float height;
		public UISprite canvas1;
		Camera cam;
		public Camera NGUICam;
		
	
		public Main main;
		List<VectorLine> lineList = new List<VectorLine> ();
	
		// Use this for initialization
		void Start ()
		{
				Init ();
				
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void Init ()
		{
				VectorLine.SetCamera (Camera.main);
				cam = VectorLine.GetCamera ();
		
		
		
				width = canvas1.width;
				height = canvas1.height;
		
		
				Vector2 bottomLeft = Tools.CenterToBottomLeft (NGUICam, canvas1.transform.position, width, height);
				left = bottomLeft.x;
				bottom = bottomLeft.y;
				right = left + width;
				top = bottom + height;
				
		}
		
		
		public void SetPointsList (List<Vector2[]> newPointsList)
		{
				pointsList = newPointsList;
				foreach (Vector2[] va in pointsList) {
						foreach (Vector2 v in va) {
								Debug.Log (v.y);
						}
				}
		}
		
		
		public void ShowGraphPanel ()
		{
				Init ();
				main.ActivateGraph ();
				Debug.Log ("??bottom left width height : " + bottom + " " + left + " " + width + " " + height);
				float min = Tools.SuperMin (pointsList);
				float max = Tools.SuperMax (pointsList);
				for (int i=0; i<pointsList.Count; i++) {
						pointsList [i] = Tools.Normalize (pointsList [i], height, max, min);
						pointsList [i] = Tools.MoveToOrigin (pointsList [i], bottom, left, width, height);
						//VectorLine.SetLine (Color.Lerp (Color.red, Color.blue, (i + 0.0f) / pointsList.Count), pointsList [i]);
						lineList.Add (VectorLine.SetLine (Color.red, pointsList [i]));
				}
				
		
		
		
				
		
		}
	
	
	
	
	
	
}
