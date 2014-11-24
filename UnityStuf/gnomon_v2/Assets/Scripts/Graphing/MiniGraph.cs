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
		public Vector2[] points;
		public Vector2[] rawPoints;
		public Main main;
		
	
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
						School school = Main.world.GetSchoolByName (HardcodedSchoolName);
						rawPoints = school.GetEnergyPointsRange (0, 30);
						break;
				case MiniMode.BUILDING:
						Building building = Main.world.GetBuildingByNames (HardcodedSchoolName, HardcodedBuildingName);
						rawPoints = building.GetEnergyPointsRange (0, 30);
						break;
			
				case MiniMode.ROOM:
						Room room = Main.world.GetRoomByNames (HardcodedSchoolName, HardcodedBuildingName, 0);
						rawPoints = room.GetEnergyPointsRange (0, 30);
						break;		
				}
		
				float min = Tools.SingleMin (rawPoints);
				float max = Tools.SingleMax (rawPoints);
				points = Tools.Normalize (rawPoints, height, max, min);
		
				points = Tools.MoveToOrigin (rawPoints, bottom, left, width, height);
		
				
				VectorLine vl = VectorLine.SetLine (cp.GetColorWrapperAt (0).ColorValue, points);
				vl.lineWidth = 20f;
				
				
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
						break;
				case MiniMode.BUILDING:
						title = HardcodedBuildingName + "(" + HardcodedSchoolName + ")";
						break;
				case MiniMode.ROOM:
						title = "Room #101, " + HardcodedBuildingName + " (" + HardcodedSchoolName + ")";
						break;
				}
				
				graphControl.ClearList ();
				graphControl.AddToPointsList (title, rawPoints);
				main.ClearVectorLines ();
				main.SetBackMode (BackMode.HOME);
				graphControl.ShowGraphPanel ();
				
		
		}
		

		
		
		
	
		
		
}
