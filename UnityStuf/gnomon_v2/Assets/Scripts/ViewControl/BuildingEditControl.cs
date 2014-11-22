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
		
		//URGENT: POPULATE THIS!!!!
		public List<UIGrid> EBGrids = new List<UIGrid> ();
	
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
		
		
				UpdateGridList ();
				RefreshGrids ();
		
				ShowEditPanels ();
				yield return null;
				EBScrollView.ResetPosition ();
				yield return null;
				AllSchoolsTable.Reposition ();
				HeaderAndSchoolsTable.Reposition ();


				//FIXME: ITERATE OVER GRIDS
				//EBGrid.Reposition ();
		
		}
		
		public void UpdateGridList ()
		{
			
				
				UIGrid[] gridArray = AllSchoolsTable.GetComponentsInChildren<UIGrid> ();
				EBGrids.Clear ();
				foreach (UIGrid grid in gridArray) {
						EBGrids.Add (grid);
				}
				
		}
	
		public void RefreshGrids ()
		{
		
				
				schools = Main.world.schools;
				theUser = Main.world.TheUser;
				float width = EBScrollArea.GetComponent<UIPanel> ().width - 20f;
				foreach (UIGrid grid in EBGrids) {
		
						grid.cellWidth = width;
				}
				
				
				
				/*
				Transform parent = ParentSSC.transform;
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				for (int i=0; i<schools.Count; i++) {
						GameObject mini = NGUITools.AddChild (ParentSSC, PrefabSSC);
						mini.GetComponent<SchoolSelectControl> ().SetAttachedSchool (theTeam, schools [i]);
						UIWidget miniWidget = mini.GetComponent<UIWidget> ();
						miniWidget.leftAnchor.target = EBScrollArea.transform;
						miniWidget.rightAnchor.target = EBScrollArea.transform;
				}
		
				EBGrid.Reposition ();
				*/
		}
	
		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				EBPanel.SetActive (true);
		
		
		}
}
