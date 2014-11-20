using UnityEngine;
using System.Collections;

public class TeamControl : MonoBehaviour
{


		public GameObject TeamOverflowPopup;
		public UILabel PopupHeader;
		private Team selectedTeam;
		

		public Team SelectedTeam {
				get {
						return selectedTeam;
				}
				set {
						selectedTeam = value;
				}
		}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
		public void ShowOverflow (Team selected)
		{
				this.SelectedTeam = selected;
				PopupHeader.text = SelectedTeam.Name;
				
	
		}
	
	
	
		public void HideOverflow ()
		{
				this.SelectedTeam = null;
				
		}
	
	
	
}
