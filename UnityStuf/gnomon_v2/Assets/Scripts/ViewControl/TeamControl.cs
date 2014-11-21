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
		
		public UIGrid TeamGrid;
		public GameObject PrefabMiniTeam;
		
		public GameObject MiniTeamParent;
		
		public GameObject ScrollArea;
	
	
	
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
				
				
				//TODO: FIX THIS DELETE CHILDREN THING
				while (parentT.childCount>0) {
						NGUITools.Destroy (parentT.GetChild (0).gameObject);
				}
				
				
				for (int i=0; i<user.myTeams.Count; i++) {
						GameObject mini = NGUITools.AddChild (MiniTeamParent, PrefabMiniTeam);
						mini.GetComponent<MiniTeamControl> ().SetAttachedTeam (user.myTeams [i]);
						UIWidget miniWidget = mini.GetComponent<UIWidget> ();
						//miniWidget.transform.
						//Vector2 leftSide = new Vector2 (ScrollArea.GetComponent<UIWidget> ().transform);
						miniWidget.leftAnchor.target = ScrollArea.transform;
						miniWidget.rightAnchor.target = ScrollArea.transform;
						//miniWidget.anc
						//miniWidget.leftAnchor.SetHorizontal (leftSide, 5f);
						//TODO: ANCHOR SO THAT FITS IN GRID
				}
				
				//TeamGrid.Reposition ();
				
		
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
