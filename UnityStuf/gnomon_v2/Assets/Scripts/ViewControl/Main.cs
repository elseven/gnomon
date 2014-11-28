using UnityEngine;
using System.Collections;
using  System.Collections.Generic;
using Vectrosity;



/**
* Has a World.cs. Part of the view/control
*/
public class Main : MonoBehaviour
{
		//FIXME: AUTO FILL STRING NAME ON ADD MATCH IS PREVIOUSLY EDITED
		//CHECK: EVERYTHING TO DO WITH TEAM/MATCH NAME
		
		
		
		[HideInInspector]
		public static bool
				teamTabNeedsActive = false;
		[HideInInspector]
		public static bool
				homeTabNeedsActive = false;
		[HideInInspector]
		public static bool
				matchTabNeedsActive = false;
	
		[HideInInspector]
		public static bool
				showAck = false ;
				
		[HideInInspector]
		public static string
				ackMessage = "";
		public static World world;
		
		public GameObject HidePanel;
		
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
		public MatchControl matchControl;
		
		public Printer p;
		public UIScrollView TeamsScrollView;
		public UITable TeamsTable;
		
		
		public GameObject AckPanel;
		public UILabel AckLabel;
		public UIWidget AckContainer;
		

		#region MONO
		// Use this for initialization
		void Start ()
		{
		
				world = new World ();
				p = gameObject.GetComponent<Printer> ();
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
				
				
				if (showAck) {
				
						ActivateAck ();
				}
				
		}
		
		void Awake ()
		{
				ActivateHome ();
		}
		
		#endregion

		public void SetBackMode (BackMode mode)
		{
				SelectedBackMode = mode;
		}
		public void ClearVectorLines ()
		{
				for (int i=0; i<vectorLines.Count; i++) {
						VectorLine vl = vectorLines [i];
						VectorLine.Destroy (ref vl);
				}
				vectorLines.Clear ();
		}
		
		
		
		public void InitMiniGraphs ()
		{
				SchoolMiniGraph.Init ();
				BuildingMiniGraph.Init ();
				RoomMiniGraph.Init ();
		}
		
		
		
		#region Activate TABS	
		public void ActivateHome ()
		{
				StartCoroutine ("ImplActivateHome");
		}
		
		public void ActivateTeams ()
		{		
				StartCoroutine ("ImplActivateTeams");
		}
	
		public void ActivateMatches ()
		{
				StartCoroutine ("ImplActivateMatches");		
		}
		
		#endregion
		
		public void ActivateGraph ()
		{
				ClearVectorLines ();
				DeactivateAllPanels ();
				GraphPanel.SetActive (true);
				ActionPanel.SetActive (true);
		}
	
	
	
		private void ActivateAck ()
		{
				StartCoroutine ("ImplActivateAck");
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
		

		#region COROUTINES
		
		IEnumerator ImplActivateAck ()
		{
				AckLabel.text = ackMessage;
				yield return null;
				AckContainer.alpha = 0f;
				AckPanel.SetActive (true);
				yield return null;
				for (int i=0; i<30; i++) {
						AckContainer.alpha += 0.03f;
						yield return new WaitForSeconds (0.01f);
				}
			
				yield return new WaitForSeconds (0.7f);
				for (int j=0; j<30; j++) {
						AckContainer.alpha -= 0.03f;
						yield return new WaitForSeconds (0.01f);
				}
				AckPanel.SetActive (false);
				showAck = false;
			
			
		}
		
		IEnumerator ImplActivateTeams ()
		{
				
				ClearVectorLines ();
				DeactivateAllPanels ();
				TopPanel.SetActive (true);
				HidePanel.SetActive (true);
				teamControl.RefreshGrid ();
				TeamsPanel.SetActive (true);
				
				yield return null;
				TeamsScrollView.ResetPosition ();
				
				yield return null;
				TeamsTable.Reposition ();
				teamControl.TeamGrid.Reposition ();
				
				yield return null;
				HidePanel.SetActive (false);
				teamTabNeedsActive = false;
		
		
		
		}
		IEnumerator ImplActivateHome ()
		{
		
				HidePanel.SetActive (true);
				ClearVectorLines ();
				DeactivateAllPanels ();
				
				
				HomePanel.SetActive (true);
				TopPanel.SetActive (true);
				yield return null;
				InitMiniGraphs ();
				yield return null;
				HidePanel.SetActive (false);
				homeTabNeedsActive = false;
				
				
		}		
		
		IEnumerator ImplActivateMatches ()
		{
		
				ClearVectorLines ();
				DeactivateAllPanels ();
				TopPanel.SetActive (true);
				HidePanel.SetActive (true);
				matchControl.RefreshGrid ();
				//TeamsPanel.SetActive (true);
				MatchesPanel.SetActive (true);
				yield return null;
				//TeamsScrollView.ResetPosition ();
				matchControl.ScrollView.ResetPosition ();
				yield return null;
				matchControl.MatchTable.Reposition ();
				matchControl.MatchGrid.Reposition ();
		
				yield return null;
				HidePanel.SetActive (false);
				matchTabNeedsActive = false;
		
	
		}
		
		#endregion
	
	
}
