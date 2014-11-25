using UnityEngine;
using System.Collections;

public class ActionBarControl : MonoBehaviour
{


	
		
		
	
		public Main main;

		
		
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
				
				main.ClearVectorLines ();
				switch (main.SelectedBackMode) {
				case BackMode.HOME:
						main.ActivateHome ();
						break;
				case BackMode.TEAMS:
						main.ActivateTeams ();
						break;
				case BackMode.MATCHES:
						main.ActivateMatches ();
						break;
				}
		}
		
		

		
		
}
