using UnityEngine;
using System.Collections;

public class MatchControl : MonoBehaviour
{


		public enum MatchEditMode
		{
				EMPTY,
				NAME,
				TEAM
		}
	
		private MatchEditMode ActiveMEM = MatchEditMode.EMPTY;


		public GameObject MatchOverflowPopup;
		public UILabel PopupHeader;
		private Match selectedMatch;
		private Match copyMatch;
	
	
	
	
		public GameObject MatchEditTop;		
		public GameObject MatchEditCAB;
	
		public GameObject MatchEditPanelBody;
	
	
	
		public UITable MatchTable;
		public UIGrid MatchGrid;
		public GameObject PrefabMiniMatch;
	
		public GameObject MiniMatchParent;
	
		public GameObject ScrollArea;
		public UIScrollView ScrollView;
		
		public UILabel TeamListLabel;
		
		
		
		public UIInput MatchNameTextField;
		
	
		
		
		public MatchesNameEditControl matchesNameEditControl;
		public MatchesTeamEditControl matchesTeamEditControl;	
		
		public GameObject ConfirmDeleteMatchPopup;
		public GameObject CancelOverlay;
		public GameObject ConfirmOverlay;
		public UILabel DeleteMatchLabel;
	
		private User theUser;
		
		
	
		public Match SelectedMatch {
				get {
						return selectedMatch;
				}
				set {
						selectedMatch = value;
				}
		}
	
	
		#region MONO
		// Use this for initialization
		void Start ()
		{
				theUser = Main.world.TheUser;
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
	
		#endregion

		#region INIT
		void InitValues ()
		{
				
		
				
				
				MatchNameTextField.label.text = SelectedMatch.Name;
				MatchNameTextField.value = SelectedMatch.Name;
				MatchNameTextField.UpdateLabel ();
				TeamListLabel.text = InitTeamLabel ();
				
		}	
	
		string InitTeamLabel ()
		{
		
				SelectedMatch.TeamList.Sort ();
				string label = "";
				for (int i=0; i<SelectedMatch.TeamList.Count; i++) {
						//School tempSchool = SelectedTeam.SchoolList [i];
						Team tempTeam = SelectedMatch.TeamList [i];
						label += tempTeam.Name;
			
						//ADD NEW LINE FOR ALL BUT LAST LINE
						if (i < SelectedMatch.TeamList.Count - 1) {
								label += "\n";
						}
				}
		
				if (label.Length == 0) {
						label = "[ffffff49]" + "(no teams)";
				}
		
				return label;
			
			
		}
		void InitValuesCopy ()
		{
				throw new System.NotImplementedException ();
		}
	
		#endregion
	
		#region CAB and ACTIONBAR
		
		public void AddMatch ()
		{
				SelectedMatch = new Match ();
				EditMatch ();
		
		
		}
		public void DoneMatch ()
		{
				HandleDoneMatch ();
				
		
				InitValues ();
				HideEditPanels ();
				MatchEditTop.SetActive (true);
				MatchEditPanelBody.SetActive (true);
		
		}
		public void CancelMatch ()
		{
				//CHECK: CANCEL match NOT CHECKED
				HandleCancelMatch ();
				InitValues ();
				HideEditPanels ();
				MatchEditTop.SetActive (true);
				MatchEditPanelBody.SetActive (true);
		}
	
		public void BackToMatchTab ()
		{
		
				Main.world.TheUser.DeleteMatch (SelectedMatch);
				Main.world.TheUser.myMatches.Add (SelectedMatch);
		
				HideEditPanels ();
				HideDetailPanels ();
				Main.matchTabNeedsActive = true;
		
		}
		
		#endregion
		
		
		
		#region POPUP
		public void ShowOverflow (Match selected)
		{

				this.SelectedMatch = selected;
				PopupHeader.text = SelectedMatch.Name;
		
				MatchOverflowPopup.SetActive (true);
		
		}
		public void HideOverflow ()
		{
				MatchOverflowPopup.SetActive (false);
		}	
		
		
			
				

		public void EditMatch ()
		{
				HideOverflow ();
				InitValues ();
				MatchEditTop.SetActive (true);
				MatchEditPanelBody.SetActive (true);
		}

	
	
		public void CopyMatch ()
		{
				//CHECK: COPY match WORKING?
				HideOverflow ();
				InitValuesCopy ();
				MatchEditTop.SetActive (true);
				MatchEditPanelBody.SetActive (true);
		}
	
		public void DeleteMatch ()
		{
				HideOverflow ();
				ShowConfirmDeleteMatch ();
		
		}
		public void ShowConfirmDeleteMatch ()
		{
				DeleteMatchLabel.text = "Delete match \"" + SelectedMatch.Name + "\"?";
				ConfirmDeleteMatchPopup.SetActive (true);
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
				theUser.DeleteMatch (SelectedMatch);
				ConfirmDeleteMatchPopup.SetActive (false);		
		
				HideEditPanels ();
				HideDetailPanels ();
				Main.matchTabNeedsActive = true;
				Main.ackMessage = "Match deleted";
				Main.showAck = true;
		
		
		}
	
		public void CancelDelete ()
		{
				CancelOverlay.SetActive (false);
				ConfirmDeleteMatchPopup.SetActive (false);
				HideEditPanels ();
				HideDetailPanels ();
				Main.matchTabNeedsActive = true;
		}
		#endregion
		
		
		public void RefreshGrid ()
		{
				User user = Main.world.TheUser;
		
				MatchGrid.cellWidth = ScrollArea.GetComponent<UIPanel> ().width - 20f;
				Transform parentT = MiniMatchParent.transform;
		
		
				while (parentT.childCount>0) {
						NGUITools.Destroy (parentT.GetChild (0).gameObject);
				}
		
		
				for (int i=0; i<user.myMatches.Count; i++) {
						GameObject mini = NGUITools.AddChild (MiniMatchParent, PrefabMiniMatch);
						mini.GetComponent<MiniMatchControl> ().SetAttachedMatch (user.myMatches [i]);
						UIWidget miniWidget = mini.GetComponent<UIWidget> ();
			
						miniWidget.leftAnchor.target = ScrollArea.transform;
						miniWidget.rightAnchor.target = ScrollArea.transform;	
				}
				MatchGrid.Reposition ();
		

		}
	
		private void HandleDoneMatch ()
		{
		
		
				switch (ActiveMEM) {
				case MatchEditMode.EMPTY:
						Debug.LogError ("WHY IS THIS EMPTY???");
						break;
				case MatchEditMode.TEAM:
						SelectedMatch = matchesTeamEditControl.ImplDone ();
						break;
				case MatchEditMode.NAME:
						SelectedMatch = matchesNameEditControl.ImplDone ();
						break;
				}
				Main.world.TheUser.UpdateMatch (SelectedMatch);
				Main.ackMessage = "Match updated";
				Main.showAck = true;
		
		}
	
	
		private void HandleCancelMatch ()
		{
		
		
				switch (ActiveMEM) {
				case MatchEditMode.EMPTY:
						Debug.LogError ("WHY IS THIS EMPTY???");
						break;
				case MatchEditMode.TEAM:
						matchesTeamEditControl.ImplCancel ();
						break;
				case MatchEditMode.NAME:
						matchesNameEditControl.ImplCancel ();
						break;
				}
				
				
				//Main.world.TheUser.UpdateMatch (SelectedMatch);
				Main.ackMessage = "No changes made";
				Main.showAck = true;
		
		}
	
	
	
		#region SHOW/HIDE STUFF
	
		/**
		* Hide SWITCHES PANELS
		*/
		public void HideEditPanels ()
		{
				matchesTeamEditControl.ETPanel.SetActive (false);
				MatchEditCAB.SetActive (false);
		}
	
		/**
		* Hide match EDIT PANEL BODY & TOP
		*/
		public void HideDetailPanels ()
		{
				MatchEditTop.SetActive (false);
				MatchEditPanelBody.SetActive (false);
		
		}
	
	
	
		public void ShowEditName ()
		{
				ActiveMEM = MatchEditMode.NAME;
				
				MatchEditCAB.SetActive (true);
				MatchEditTop.SetActive (false);
				matchesNameEditControl.Init (SelectedMatch);
		}
		public void ShowEditTeam ()
		{
		
				ActiveMEM = MatchEditMode.TEAM;
			
				HideDetailPanels ();
				matchesTeamEditControl.Init (SelectedMatch);
		
		}
		#endregion	
	
}
