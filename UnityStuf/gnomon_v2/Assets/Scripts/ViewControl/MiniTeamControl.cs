using UnityEngine;
using System.Collections;

public class MiniTeamControl : MonoBehaviour
{
		public Team AttachedTeam;
		
		public UILabel TeamNameLabel;
		public UILabel Line1Label;
		public UILabel Line2Label;
		public UILabel Line3Label;
		private TeamControl teamControl;
		
		public GameObject Overlay;
		public Main main;
		public GraphControl graphControl;
		
		
	
		// Use this for initialization
		void Start ()
		{
		
				GameObject teamGO = GameObject.FindGameObjectWithTag ("TeamsPanel");
				teamControl = teamGO.GetComponent<TeamControl> ();
				GameObject rootGO = GameObject.FindGameObjectWithTag ("UIRoot");
				main = rootGO.GetComponent<Main> ();
				graphControl = main.GraphPanel.GetComponent<GraphControl> ();
				
				
				if (AttachedTeam == null) {
						Debug.LogError ("why is this null??");
						AttachedTeam = new Team ();
				}
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void SetAttachedTeam (Team team)
		{
				this.AttachedTeam = team;
				ResetValues ();
				
		}
		
		public void ResetValues ()
		{
				TeamNameLabel.text = AttachedTeam.Name;
				if (AttachedTeam.GetLineCount () == 0) {
						Line1Label.text = "(team is empty)";
						Line2Label.text = "";
						Line3Label.text = "";
				} else if (AttachedTeam.GetLineCount () > 3) {
						Line1Label.text = AttachedTeam.GetLineAt (0);
						Line2Label.text = AttachedTeam.GetLineAt (1);
						Line3Label.text = AttachedTeam.GetLineAt (2) + "  . . . ";
				} else {
						Line1Label.text = AttachedTeam.GetLineAt (0);
						Line2Label.text = AttachedTeam.GetLineAt (1);
						Line3Label.text = AttachedTeam.GetLineAt (2);
				}
		
			
		}
	
	
	
		//ON PRESS
		public void ShowOverlay ()
		{
				Overlay.SetActive (true);
		}
		
		//ON RELEASE
		public void ShowTeamGraph ()
		{
				//URGENT: ACTUALLY SHOW TEAM
				Overlay.SetActive (false);
				string title = AttachedTeam.GenerateGraphTitle ();
				
				
				graphControl.ClearList ();
				graphControl.AddToPointsList (title, AttachedTeam.GetEnergyPointsRange (0, 30));
				main.ClearVectorLines ();
				main.SetBackMode (BackMode.TEAMS);
				graphControl.ShowGraphPanel ();
		
		}
	
		public void ShowOverflowPopup ()
		{
				teamControl.ShowOverflow (AttachedTeam);
		}
}
