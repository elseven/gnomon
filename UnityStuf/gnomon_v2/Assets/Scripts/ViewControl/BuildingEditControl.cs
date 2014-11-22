using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BuildingEditControl : MonoBehaviour
{

		public GameObject CABPanel;
		public GameObject ESPanel;
		public GameObject ESScrollArea;
	
		public GameObject PrefabSSC;
		public GameObject ParentSSC;
	
		public UIScrollView ESScrollView;
		public UITable ESTable;
		public UIGrid ESGrid;
	
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
	
	
		private void SetAttachedTeam (Team team)
		{
				this.theTeam = team;
		}
	
	
	
	
		public Team ImplDone ()
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
		}
	
	
		public void Init (Team team)
		{
				SetAttachedTeam (team);
				StartCoroutine ("FixScroll");
		
		}
	
		IEnumerator FixScroll ()
		{
				RefreshGrid ();
		
				ShowEditPanels ();
				yield return null;
				ESScrollView.ResetPosition ();
				yield return null;
				ESTable.Reposition ();
				ESGrid.Reposition ();
		
		}
	
		public void RefreshGrid ()
		{
		
				schools = Main.world.schools;
				theUser = Main.world.TheUser;
		
				ESGrid.cellWidth = ESScrollArea.GetComponent<UIPanel> ().width - 20f;
		
				Transform parent = ParentSSC.transform;
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
				for (int i=0; i<schools.Count; i++) {
						GameObject mini = NGUITools.AddChild (ParentSSC, PrefabSSC);
						mini.GetComponent<SchoolSelectControl> ().SetAttachedSchool (theTeam, schools [i]);
						UIWidget miniWidget = mini.GetComponent<UIWidget> ();
						miniWidget.leftAnchor.target = ESScrollArea.transform;
						miniWidget.rightAnchor.target = ESScrollArea.transform;
				}
		
				ESGrid.Reposition ();
		}
	
		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				ESPanel.SetActive (true);
		
		
		}
}
