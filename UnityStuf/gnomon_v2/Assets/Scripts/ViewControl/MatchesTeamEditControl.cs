using UnityEngine;
using System.Collections;

public class MatchesTeamEditControl : MonoBehaviour
{

		//TODO: DRAG AND DROP
	
		public Match theMatch;
	
		public GameObject ParentOfMatches;
		public GameObject PrefabMatch;
		
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
				Transform parent = ParentOfMatches.transform;
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
		}
	
		public void ShowEditPanels ()
		{
				CABPanel.SetActive (true);
				ETPanel.SetActive (true);
		
		
		}		
}
