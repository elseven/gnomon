using UnityEngine;
using System.Collections;
using System.Reflection;
public class RoomSchoolEditControl : MonoBehaviour
{

	
		public GameObject PrefabBuildingContainer;
		public GameObject ParentOfBuildings;
	
	
		public UILabel schoolLabel;
		public UIWidget HeaderContainer;
	
		public School theSchool;
		public Team theTeam;
		private Transform parent;
		
		public void RefreshSchoolContainer (Team team, School school)
		{
		
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
		
				
				this.theSchool = school;
				this.theTeam = team;
		
		
				schoolLabel.text = theSchool.Name;
				parent = ParentOfBuildings.transform;
				gameObject.SetActive (true);
				ParentOfBuildings.SetActive (true);
				PrefabBuildingContainer.SetActive (true);
				//REMOVE ALL PrefabBuildingContainer from Buildings
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
						//yield return null;
				}
		
		
				//UIWidget topWidget= ParentOfBuildings.GetComponent<UIWidget>();
				Transform topTransform = ParentOfBuildings.transform;
		
				int topOffset = 0;
				int roomHeight = 30;
				//ADD BACK ALL PrefabBuildingContainer to Buildings
				for (int i=0; i<theSchool.Buildings.Count; i++) {
			
						GameObject building = NGUITools.AddChild (ParentOfBuildings, PrefabBuildingContainer);
			
			
						//ADD building to school container
						int roomCount = building.GetComponent<RoomBuildingEditControl> ().RefreshBuildingContainer (theTeam, theSchool, i);
			
			
						UIWidget buildingWidget = building.GetComponent<UIWidget> ();
			
			
						buildingWidget.topAnchor.target = topTransform;
						buildingWidget.bottomAnchor.target = topTransform;
			
						buildingWidget.topAnchor.absolute = -30 - topOffset;
						buildingWidget.bottomAnchor.absolute = -60 - topOffset;
			
			
						buildingWidget.leftAnchor.target = parent;
						buildingWidget.rightAnchor.target = parent;
			
						topOffset += roomCount * roomHeight;
						topOffset += 60;
						//topTransform = building.transform;
			
			
				}
				
		}
		
	
		
				
}
