using UnityEngine;
using System.Collections;
using System.Reflection;
public class RoomSchoolEditControl : MonoBehaviour
{

	
		public GameObject PrefabBuildingContainer;
		public GameObject ParentOfBuildings;
	
	
		public UILabel schoolLabel;
	
		public School theSchool;
		public Team theTeam;
	
	
	
		public void RefreshSchoolContainer (Team team, School school)
		{
		
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
		
				this.theSchool = school;
				this.theTeam = team;
		
		
				schoolLabel.text = theSchool.Name;
				Transform parent = ParentOfBuildings.transform;
		
				//REMOVE ALL PrefabBuildingContainer from Buildings
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
		
				//UIWidget topWidget= ParentOfBuildings.GetComponent<UIWidget>();
				Transform topTransform = ParentOfBuildings.transform;
		
				//ADD BACK ALL PrefabBuildingContainer to Buildings
				for (int i=0; i<theSchool.Buildings.Count; i++) {
						GameObject building = NGUITools.AddChild (ParentOfBuildings, PrefabBuildingContainer);
			
						//ADD building to school container
						building.GetComponent<RoomBuildingEditControl> ().RefreshBuildingContainer (theTeam, theSchool, i);
						UIWidget buildingWidget = building.GetComponent<UIWidget> ();
			
						buildingWidget.topAnchor.target = topTransform;
						buildingWidget.bottomAnchor.target = topTransform;
						buildingWidget.topAnchor.absolute = -30;
						buildingWidget.bottomAnchor.absolute = -60;
			
			
						buildingWidget.leftAnchor.target = parent;
						buildingWidget.rightAnchor.target = parent;
			
			
						topTransform = building.transform;
				}
		
		
		}
}
