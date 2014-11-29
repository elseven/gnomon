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
		
		public Building theBuilding;
	
	
		public bool IsSelected {
				get {
						return isSelected;
				}
		}
	


		public void SetAttachedRoom (Team team, Building b, int roomIndex)
		{
		
				if (team == null) {
						Debug.LogError ("no team");
				}
		
		
			
				this.theTeam = team;
				//this.theSchool = s;
				this.theBuilding = b;
				
				this.AttachedRoom = theBuilding.Rooms [roomIndex];
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
