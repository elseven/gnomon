using UnityEngine;
using System.Collections;

public class MatchesTeamEditControl : MonoBehaviour
{

		//TODO: DRAG AND DROP
	
		public Match theMatch;
	
		public GameObject ParentOfTeams;
		public GameObject PrefabTeam;
		
		public GameObject CABPanel;
		public GameObject ETPanel;
		public GameObject ETScrollArea;
		
		
		
		public UIGrid ETGrid;
		public UIScrollView ETScrollView;
		public UITable ETTable;
		
		
		public User theUser;
		private void SetAttachedMatch (Match match)
		{
				this.theMatch = match;
		}
	
	
	
	
		public Match ImplDone ()
		{
				theMatch.TeamList.Clear ();
				Transform parent = ParentOfTeams.transform;
				TeamSelectControl[] tscs = parent.GetComponentsInChildren<TeamSelectControl> ();
				foreach (TeamSelectControl tsc in tscs) {		
						if (tsc.IsSelected) {
								theMatch.TeamList.Add (tsc.AttachedTeam);
						}
				}
		
				return theMatch;
		}
	
	
		public void Init (Match match)
		{
				SetAttachedMatch (match);
				match.TeamList.Sort ();
				StartCoroutine ("FixScroll");
		
		}
	
		IEnumerator FixScroll ()
		{
				RefreshGrid ();
		
				ShowEditPanels ();
				yield return null;
				ETScrollView.ResetPosition ();
				yield return null;
				ETTable.Reposition ();
				ETGrid.Reposition ();
		
		}
	
		public void RefreshGrid ()
		{
				//TODO: REFRESH GRID

	
		
				theUser = Main.world.TheUser;
		
				
				float width = ETScrollArea.GetComponent<UIPanel> ().width - 20f;
		
		
		
				Transform parent = ParentOfTeams.transform;
		
				//REMOVE ALL Team Switch things
				while (parent.childCount>0) {
						NGUITools.Destroy (parent.GetChild (0).gameObject);
				}
		
		
				//ADD BACK ALL Team switch things
				for (int i=0; i<theUser.myTeams.Count; i++) {
						GameObject teamSwitch = NGUITools.AddChild (ParentOfTeams, PrefabTeam);
			
						//ADD ALL BUILDINGS TO SCHOOL CONTAINER
						teamSwitch.GetComponent<TeamSelectControl> ().SetAttachedTeam (theMatch, theUser.myTeams [i]);
			
			
						UIWidget miniWidget = teamSwitch.GetComponent<UIWidget> ();
						miniWidget.leftAnchor.target = ETScrollArea.transform;
						miniWidget.rightAnchor.target = ETScrollArea.transform;
			
			
			
				}
						
	
		}
	
		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				ETPanel.SetActive (true);
		
		
		}		
}
