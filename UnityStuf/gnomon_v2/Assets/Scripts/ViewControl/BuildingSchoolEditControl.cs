using UnityEngine;
using System.Collections;
using System.Reflection;
public class BuildingSchoolEditControl : MonoBehaviour
{

		public GameObject PrefabSwitchContainer;
		public GameObject ParentOfBuildingSwitch;
		
		
		public UILabel schoolLabel;
		
		public School theSchool;
		public Team theTeam;
	

		
		public void RefreshSchoolContainer (Team team, School school)
		{
		
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
		
				this.theSchool = school;
				this.theTeam = team;
				
				//URGENT: IMPLEMENT THIS
				//LEFTOFF
				
		
				Transform parent = ParentOfBuildingSwitch.transform;
		
				//REMOVE ALL PrefabSwitchContainer from Buildings
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
				
				
				//UIWidget topWidget= ParentOfBuildingSwitch.GetComponent<UIWidget>();
				Transform topTransform = ParentOfBuildingSwitch.transform;
				
				//LEFTOFF iterate over all buildings not just the ones in theSchool? or is this right? nevermind i think...
				//ADD BACK ALL PrefabSwitchContainer to Buildings
				for (int i=0; i<theSchool.Buildings.Count; i++) {
						GameObject building = NGUITools.AddChild (ParentOfBuildingSwitch, PrefabSwitchContainer);
			
						//LEFTOFF
						
						//ADD building to school container
						building.GetComponent<BuildingSelectControl> ().SetAttachedBuilding (theTeam, theSchool, i);
						UIWidget buildingWidget = building.GetComponent<UIWidget> ();
						
						buildingWidget.topAnchor.target = topTransform;
						buildingWidget.bottomAnchor.target = topTransform;
						buildingWidget.topAnchor.absolute = -30;
						buildingWidget.bottomAnchor.absolute = -60;
						
						//buildingWidget.height = 20;
						
						
						
						
						topTransform = building.transform;
				}
				
			
		}
}
