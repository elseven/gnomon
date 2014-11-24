using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class RoomEditControl : MonoBehaviour
{

	
		public Room AttachedRoom;
	
	
		public GameObject CABPanel;
		public GameObject ERPanel;
		public GameObject ERScrollArea;
	
	
		public GameObject PrefabSchoolContainer;

		public GameObject ParentOfSC;
	
	
		public UIScrollView ERScrollView;
	
	
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
		
				/*
				theTeam.BuildingList.Clear ();
				Transform parent = ParentOfSC.transform;
				BuildingSelectControl[] bscs = parent.GetComponentsInChildren<BuildingSelectControl> ();
		
				foreach (BuildingSelectControl bsc in bscs) {	
						if (bsc.IsSelected) {
								theTeam.BuildingList.Add (bsc.AttachedBuilding);
						}
				}
				theTeam.BuildingList.Sort ();*/
				
				
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
				ERScrollView.ResetPosition ();
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
				//StartCoroutine ("ImplRefreshMain");
				float width = ERScrollArea.GetComponent<UIPanel> ().width - 20f;
		
		
		
				Transform parent = ParentOfSC.transform;
		
				//REMOVE ALL School Containers from AllSchoolsTable
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				//yield return null;
				//ADD BACK ALL SchoolContainers
				for (int i=0; i<schools.Count; i++) {
						GameObject schoolContainer = NGUITools.AddChild (ParentOfSC, PrefabSchoolContainer);
			
			
						schools [i].Buildings.Sort ();
						//ADD ALL BUILDINGS TO SCHOOL CONTAINER
						schoolContainer.GetComponent<RoomSchoolEditControl> ().RefreshSchoolContainer (theTeam, schools [i]);
			
			
						UIWidget scWidget = schoolContainer.GetComponent<UIWidget> ();
						scWidget.leftAnchor.target = ERScrollArea.transform;
						scWidget.rightAnchor.target = ERScrollArea.transform;
			
			
				}
		}
	
	
		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				ERPanel.SetActive (true);
		
		
		}
		
		

	
}
