using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TeamControl : MonoBehaviour
{


		public GameObject TeamOverflowPopup;
		public UILabel PopupHeader;
		private Team selectedTeam;
	
		
		public GameObject TeamEditTopPanel;
		public GameObject TeamEditPanelBody;
		
		
		public GameObject PrefabMiniTeam;
		
		public GameObject MiniTeamParent;
		
		
	
	
	
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
				
				TeamOverflowPopup.SetActive (true);
	
		}
	
	
	
		public void HideOverflow ()
		{
				
				
				TeamOverflowPopup.SetActive (false);
		}
		
		
		
		
		
		public void RefreshGrid ()
		{
				User user = Main.world.TheUser;
				
		
		}
		
		
		
		
		#region POPUP STUFF
		
		public void EditTeam ()
		{
				//URGENT: IMPL EDIT TEAM
				HideOverflow ();
				TeamEditTopPanel.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
		
		public void CopyTeam ()
		{
				//URGENT: IMPL COPY TEAM
		}
		
		public void DeleteTeam ()
		{
				//URGENT: IMPL DELETE TEAM
		
		}
		#endregion

	
		
				
	
}
