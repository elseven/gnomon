using UnityEngine;
using System.Collections;

public class TabControl : MonoBehaviour
{

	
		public GameObject HomeTab;
		public GameObject TeamsTab;
		public GameObject MatchesTab;
	
		public GameObject HomeSelector;
		public GameObject TeamsSelector;
		public GameObject MatchesSelector;


	




		// Use this for initialization
		void Start ()
		{
				ActivateHomeTab ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		void Awake ()
		{
				
		
		}
		
		
		
		
		
		public void ActivateHomeTab ()
		{
				DisableAllSelectors ();
				HomeSelector.SetActive (true);
		
		}
		
		
		
		
		public void ActivateTeamsTab ()
		{
				
				DisableAllSelectors ();
				TeamsSelector.SetActive (true);
		
		
		}
		
		
		public void ActivateMatchesTab ()
		{
		
				DisableAllSelectors ();
				MatchesSelector.SetActive (true);
				
		}
		
		
		
		
		private void DisableAllSelectors ()
		{
				HomeSelector.SetActive (false);
				TeamsSelector.SetActive (false);
				MatchesSelector.SetActive (false);
		
		}
		
		
}
