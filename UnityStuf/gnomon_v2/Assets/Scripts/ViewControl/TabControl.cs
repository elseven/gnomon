using UnityEngine;
using System.Collections;

public class TabControl : MonoBehaviour
{

	
		public GameObject HomeTab;
		public GameObject TeamsTab;
		public GameObject MatchesTab;
	
	
		public GameObject HomePanel;
		public GameObject TeamsPanel;
		public GameObject MatchesPanel;
	
	





		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		void Awake ()
		{
				ActivateHome ();
		
		}
		
		
		
		public void ActivateHome ()
		{
				HomePanel.SetActive (true);
				TeamsPanel.SetActive (false);
				MatchesPanel.SetActive (false);
			
		}
		
		
		
		
		public void ActivateTeams ()
		{
				HomePanel.SetActive (false);
				TeamsPanel.SetActive (true);
				MatchesPanel.SetActive (false);
		
		}
		
		
		public void ActivateMatches ()
		{
				HomePanel.SetActive (false);
				TeamsPanel.SetActive (false);
				MatchesPanel.SetActive (true);
		}
		
		
		
		
		
}
