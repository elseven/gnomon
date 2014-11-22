using UnityEngine;
using System.Collections;

public class BuildingSchoolEditControl : MonoBehaviour
{

		public GameObject PrefabSwitchContainer;
		public GameObject ParentOfBuildingSwitch;
		
		
		public UILabel schoolLabel;
		
		public School theSchool;
	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void RefreshSchoolContainer (School school)
		{
		
				this.theSchool = school;
				
				//URGENT: IMPLEMENT THIS
			
		}
}
