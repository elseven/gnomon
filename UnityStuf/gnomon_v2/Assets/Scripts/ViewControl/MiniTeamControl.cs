using UnityEngine;
using System.Collections;

public class MiniTeamControl : MonoBehaviour
{
		public Team AttachedTeam;
		public TeamControl Control;

		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
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
