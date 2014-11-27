using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;
public class GraphControl : MonoBehaviour
{

		//LEFTOFF: ADD TICKS AND X-AXIS LABEL TO GRAPH AND MINI GRAPHS!
		
		//private List<Vector2[]> pointsList = new List<Vector2[]> ();
		private List<Vector2[]> rawPointsList = new List<Vector2[]> ();
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
	
	
		
		private void Setup ()
		{
				VectorLine.SetCamera (Camera.main);
				cam = VectorLine.GetCamera ();
		
		
				combinedTitle = Tools.MakeTitle (titlesList);
				GraphTitle.text = combinedTitle;
		
		
		
				//URGENT WORKING ON THIS
				Vector3 worldBottomLeft = canvas1.worldCorners [0];
				Vector3 worldTopRight = canvas1.worldCorners [2];
				width = canvas1.width;
				height = canvas1.height;
				float max = Tools.SuperMax (rawPointsList);
		
				List<Vector2[]> pointsList = Tools.Map (NGUICam, worldBottomLeft, worldTopRight, rawPointsList);
		
		
				
		
		
				for (int i=0; i<pointsList.Count; i++) {
			
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
		
		
		
				
	
	
				
		}
		
		
		
		public void ClearList ()
		{
				rawPointsList.Clear ();
				titlesList.Clear ();
		
		}
		public void AddToPointsList (string title, Vector2[] points)
		{
		
		
				titlesList.Add (title);
				rawPointsList.Add (points);
			
				
		
		
		}
		
		
		
		public void SetPointsList (List<string> titles, List<Vector2[]> newPointsList)
		{
				rawPointsList = newPointsList;
				titlesList = titles;
				foreach (Vector2[] va in rawPointsList) {
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
