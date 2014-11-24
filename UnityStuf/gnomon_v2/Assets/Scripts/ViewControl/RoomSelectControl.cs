using UnityEngine;
using System.Collections;

public class RoomSelectControl : MonoBehaviour
{

		public Room AttachedRoom;
		public UILabel RoomNumberLabel;
		private bool isSelected = false;
		public GameObject OnSprite;
		public GameObject OffSprite;
	
		public GameObject OnLabel;
		public GameObject OffLabel;
	
		public Team theTeam;
		public School theSchool;
		public Building theBuilding;
	
	
		public bool IsSelected {
				get {
						return isSelected;
				}
		}
	
		// Use this for initialization
		void Start ()
		{
				Refresh ();
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
	
		public void SetAttachedRoom (Team team, School s, Building b, int roomIndex)
		{
		
				if (team == null) {
						Debug.LogError ("no team");
				}
		
		
				if (s == null) {
						Debug.LogError ("no school");
				}
		
		
				this.theTeam = team;
				this.theSchool = s;
				this.theBuilding = b;
				//CHECK GetRoomAt???
				this.AttachedRoom = theBuilding.GetRoomAt (roomIndex);
				isSelected = theTeam.RoomList.Contains (this.AttachedRoom);
				RoomNumberLabel.text = AttachedRoom.Number.ToString ();
				
				Refresh ();
		}
	
	
		public void Toggle ()
		{
				isSelected = !isSelected;
				Refresh ();
		}
	
		public void Refresh ()
		{
				OnSprite.SetActive (isSelected);
				OffSprite.SetActive (!isSelected);
				OnLabel.SetActive (isSelected);
		
				OffLabel.SetActive (!isSelected);
		}
	
	
}
