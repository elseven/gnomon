using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BuildingEditControl : MonoBehaviour
{

		public Building AttachedBuilding;
		
		
		public GameObject CABPanel;
		public GameObject EBPanel;
		public GameObject EBScrollArea;
	
		public GameObject PrefabSwitchContainer;
		public GameObject PrefabSchoolContainer;
		
		
		public GameObject ParentOfBuildingSwitch;
		public GameObject ParentOfSC;
	
	
		public UIScrollView EBScrollView;
		
		
		public UITable HeaderAndSchoolsTable;
		public UITable AllSchoolsTable;
		

	
		public Team theTeam;
		public School theSchool;
		public User theUser;
	
		private List<School> schools = new List<School> ();
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
	
	
	
	
		/*	public Team ImplDone ()
		{
				theTeam.SchoolList.Clear ();
				Transform parent = ParentSSC.transform;
				SchoolSelectControl[] sscs = parent.GetComponentsInChildren<SchoolSelectControl> ();
				foreach (SchoolSelectControl ssc in sscs) {		
						if (ssc.IsSelected) {
								theTeam.SchoolList.Add (ssc.AttachedSchool);
						}
				}
		
				return theTeam;
		}*/
	
	
		public void Init (Team team)
		{
		
				this.theTeam = team;
				
				StartCoroutine ("FixScroll");
		
		}
	
		IEnumerator FixScroll ()
		{
		
		
				RefreshMain ();
		
				ShowEditPanels ();
				yield return null;
				EBScrollView.ResetPosition ();
				yield return null;
				AllSchoolsTable.Reposition ();
				HeaderAndSchoolsTable.Reposition ();


				//FIXME: ITERATE OVER GRIDS
				//EBGrid.Reposition ();
		
		}
		
		
		public void RefreshMain ()
		{
		
				Main.world.schools.Sort ();
				
				schools = Main.world.schools;
				theUser = Main.world.TheUser;
				float width = EBScrollArea.GetComponent<UIPanel> ().width - 20f;
				
				
				
				Transform parent = ParentOfSC.transform;
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				for (int i=0; i<schools.Count; i++) {
						GameObject schoolContainer = NGUITools.AddChild (ParentOfSC, PrefabSchoolContainer);
						RefreshSchoolContainer (schoolContainer, schools [i]);
						
						UIWidget miniWidget = schoolContainer.GetComponent<UIWidget> ();
						miniWidget.leftAnchor.target = EBScrollArea.transform;
						miniWidget.rightAnchor.target = EBScrollArea.transform;
				}
		
			
				
		}
		
		private void RefreshSchoolContainer (GameObject schoolContainer, School school)
		{
				
				Transform parent = schoolContainer.transform;
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				for (int i=0; i<school.Buildings.Count; i++) {
						GameObject buildingContainer = NGUITools.AddChild (schoolContainer, PrefabSwitchContainer);
						buildingContainer.GetComponent<BuildingSelectControl> ().SetAttachedBuilding (theTeam, school, school.Buildings [i]);
			
				}
		}
		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				EBPanel.SetActive (true);
		
		
		}
}
