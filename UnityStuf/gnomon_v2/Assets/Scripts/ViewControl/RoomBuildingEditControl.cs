using UnityEngine;
using System.Collections;
using System.Reflection;

public class RoomBuildingEditControl : MonoBehaviour
{
		public GameObject PrefabSwitchContainer;
		public GameObject ParentOfRoomSwitch;
	
	
		public UILabel buildingLabel;
	
		public School theSchool;
		public Team theTeam;
		public Building theBuilding;
	
	
		public void RefreshBuildingContainer (Team team, School school, int buildingIndex)
		{
		
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
		
				this.theSchool = school;
				this.theTeam = team;
				this.theBuilding = school.Buildings [buildingIndex];
		
				buildingLabel.text = theBuilding.Name;
				Transform parent = ParentOfRoomSwitch.transform;
		
				//REMOVE ALL PrefabSwitchContainer from Buildings
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
		
				//UIWidget topWidget= ParentOfRoomSwitch.GetComponent<UIWidget>();
				Transform topTransform = ParentOfRoomSwitch.transform;
		
				//ADD BACK ALL PrefabSwitchContainer to Buildings
				for (int i=0; i<theBuilding.Rooms.Count; i++) {
						GameObject room = NGUITools.AddChild (ParentOfRoomSwitch, PrefabSwitchContainer);
			
						//ADD room to building container
						room.GetComponent<RoomSelectControl> ().SetAttachedRoom (theTeam, theSchool, theBuilding, i);
						/*
						UIWidget roomWidget = room.GetComponent<UIWidget> ();
			
						roomWidget.topAnchor.target = topTransform;
						roomWidget.bottomAnchor.target = topTransform;
						roomWidget.topAnchor.absolute = -30;
						roomWidget.bottomAnchor.absolute = -60;
			
			
						roomWidget.leftAnchor.target = parent;
						roomWidget.rightAnchor.target = parent;
						*/
			
						topTransform = room.transform;
				}
		
		
		}
	
}
