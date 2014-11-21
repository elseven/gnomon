using UnityEngine;
using System.Collections;

public class MiniTeamControl : MonoBehaviour
{
		public Team AttachedTeam;
		public TeamControl Control;
		public UILabel TeamNameLabel;
		public UILabel Line1Label;
		public UILabel Line2Label;
		public UILabel Line3Label;
		// Use this for initialization
		void Start ()
		{
				if (AttachedTeam == null) {
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
						Line3Label.text = AttachedTeam.GetLineAt (2) + "  ... ";
				} else {
						Line1Label.text = AttachedTeam.GetLineAt (0);
						Line2Label.text = AttachedTeam.GetLineAt (1);
						Line3Label.text = AttachedTeam.GetLineAt (2);
				}
		
			
		}
	
	
		public void ShowTeamGraph ()
		{
				//URGENT: ACTUALLY SHOW TEAM
		}
	
		public void ShowOverflowPopup ()
		{
			
				Control.ShowOverflow (AttachedTeam);
			
		
	
	
		}
}
