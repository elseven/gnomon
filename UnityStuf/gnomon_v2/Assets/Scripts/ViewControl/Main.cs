using UnityEngine;
using System.Collections;
using  System.Collections.Generic;
using Vectrosity;


/**
* Has a World.cs. Part of the view/control
*/
public class Main : MonoBehaviour
{

		[HideInInspector]
		public static bool
				teamTabNeedsActive = false;
		[HideInInspector]
		public static bool
				homeTabNeedsActive = false;
		[HideInInspector]
		public static bool
				matchTabNeedsActive = false;
	
	
		public static World world = new World ();
		
		public GameObject HomePanel;
		public GameObject TeamsPanel;
		public GameObject MatchesPanel;
		public GameObject GraphPanel;
		public GameObject TopPanel;
		public GameObject ActionPanel;
		public List<VectorLine> vectorLines = new List<VectorLine> ();
		public BackMode SelectedBackMode = BackMode.HOME;
		public MiniGraph SchoolMiniGraph;
		public MiniGraph BuildingMiniGraph;
		public MiniGraph RoomMiniGraph;
		public TeamControl teamControl;
		
		
		public UIScrollView TeamsScrollView;
		public UITable TeamsTable;
		

		
		// Use this for initialization
		void Start ()
		{
				
				Random.seed = 123;
				//teamControl = TeamsPanel.GetComponent<TeamControl> ();	
				teamControl.HideEditPanels ();
				teamControl.HideDetailPanels ();	
				//ActivateHome ();
				
				//world = new World ();
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (teamTabNeedsActive) {
						ActivateTeams ();
				} else if (homeTabNeedsActive) {
						ActivateHome ();
				} else if (matchTabNeedsActive) {
						ActivateMatches ();
				}
		}
		
		void Awake ()
		{
				ActivateHome ();
		}
		
		


		public void ClearVectorLines ()
		{
				for (int i=0; i<vectorLines.Count; i++) {
						VectorLine vl = vectorLines [i];
						VectorLine.Destroy (ref vl);
				}
				vectorLines.Clear ();
		}
		
		
		
		//FIXME: SET BACK MODE NOT BEING CALLED
		public void SetBackMode (BackMode mode)
		{
				SelectedBackMode = mode;	
		}
		
		
		
		
		
		public void InitMiniGraphs ()
		{
				SchoolMiniGraph.Init ();
				BuildingMiniGraph.Init ();
				RoomMiniGraph.Init ();
		}
		
		
		
		public void ActivateHome ()
		{
		
				ClearVectorLines ();
				DeactivateAllPanels ();
				InitMiniGraphs ();
				HomePanel.SetActive (true);
				TopPanel.SetActive (true);
				homeTabNeedsActive = false;
				

		
		}
	
	
	
		
		public void ActivateTeams ()
		{
				ClearVectorLines ();
				DeactivateAllPanels ();
				TopPanel.SetActive (true);
				
				StartCoroutine ("FixTeamsScroll");
		}
	
	
	
		//TODO: DO SOMETHING SIMILAR FOR EDIT SCHOOL PANEL
		IEnumerator FixTeamsScroll ()
		{
		
				//URGENT: NEED TO MAKE SURE TABLE STARTS OUT AT TOP AFTER ADDING ITEMS
				teamControl.RefreshGrid ();
				TeamsPanel.SetActive (true);
				yield return null;
				TeamsScrollView.ResetPosition ();
				yield return null;
				TeamsTable.Reposition ();
				teamControl.TeamGrid.Reposition ();
				teamTabNeedsActive = false;
				
				
				
		}
	
		public void ActivateMatches ()
		{
				ClearVectorLines ();
				DeactivateAllPanels ();
				MatchesPanel.SetActive (true);
				TopPanel.SetActive (true);
				matchTabNeedsActive = false;
		}
		
		public void ActivateGraph ()
		{
				ClearVectorLines ();
				DeactivateAllPanels ();
				GraphPanel.SetActive (true);
				ActionPanel.SetActive (true);
		}
	
		
		
	
	
	
	
	
	
		public void DeactivateAllPanels ()
		{
				HomePanel.SetActive (false);
				TeamsPanel.SetActive (false);
				MatchesPanel.SetActive (false);
				GraphPanel.SetActive (false);
				TopPanel.SetActive (false);
				ActionPanel.SetActive (false);
		}
		
		
		
		
}
