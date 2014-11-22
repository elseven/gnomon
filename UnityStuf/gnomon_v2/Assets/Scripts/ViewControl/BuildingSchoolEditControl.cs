using UnityEngine;
using System.Collections;
using System.Reflection;
public class BuildingSchoolEditControl : MonoBehaviour
{

		public GameObject PrefabSwitchContainer;
		public GameObject ParentOfBuildingSwitch;
		
		
		public UILabel schoolLabel;
		
		public School theSchool;
	

		
		public void RefreshSchoolContainer (School school)
		{
		
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
		
				this.theSchool = school;
				
				//URGENT: IMPLEMENT THIS
				//LEFTOFF
				
				//REMOVE everything from parent of building
				//add back all buildings to parent of buildings but change anchor each time
			
		}
}
