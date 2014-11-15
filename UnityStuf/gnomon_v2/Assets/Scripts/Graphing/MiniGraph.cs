using UnityEngine;
using System.Collections;
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
		float right;
		float top;
		float bottom;
		float width;
		float height;

		UISprite canvas1;
		VectorLine vl;
		Camera cam;
		public Camera NGUICam;
		public string HardcodedSchoolName;
		public string HardcodedBuildingName;
		
	
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
				//Debug.LogWarning ("left " + left + "  top  " + top + "  width  " + width + "  height  " + height);
				//Debug.LogWarning ("right " + right + "  bottom  " + bottom);
			
			
			
				//FIXME: GET ACTUAL DATA INSTEAD OF RANDOM
				Vector2[] points = new Vector2[30];
				
				switch (SelectedMiniMode) {
				case MiniMode.SCHOOL:
						School school = Main.world.GetSchoolByName (HardcodedSchoolName);
			
						points = school.GetEnergyPointsRange (0, 30);
						break;
				case MiniMode.BUILDING:
						Building building = Main.world.GetBuildingByNames (HardcodedSchoolName, HardcodedBuildingName);
						points = building.GetEnergyPointsRange (0, 30);
						break;
						
				case MiniMode.ROOM:
						Room room = Main.world.GetRoomByNames (HardcodedSchoolName, HardcodedBuildingName, 0);
						points = room.GetEnergyPointsRange (0, 30);
						break;
						
				}
				
				float min = Tools.SingleMin (points);
				float max = Tools.SingleMax (points);
				points = Tools.Normalize (points, height, max, min);
				
				points = Tools.MoveToOrigin (points, bottom, left, width, height);

	
				
				VectorLine.SetLine (Color.green, points);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
	
		
		
}
