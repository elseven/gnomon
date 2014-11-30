using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
public class TeamControl : MonoBehaviour
{
		

		public enum TeamEditMode
		{
				EMPTY,
				SCHOOL,
				BUILDING,
				ROOM,
				NAME
		}
		
		private TeamEditMode ActiveTEM = TeamEditMode.EMPTY;
		public GameObject TeamOverflowPopup;
		public UILabel PopupHeader;
		//private Team backupTeam;
		private Team selectedTeam;
		private Team copyTeam;


	
		
		public GameObject TeamEditTop;
		public GameObject TeamEditCAB;
	
		public GameObject TeamEditPanelBody;
		
		public UIGrid TeamGrid;
		public GameObject PrefabMiniTeam;
		
		public GameObject MiniTeamParent;
		
		public GameObject ScrollArea;
		
		public UIInput TeamNameTextField;
		public UILabel SchoolListLabel;
		public UILabel BuildingListLabel;
		public UILabel RoomListLabel;
		
		public GameObject EditSchoolPanel;
		public GameObject EditBuildingPanel;
		public GameObject EditRoomPanel;
		
		
		public SchoolEditControl schoolEditControl;
		public BuildingEditControl buildingEditControl;
		public RoomEditControl roomEditControl;
		public TeamNameEditControl teamNameEditControl;
	
		public GameObject ConfirmDeleteTeamPopup;
		public GameObject CancelOverlay;
		public GameObject ConfirmOverlay;
		public UILabel DeleteTeamLabel;
	
		public User theUser;
		public Team SelectedTeam {
				get {
						return selectedTeam;
				}
				set {
						selectedTeam = value;
				}
		}




		
		public void RefreshGrid ()
		{
				theUser = Main.world.TheUser;
				
				TeamGrid.cellWidth = ScrollArea.GetComponent<UIPanel> ().width - 20f;
				Transform parentT = MiniTeamParent.transform;
				
			
				while (parentT.childCount>0) {
						NGUITools.Destroy (parentT.GetChild (0).gameObject);
				}
				
				
				for (int i=0; i<theUser.myTeams.Count; i++) {
						GameObject mini = NGUITools.AddChild (MiniTeamParent, PrefabMiniTeam);
						mini.GetComponent<MiniTeamControl> ().SetAttachedTeam (theUser.myTeams [i]);
						UIWidget miniWidget = mini.GetComponent<UIWidget> ();

						miniWidget.leftAnchor.target = ScrollArea.transform;
						miniWidget.rightAnchor.target = ScrollArea.transform;	
				}
				TeamGrid.Reposition ();

		}
		
		
		
		
		#region POPUP STUFF and FOOTER
		/**
		* Attaches team and shows popup
		*/
		public void ShowOverflow (Team selected)
		{
		
				//actual reference
				//this.backupTeam = selected;
		
				//deep copy
				//this.SelectedTeam = new Team (selected);
		
				this.SelectedTeam = selected;
				PopupHeader.text = SelectedTeam.Name;
		
				TeamOverflowPopup.SetActive (true);
		
		}
	
		public void HideOverflow ()
		{
		
				TeamOverflowPopup.SetActive (false);
		}
	

	
		
		public void AddTeam ()
		{
				SelectedTeam = new Team ("<TEAM NAME>");
				EditTeam ();
				Main.ackMessage = "Team added";
				Main.showAck = true;
		
		
		}
		
		
		
		public void EditTeam ()
		{
				HideOverflow ();
				InitValues ();
				TeamEditTop.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
		
		public void CopyTeam ()
		{
				//CHECK: COPY TEAM WORKING?
				HideOverflow ();
				InitValuesCopy ();
				TeamEditTop.SetActive (true);
				TeamEditPanelBody.SetActive (true);
				Main.ackMessage = "Team coppied";
				Main.showAck = true;
		}
	
		public void DeleteTeam ()
		{
				
				HideOverflow ();
				ShowConfirmDeleteTeam ();
		
		}
		
		public void ShowConfirmDeleteTeam ()
		{
				DeleteTeamLabel.text = "Delete team \"" + SelectedTeam.Name + "\"?";
				ConfirmDeleteTeamPopup.SetActive (true);
		}
	
	
		
		public void ShowDeleteOverlay ()
		{
				ConfirmOverlay.SetActive (true);
		}
		public void ShowCancelOverlay ()
		{
				CancelOverlay.SetActive (true);
		}
		
		
		public void ConfirmDelete ()
		{
		
		
				ConfirmOverlay.SetActive (false);
				theUser.DeleteTeam (SelectedTeam);
				ConfirmDeleteTeamPopup.SetActive (false);		
				
				HideEditPanels ();
				HideDetailPanels ();
				Main.teamTabNeedsActive = true;
				Main.ackMessage = "Team deleted";
				Main.showAck = true;
				
				
		}
		
		public void CancelDelete ()
		{
				CancelOverlay.SetActive (false);
				ConfirmDeleteTeamPopup.SetActive (false);
				HideEditPanels ();
				HideDetailPanels ();
				Main.teamTabNeedsActive = true;
		}
		
		#endregion

	
		#region init stuff
		private void InitValues ()
		{
				TeamNameTextField.label.text = SelectedTeam.Name;
				TeamNameTextField.value = SelectedTeam.Name;
				TeamNameTextField.UpdateLabel ();
				SchoolListLabel.text = InitSchoolLabel ();
				BuildingListLabel.text = InitBuildingLabel ();
				RoomListLabel.text = InitRoomLabel ();
		}
		
		
		
		private void InitValuesCopy ()
		{
				copyTeam = new Team (SelectedTeam);
				copyTeam.Name = copyTeam.Name + "_COPY";
				SelectedTeam = copyTeam;
				InitValues ();
		
		}
	
		
		private string InitSchoolLabel ()
		{
				string label = "";
				for (int i=0; i<SelectedTeam.SchoolList.Count; i++) {
						School tempSchool = SelectedTeam.SchoolList [i];
						
						label += tempSchool.Name;
						
						//ADD NEW LINE FOR ALL BUT LAST LINE
						if (i < SelectedTeam.SchoolList.Count - 1) {
								label += "\n";
						}
				}
				
				if (label.Length == 0) {
						label = "[ffffff49]" + "(no schools/universities)";
				}
				
				return label;
		}
		
		private string InitBuildingLabel ()
		{
				string label = "";
				
				Dictionary<string,List<string>> buildingDict = new Dictionary<string, List<string>> ();
				List<string> keyList = new List<string> ();
				
				for (int i=0; i<SelectedTeam.BuildingList.Count; i++) {
						Building tempB = SelectedTeam.BuildingList [i];
						if (buildingDict.ContainsKey (tempB.SchoolName)) {
								buildingDict [tempB.SchoolName].Add (tempB.Name);
						} else {
								List<string> val = new List<string> ();
								val.Add (tempB.Name);
								buildingDict.Add (tempB.SchoolName, val);
								keyList.Add (tempB.SchoolName);
						}
						
				}
				
				//Sort buildings within school
				foreach (KeyValuePair<string,List<string>> kvp in buildingDict) {
						kvp.Value.Sort ();
				}
				keyList.Sort ();
				
				
				
				/*
				*
				* SCHOOL1 NAME
				*    BUILDING1 NAME
				*    BUILDING2 NAME
				*    BUILDING3 NAME
				*
				* SCHOOL2 NAME
				*    BUILDING1 NAME
				*/
				foreach (string key in keyList) {
						label += "\n" + key + "\n";
						List<string> values = buildingDict [key];
						foreach (string val in values) {
									
								label += "    " + val + "\n";
									
						}
						
				}
				
				if (label.Length == 0) {
						label = "[ffffff49]" + "(no buildings)";
				}
				
				return label;
		}
		
		private string InitRoomLabel ()
		{
		
			
				
				string label = "";
		
				SelectedTeam.RoomList.Sort ();
				
				string currentSchool = "";
				string currentBuilding = "";
				foreach (Room r in SelectedTeam.RoomList) {
						if (!currentSchool.Equals (r.SchoolName)) {
								currentSchool = r.SchoolName;
								currentBuilding = r.BuildingName;
								label += "\n" + currentSchool + "\n";
								label += "   " + currentBuilding + "\n";
						} else if (!currentBuilding.Equals (r.BuildingName)) {
								currentBuilding = r.BuildingName;
								label += "   " + currentBuilding + "\n";
						}
								
					
						
						label += "      #" + r.Number + "\n";
				}
				
				if (label.Length == 0) {
						label = "[ffffff49]" + "(no rooms)";
				}
				
		
				return label;
		}
		
		

		
		#endregion
		
		
		

	
		#region CAB and ACTION BAR
		public void DoneTeam ()
		{
	
				HandleDoneTeam ();
							
				InitValues ();
				HideEditPanels ();
				TeamEditTop.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		
		}
		public void CancelTeam ()
		{
				HandleCancelTeam ();
				InitValues ();
				HideEditPanels ();
				
				TeamEditTop.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
		
		public void BackToTeamsTab ()
		{
				
				
				
				Main.world.TheUser.UpdateTeam (SelectedTeam);
				HideEditPanels ();
				HideDetailPanels ();
				Main.teamTabNeedsActive = true;
		
		}
	
	
		#endregion
		
		
	
		private void HandleDoneTeam ()
		{
		
			
				switch (ActiveTEM) {
				case TeamEditMode.EMPTY:
						Debug.LogError ("WHY IS THIS EMPTY???");
						break;
				case TeamEditMode.SCHOOL:
						SelectedTeam = schoolEditControl.ImplDone ();
						break;
				case TeamEditMode.BUILDING:

						SelectedTeam = buildingEditControl.ImplDone ();
						break;
				case TeamEditMode.ROOM:
						SelectedTeam = roomEditControl.ImplDone ();
						break;
				case TeamEditMode.NAME:
				
						SelectedTeam = teamNameEditControl.ImplDone ();
						break;
				}
				
				
				
				Main.world.TheUser.UpdateTeam (SelectedTeam);			
				Main.ackMessage = "Team updated";
				Main.showAck = true;
				
		}
		
		private void HandleCancelTeam ()
		{
				switch (ActiveTEM) {
				case TeamEditMode.EMPTY:
						Debug.LogError ("WHY IS THIS EMPTY???");
						break;
				case TeamEditMode.SCHOOL:
						schoolEditControl.ImplCancel ();
						break;
				case TeamEditMode.BUILDING:
			
						buildingEditControl.ImplCancel ();
						break;
				case TeamEditMode.ROOM:
						roomEditControl.ImplCancel ();
						break;
				case TeamEditMode.NAME:
			
						teamNameEditControl.ImplCancel ();
						break;
				}
		
		
		
				//Main.world.TheUser.UpdateTeam (SelectedTeam);			
				Main.ackMessage = "No changes made";
				Main.showAck = true;
		}
	
	
		/**
		* Hide SWITCHES PANELS
		*/
		public void HideEditPanels ()
		{
				EditSchoolPanel.SetActive (false);
				EditBuildingPanel.SetActive (false);
				EditRoomPanel.SetActive (false);	
				TeamEditCAB.SetActive (false);
		}
		
		/**
		* Hide TEAM EDIT PANEL BODY & TOP
		*/
		public void HideDetailPanels ()
		{
				TeamEditTop.SetActive (false);
				TeamEditPanelBody.SetActive (false);
			
		}
		
	
	
	
		#region SHOW EDIT PANELS
		
		public void ShowEditName ()
		{
				ActiveTEM = TeamEditMode.NAME;
				TeamEditCAB.SetActive (true);
				TeamEditTop.SetActive (false);
				teamNameEditControl.Init (SelectedTeam);
		}
	
		public void ShowEditSchool ()
		{
				
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				ActiveTEM = TeamEditMode.SCHOOL;
				HideDetailPanels ();

				schoolEditControl.Init (SelectedTeam);

		}
		
		public void ShowEditBuilding ()
		{
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				ActiveTEM = TeamEditMode.BUILDING;
				HideDetailPanels ();
				
			
				buildingEditControl.Init (SelectedTeam);
				
		}
	
		public void ShowEditRooms ()
		{
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				ActiveTEM = TeamEditMode.ROOM;
				HideDetailPanels ();
		
		
				roomEditControl.Init (SelectedTeam);
		}
		#endregion
		
	
}
