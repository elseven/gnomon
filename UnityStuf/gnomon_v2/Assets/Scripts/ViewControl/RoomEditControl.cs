using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class RoomEditControl : MonoBehaviour
{

		//TODO: ADD SCROLL COLLIDERS TO PREFABS FOR ROOMS
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
		
				
				theTeam.RoomList.Clear ();
				Transform parent = ParentOfSC.transform;
				RoomSelectControl[] rscs = parent.GetComponentsInChildren<RoomSelectControl> ();
		
				foreach (RoomSelectControl rsc in rscs) {	
						if (rsc.IsSelected) {
								theTeam.RoomList.Add (rsc.AttachedRoom);
						}
				}
				//theTeam.RoomList.Sort ();
				
				
				return theTeam;
		}
	
	
	
	
		public void Init (Team team)
		{
		
				this.theTeam = team;
		
				StartCoroutine ("FixScroll");
		
		}
	
		IEnumerator FixScroll ()
		{
		
				//yield return null;
				RefreshMain ();
				yield return null;
				//yield return new WaitForEndOfFrame ();
				
				ShowEditPanels ();
				
				ERScrollView.ResetPosition ();
				yield return null;
				AllSchoolsTable.Reposition ();
				
		
		}
	
		private void RefreshMain ()
		{
		
				Main.world.schools.Sort ();
		
				schools = Main.world.schools;
				theUser = Main.world.TheUser;
				//StartCoroutine ("ImplRefreshMain");
		
		
				Transform parent = ParentOfSC.transform;
		
				//REMOVE ALL School Containers from AllSchoolsTable
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				ParentOfSC.SetActive (true);
				PrefabSchoolContainer.SetActive (true);
		
				//ADD BACK ALL SchoolContainers
				for (int i=0; i<schools.Count; i++) {
						GameObject schoolContainer = NGUITools.AddChild (ParentOfSC, PrefabSchoolContainer);
						schoolContainer.SetActive (true);
			
			
						//schools [i].Buildings.Sort ();
						//ADD ALL BUILDINGS TO SCHOOL CONTAINER
						RoomSchoolEditControl rsec = schoolContainer.GetComponent<RoomSchoolEditControl> ();
			
						rsec.HeaderContainer.leftAnchor.target = ERScrollArea.transform;
						rsec.HeaderContainer.rightAnchor.target = ERScrollArea.transform;
						rsec.RefreshSchoolContainer (theTeam, schools [i]);
			
			
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
