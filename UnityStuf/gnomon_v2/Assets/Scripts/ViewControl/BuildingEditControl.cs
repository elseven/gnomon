using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BuildingEditControl : MonoBehaviour
{

		public Building AttachedBuilding;
		
		
		public GameObject CABPanel;
		public GameObject EBPanel;
		public GameObject EBScrollArea;
	
		
		public GameObject PrefabSchoolContainer;
		
		
	
		public GameObject ParentOfSC;
	
	
		public UIScrollView EBScrollView;
		
		
		public UITable HeaderAndSchoolsTable;
		public UITable AllSchoolsTable;
		

	
		public Team theTeam;
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
				
				//REMOVE ALL SchoolAndAllBuildingsContainer
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				
	
				//ADD BACK ALL SchoolAndAllBuildingsContainer
				for (int i=0; i<schools.Count; i++) {
						GameObject schoolContainer = NGUITools.AddChild (ParentOfSC, PrefabSchoolContainer);
						
						//LEFTOFF
						//LEFTOFF
						//LEFTOFF
						//ADD ALL BUILDINGS TO SCHOOL CONTAINER
						schoolContainer.GetComponent<BuildingSchoolEditControl> ().RefreshSchoolContainer (schools [i]);

				}
		
			
				
		}
		

		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				EBPanel.SetActive (true);
		
		
		}
}
