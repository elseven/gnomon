using UnityEngine;
using System.Collections;

public class ActionBarControl : MonoBehaviour
{


	
		
		public BackMode SelectedBackMode = BackMode.HOME;
	
		
		public GameObject HomePanel;
		public GameObject TeamsPanel;
		public GameObject MatchesPanel;
		public GameObject GraphPanel;
		public GameObject TopPanel;
		
		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
		public void Back ()
		{
				
				//FIXME: BACK NOT CALLED
				switch (SelectedBackMode) {
				case BackMode.HOME:
						//FIXME: BACK HOME NOT IMPLEMENTED
						break;
				case BackMode.TEAMS:
						//FIXME: BACK TEAMS NOT IMPLEMENTED
						break;
				case BackMode.MATCHES:
						//FIXME: BACK MATCHES NOT IMPLEMENTED
						break;
		
				}
		}
		
		
		//FIXME: SET BACK MODE NOT BEING CALLED
		public void SetBackMode (BackMode mode)
		{
		
				SelectedBackMode = mode;
				
				
				
		}
		
		
}
