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
	
	
		public UILabel label0;
		public UILabel label1;
		public UILabel label2;
		public UILabel label3;
		public UILabel label4;
		public UILabel label5;
		public UILabel label6;
		public UILabel label7;
		public UILabel label8;
	
	
	
	
	
	
		// Use this for initialization
		void Start ()
		{
				
				
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}				
	
	


		
		private void Setup ()
		{
				VectorLine.SetCamera (Camera.main);
				cam = VectorLine.GetCamera ();
		
				//cam.transform.position = new Vector3 (0f, 0f, 0f);
				//canvas1 = gameObject.GetComponent<UISprite> ();
		
		
		
				width = canvas1.width;
				height = canvas1.height;
		
		
				combinedTitle = Tools.MakeTitle (titlesList);
				GraphTitle.text = combinedTitle;
		
		
				Vector2 bottomLeft = Tools.CenterToBottomLeft (NGUICam, canvas1.transform.position, width, height);
				left = bottomLeft.x;
				bottom = bottomLeft.y;
				//right = left + width;
				//top = bottom + height;
		
		
				
		

				float min = Tools.SuperMin (pointsList);
				float max = Tools.SuperMax (pointsList);
		
		
				
				
				float incValue = (max / 8.0f);
		
				string formatString = "n0";
				if (incValue < .5f) {
						formatString = "n2";
				}
		
		
				label0.text = "0";
				label1.text = incValue.ToString (formatString);
				label2.text = (incValue * 2).ToString (formatString);
				label3.text = (incValue * 3).ToString (formatString);
				label4.text = (incValue * 4).ToString (formatString);
				label5.text = (incValue * 5).ToString (formatString);
				label6.text = (incValue * 6).ToString (formatString);
				label7.text = (incValue * 7).ToString (formatString);
				label8.text = (incValue * 8).ToString (formatString);
		
		
		
		
		
				for (int i=0; i<pointsList.Count; i++) {
						pointsList [i] = Tools.Normalize (pointsList [i], height, max, min);
						pointsList [i] = Tools.MoveToOrigin (pointsList [i], bottom, left, width, height);
						
						if (SharedVariables.DebugGraphs) {
								string pstring = combinedTitle + "_" + i + "\n";
								foreach (Vector2 p in pointsList[i]) {
										pstring += p.y + "\n";
								}
				
								Debug.LogError (pstring);
				
						}
						
						VectorLine vl = new VectorLine (combinedTitle + "_" + i, pointsList [i], Tools.cp.GetColorWrapperAt (i).ColorValue, null, 4f, LineType.Continuous);
						vl.Draw ();
						main.vectorLines.Add (vl);
				}
		
	
				
		}
		
		
		
		public void ClearList ()
		{
				pointsList.Clear ();
				titlesList.Clear ();
		
		}
		public void AddToPointsList (string title, Vector2[] points)
		{
		
			
				if (SharedVariables.DebugGraphs) {
						Debug.Log ("points count = " + points.Length);
				}	
					
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
				Setup ();
				yield return null;
	
		
		
		
		}
	
	
	
	
	
	
}
