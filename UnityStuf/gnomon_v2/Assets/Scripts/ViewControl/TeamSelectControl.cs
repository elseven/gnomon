using UnityEngine;
using System.Collections;

public class TeamSelectControl : MonoBehaviour
{
	
		public Team AttachedTeam;
		public UILabel TeamNameLabel;
		private bool isSelected = false;
		public GameObject OnSprite;
		public GameObject OffSprite;
	
		public GameObject OnLabel;
		public GameObject OffLabel;
	
	
		public Match theMatch;
		
	
		public bool IsSelected {
				get {
						return isSelected;
				}
		}
	
		// Use this for initialization
		void Start ()
		{
				Refresh ();
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
	
		public void SetAttachedTeam (Match match, Team team)
		{
		
				if (team == null) {
						Debug.LogError ("no team");
				}
		
		
				this.AttachedTeam = team;
				this.theMatch = match;
		
				isSelected = theMatch.TeamList.Contains (this.AttachedTeam);
				TeamNameLabel.text = this.AttachedTeam.Name;
		
				Refresh ();
		}
	
	
		public void Toggle ()
		{
				isSelected = !isSelected;
				Refresh ();
		}
	
		public void Refresh ()
		{
				OnSprite.SetActive (isSelected);
				OffSprite.SetActive (!isSelected);
				OnLabel.SetActive (isSelected);
		
				OffLabel.SetActive (!isSelected);
		}
	
}
