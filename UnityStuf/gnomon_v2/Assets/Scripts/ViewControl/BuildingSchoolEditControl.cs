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
		
				
		
				this.theSchool = school;
				this.theTeam = team;
				

				schoolLabel.text = theSchool.Name;
				Transform parent = ParentOfBuildingSwitch.transform;
		
				//REMOVE ALL PrefabSwitchContainer from Buildings
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
				
				
				//UIWidget topWidget= ParentOfBuildingSwitch.GetComponent<UIWidget>();
				Transform topTransform = ParentOfBuildingSwitch.transform;
				
				//ADD BACK ALL PrefabSwitchContainer to Buildings
				for (int i=0; i<theSchool.Buildings.Count; i++) {
						GameObject building = NGUITools.AddChild (ParentOfBuildingSwitch, PrefabSwitchContainer);
									
						//ADD building to school container
						building.GetComponent<BuildingSelectControl> ().SetAttachedBuilding (theTeam, theSchool, i);
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
