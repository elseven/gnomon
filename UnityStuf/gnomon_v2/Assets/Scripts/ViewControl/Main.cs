using UnityEngine;
using System.Collections;
using  System.Collections.Generic;
using Vectrosity;


/**
* Has a World.cs. Part of the view/control
*/
public class Main : MonoBehaviour
{


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
				
				
				
		}
	
		public void ActivateMatches ()
		{
				ClearVectorLines ();
				DeactivateAllPanels ();
				MatchesPanel.SetActive (true);
				TopPanel.SetActive (true);
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
