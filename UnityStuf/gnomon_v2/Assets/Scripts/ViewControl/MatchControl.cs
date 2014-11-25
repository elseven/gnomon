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
	
		public UIGrid TeamGrid;
		public GameObject PrefabMiniMatch;
	
		public GameObject MiniMatchParent;
	
		public GameObject ScrollArea;
		
		
		
		//TODO: NOT DRAGGED
		public UIInput MatchNameTextField;
		
		
		public MatchesNameEditControl matchesNameEditControl;
		public MatchesTeamEditControl matchesTeamEditControl;	
		
	
		public Match SelectedMatch {
				get {
						return selectedMatch;
				}
				set {
						selectedMatch = value;
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

		void InitValues ()
		{
				throw new System.NotImplementedException ();
		}	
	
	
	
	
	
	
	
	
	
	
		public void DoneMatch ()
		{
		
				UpdateMatch ();
		
				InitValues ();
				HideEditPanels ();
				MatchEditTop.SetActive (true);
				MatchEditPanelBody.SetActive (true);
		
		}
		public void CancelMatch ()
		{
				//CHECK: CANCEL match NOT CHECKED
				matchesNameEditControl.ImplCancel ();
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
		public void ShowOverflow (Match selected)
		{

				this.SelectedMatch = selected;
				PopupHeader.text = SelectedMatch.Name;
		
				MatchOverflowPopup.SetActive (true);
		
		}
		void HideOverflow ()
		{
				throw new System.NotImplementedException ();
		}		
		void InitValuesCopy ()
		{
				throw new System.NotImplementedException ();
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
				/*URGENT: IMPL DELETE match WITH CONFIRM POPUP*/
		
		
		
		}

	
	
		private void UpdateMatch ()
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
		
		
		}
	
	
		/**
		* Hide SWITCHES PANELS
		*/
		public void HideEditPanels ()
		{
				//TODO: HIDE THE SWITCHES PANEL
				MatchEditCAB.SetActive (false);
				//URGENT: POPUP SAVED/CANCELED
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
				//TODO: FOR MATCHES
				//TeamEditCAB.SetActive (true);
				//TeamEditTop.SetActive (false);
				//teamNameEditControl.Init (SelectedTeam);
		}
		public void ShowEditTeam ()
		{
		
				ActiveMEM = MatchEditMode.TEAM;
				//TODO: FOR MATCHES
				//HideDetailPanels ();
				//schoolEditControl.Init (SelectedTeam);
		
		}
	
	
}
