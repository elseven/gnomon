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
		private Team backupTeam;
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
	





		//TODO: SELECTING TEXT FIELD SHOULD SHOW CAB!


		/**
		* Attaches team and shows popup
		*/
		public void ShowOverflow (Team selected)
		{
		
				//actual reference
				this.backupTeam = selected;
				
				//deep copy
				this.SelectedTeam = new Team (selected);
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
				TeamEditTop.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
		
		public void CopyTeam ()
		{
				//URGENT: IMPL COPY TEAM
				HideOverflow ();
				InitValuesCopy ();
				TeamEditTop.SetActive (true);
				TeamEditPanelBody.SetActive (true);
		}
	
		public void DeleteTeam ()
		{
				//URGENT: IMPL DELETE TEAM
		
		}
		#endregion

	
		#region init stuff
		private void InitValues ()
		{
				TeamNameTextField.label.text = SelectedTeam.Name;
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
						label = "[ffffff0e]" + "(no schools/universities)";
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
								
					
						
						label += "      #" + r.Number;
				}
				
				
		
				return label;
		}
		
		

		
		#endregion
		
		
		
		public Team GetUpdatedTeam ()
		{
				return SelectedTeam;
		}
	
		public void DoneTeam ()
		{
		
				//URGENT: IMPL DONETEAM
				//TODO: UPDATE TEAM HERE!!!
				
				UpdateTeam ();
				
				InitValues ();
				HideEditPanels ();
		}
		public void CancelTeam ()
		{
				//URGENT: IMPL CANCELTEAM
				InitValues ();
				HideEditPanels ();
		}
		
		private void UpdateTeam ()
		{
		
				switch (ActiveTEM) {
				case TeamEditMode.EMPTY:
						Debug.LogError ("WHY IS THIS EMPTY???");
						break;
				case TeamEditMode.SCHOOL:
						SelectedTeam = schoolEditControl.GetUpdatedTeam ();
						break;
				case TeamEditMode.BUILDING:
				//URGENT: NOT IMPL
						Debug.LogError ("NOT IMPLEMENTED");
						break;
				case TeamEditMode.ROOM:
				//URGENT: NOT IMPL
						Debug.LogError ("NOT IMPLEMENTED");
						break;
				case TeamEditMode.NAME:
				//URGENT: NOT IMPL
						Debug.LogError ("NOT IMPLEMENTED");
						break;
				}
		}
	
	
	
		public void HideEditPanels ()
		{
				EditSchoolPanel.SetActive (false);
				EditBuildingPanel.SetActive (false);
				EditRoomPanel.SetActive (false);	
				TeamEditCAB.SetActive (false);
				//URGENT: POPUP SAVED/CANCELED
		}
		public void HideDetailPanels ()
		{
				TeamEditTop.SetActive (false);
				TeamEditPanelBody.SetActive (false);
			
		}
		
		public void BackToTeams ()
		{
				//TODO: ATTACH
				//TODO: IMPL
				HideEditPanels ();
				HideDetailPanels ();
		}
	
	
	
		public void ShowEditSchool ()
		{
				
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				ActiveTEM = TeamEditMode.SCHOOL;
				HideDetailPanels ();
				//TeamEditCAB.SetActive (true);
				//EditSchoolPanel.SetActive (true);
				schoolEditControl.Init (SelectedTeam);
				
				//TODO: IMPL
		}
		
		public void ShowEditBuilding ()
		{
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				ActiveTEM = TeamEditMode.BUILDING;
				TeamEditCAB.SetActive (true);
				EditBuildingPanel.SetActive (true);
				//TODO: IMPL
		}
	
		public void ShowEditRooms ()
		{
				MethodBase methodBase = MethodBase.GetCurrentMethod ();
				Debug.LogWarning (methodBase.Name);
				ActiveTEM = TeamEditMode.ROOM;
				TeamEditCAB.SetActive (true);
				EditRoomPanel.SetActive (true);
				//TODO: IMPL
		}
		
		
}
