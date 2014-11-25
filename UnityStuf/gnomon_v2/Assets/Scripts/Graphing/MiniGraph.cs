using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;


public class MiniGraph : MonoBehaviour
{

		public enum MiniMode
		{
				SCHOOL,
				BUILDING,
				ROOM
		
		}
		
		public MiniMode SelectedMiniMode;
		float left;
		//float right;
		//float top;
		float bottom;
		float width;
		float height;
		public GameObject Overlay;
		public GraphControl graphControl;
		
		public static ColorPicker cp = new ColorPicker ();
		

		UISprite canvas1;
		
		Camera cam;
		public Camera NGUICam;
		public string HardcodedSchoolName;
		public string HardcodedBuildingName;
		private Vector2[] points;
		private Vector2[] rawPoints;
		public Main main;
		
		public UILabel label0;
		public UILabel label1;
		public UILabel label2;
		public UILabel label3;
		public UILabel label4;
		
		private School theSchool;
		private Building theBuilding;
		private Room theRoom;
		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void Init ()
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
				//right = left + width;
				//top = bottom + height;
		
		
				points = new Vector2[30];
		
				switch (SelectedMiniMode) {
				case MiniMode.SCHOOL:
						theSchool = Main.world.GetSchoolByName (HardcodedSchoolName);
						rawPoints = theSchool.GetEnergyPointsRange (0, 29);
						break;
				case MiniMode.BUILDING:
						theBuilding = Main.world.GetBuildingByNames (HardcodedSchoolName, HardcodedBuildingName);
						rawPoints = theBuilding.GetEnergyPointsRange (0, 29);
						break;
			
				case MiniMode.ROOM:
						theRoom = Main.world.GetRoomByNames (HardcodedSchoolName, HardcodedBuildingName, 0);
						rawPoints = theRoom.GetEnergyPointsRange (0, 29);
						break;		
				}
		
				float min = Tools.SingleMin (rawPoints);
				float max = Tools.SingleMax (rawPoints);
				points = Tools.Normalize (rawPoints, height, max, min);
				//points = Tools.MoveToOrigin (rawPoints, bottom, left, width, height);
				points = Tools.MoveToOrigin (points, bottom, left, width, height);
				
				if (SharedVariables.DebugGraphs) {
						string pstring = "Minigraph_" + SelectedMiniMode.ToString ();
						foreach (Vector2 p in rawPoints) {
								pstring += p.y + "\n";
						}
						Debug.LogError (pstring);
				}
				//VectorLine vl = VectorLine.SetLine (cp.GetColorWrapperAt (0).ColorValue, points);
				//vl.smoothWidth = true;
				//vl.lineWidth = 40f;
				VectorLine vl = new VectorLine ("mini_" + SelectedMiniMode.ToString (), points, cp.GetColorWrapperAt (0).ColorValue, null, 4f, LineType.Continuous);
			
				
				float incValue = (max / 4.0f);
				string formatString = "n0";
				if (incValue < 5f) {
						formatString = "f1";
				}
				
				label0.text = "0";
				label1.text = incValue.ToString (formatString);
				label2.text = (incValue * 2).ToString (formatString);
				label3.text = (incValue * 3).ToString (formatString);
				label4.text = (incValue * 4).ToString (formatString);
				
		
				vl.Draw ();
				main.vectorLines.Add (vl);
				
		}
		
		
		//ON PRESS
		public void Highlight ()
		{
				Overlay.SetActive (true);
		
		}
		
		//ON RELEASE
		public void ViewGraph ()
		{
				
				Overlay.SetActive (false);
				//List<Vector2[]> pointsList = new List<Vector2[]> ();
				//pointsList.Add (rawPoints);
				//graphControl.SetPointsList (title, pointsList);
		
				
				string title = "";
				switch (SelectedMiniMode) {
				case MiniMode.SCHOOL:
						title = HardcodedSchoolName;
						rawPoints = theSchool.GetEnergyPointsRange (0, 29);
						break;
				case MiniMode.BUILDING:
						title = HardcodedBuildingName + "(" + HardcodedSchoolName + ")";
						rawPoints = theBuilding.GetEnergyPointsRange (0, 29);
						break;
				case MiniMode.ROOM:
						title = "Room #101, " + HardcodedBuildingName + " (" + HardcodedSchoolName + ")";
						rawPoints = theRoom.GetEnergyPointsRange (0, 29);
						break;
				}
				
				graphControl.ClearList ();
				graphControl.AddToPointsList (title, rawPoints);
				main.ClearVectorLines ();
				main.SetBackMode (BackMode.HOME);
				graphControl.ShowGraphPanel ();
				
		
		}
		

		
		
		
	
		
		
}
