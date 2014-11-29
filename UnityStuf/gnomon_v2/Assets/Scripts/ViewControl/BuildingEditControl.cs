using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
	
		public Team ImplDone ()
		{
				theTeam.BuildingList.Clear ();
				Transform parent = ParentOfSC.transform;
				//SchoolSelectControl[] sscs = parent.GetComponentsInChildren<SchoolSelectControl> ();
				BuildingSelectControl[] bscs = parent.GetComponentsInChildren<BuildingSelectControl> ();
				
				foreach (BuildingSelectControl bsc in bscs) {	
						if (bsc.IsSelected) {
								theTeam.BuildingList.Add (bsc.AttachedBuilding);
						}
				}
				theTeam.BuildingList.Sort ();
				return theTeam;
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
		
		}
		
		
		public void RefreshMain ()
		{
		
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				Main.world.schools.Sort ();
				
				schools = Main.world.schools;
				theUser = Main.world.TheUser;
				//float width = EBScrollArea.GetComponent<UIPanel> ().width - 20f;
				
				
				
				Transform parent = ParentOfSC.transform;
				
				//REMOVE ALL School Containers from AllSchoolsTable
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
	
	
				//ADD BACK ALL SchoolContainers
				for (int i=0; i<schools.Count; i++) {
						GameObject schoolContainer = NGUITools.AddChild (ParentOfSC, PrefabSchoolContainer);
		
						//ADD ALL BUILDINGS TO SCHOOL CONTAINER
						schoolContainer.GetComponent<BuildingSchoolEditControl> ().RefreshSchoolContainer (theTeam, schools [i]);
						
						
						UIWidget scWidget = schoolContainer.GetComponent<UIWidget> ();
						scWidget.leftAnchor.target = EBScrollArea.transform;
						scWidget.rightAnchor.target = EBScrollArea.transform;
						
						
						
				}
		
			
				
		}
		

		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				EBPanel.SetActive (true);
		
		
		}
}
