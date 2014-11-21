﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TeamControl : MonoBehaviour
{


		public GameObject TeamOverflowPopup;
		public UILabel PopupHeader;
		private Team selectedTeam;
	
		
		public GameObject TeamEditTopPanel;
		public GameObject TeamEditPanelBody;
		
		public UIGrid TeamGrid;
		public GameObject PrefabMiniTeam;
		
		public GameObject MiniTeamParent;
		
		public GameObject ScrollArea;
		
		public UIInput TeamNameTextField;
		public UILabel SchoolListLabel;
		public UILabel BuildingListLabel;
		public UILabel RoomListLabel;
	
	
	
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
				
				TeamGrid.cellWidth = ScrollArea.GetComponent<UIPanel> ().width - 20f;
				Transform parentT = MiniTeamParent.transform;
				
			
				while (parentT.childCount>0) {
						NGUITools.Destroy (parentT.GetChild (0).gameObject);
				}
				
				
				for (int i=0; i<user.myTeams.Count; i++) {
						GameObject mini = NGUITools.AddChild (MiniTeamParent, PrefabMiniTeam);
						mini.GetComponent<MiniTeamControl> ().SetAttachedTeam (user.myTeams [i]);
						UIWidget miniWidget = mini.GetComponent<UIWidget> ();

						miniWidget.leftAnchor.target = ScrollArea.transform;
						miniWidget.rightAnchor.target = ScrollArea.transform;

						
				}
				
				//TeamGrid.Reposition ();
				
		
		}
		
		
		
		
		#region POPUP STUFF
		
		public void EditTeam ()
		{
				//URGENT: IMPL EDIT TEAM
				HideOverflow ();
				InitValues ();
				TeamEditTopPanel.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
		
		public void CopyTeam ()
		{
				//URGENT: IMPL COPY TEAM
				HideOverflow ();
				InitValuesCopy ();
				TeamEditTopPanel.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
	
		public void DeleteTeam ()
		{
				//URGENT: IMPL DELETE TEAM
		
		}
		#endregion

	
	
		private void InitValues ()
		{
				//TODO: INIT VALUES
		}
		
		private void InitValuesCopy ()
		{
				//TODO: INIT VALUES WITH NAME CHANGED TO "NAME_COPY"			
		}
		
				
	
}
