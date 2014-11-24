using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;
public class GraphControl : MonoBehaviour
{


		public List<Vector2[]> pointsList = new List<Vector2[]> ();
		public List<string> titlesList = new List<string> ();
		public string combinedTitle;
		float left;
		//float right;
		//float top;
		float bottom;
		float width;
		float height;
		public UISprite canvas1;
		public UILabel GraphTitle;
		Camera cam;
		public Camera NGUICam;
		
	
		public Main main;
	
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
				//	right = left + width;
				//	top = bottom + height;
				
		}
		
		
		
		public void ClearList ()
		{
				pointsList.Clear ();
				titlesList.Clear ();
		
		}
		public void AddToPointsList (string title, Vector2[] points)
		{
				titlesList.Add (title);
				pointsList.Add (points);
			
		
		
		}
		
		
		
		public void SetPointsList (List<string> titles, List<Vector2[]> newPointsList)
		{
				pointsList = newPointsList;
				titlesList = titles;
				foreach (Vector2[] va in pointsList) {
						foreach (Vector2 v in va) {
								Debug.Log (v.y);
						}
				}
		}
		
		
		public void ShowGraphPanel ()
		{
				
				main.ActivateGraph ();		
				StartCoroutine ("ImplShowGraph");
		
		}
		
		IEnumerator ImplShowGraph ()
		{
		
		
				yield return null;
				Init ();
		
				combinedTitle = Tools.MakeTitle (titlesList);
				GraphTitle.text = combinedTitle;
		
				yield return null;
				float min = Tools.SuperMin (pointsList);
				float max = Tools.SuperMax (pointsList);
		
				
				for (int i=0; i<pointsList.Count; i++) {
						pointsList [i] = Tools.Normalize (pointsList [i], height, max, min);
						pointsList [i] = Tools.MoveToOrigin (pointsList [i], bottom, left, width, height);
						//main.vectorLines.Add (VectorLine.SetLine (Tools.cp.GetColorWrapperAt (i).ColorValue, pointsList [i]));
						VectorLine vl = new VectorLine (combinedTitle + "_" + i, pointsList [i], Tools.cp.GetColorWrapperAt (i).ColorValue, null, 4f, LineType.Continuous);
						vl.Draw ();
						main.vectorLines.Add (vl);
				}
		
		
		
		}
	
	
	
	
	
	
}
