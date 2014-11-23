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
		
				
				
				//LEFTOFF iterate over all buildings not just the ones in theSchool? or is this right? nevermind i think...
				//ADD BACK ALL PrefabSwitchContainer to Buildings
				for (int i=0; i<theSchool.Buildings.Count; i++) {
						GameObject building = NGUITools.AddChild (ParentOfBuildingSwitch, PrefabSwitchContainer);
			
						//LEFTOFF
			
						//ADD ALL BUILDINGS TO SCHOOL CONTAINER
						building.GetComponent<BuildingSelectControl> ().SetAttachedBuilding (theTeam, theSchool, i);
			
				}
				
			
		}
}
