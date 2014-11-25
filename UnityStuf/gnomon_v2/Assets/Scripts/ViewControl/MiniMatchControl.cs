using UnityEngine;
using System.Collections;

public class MiniMatchControl : MonoBehaviour
{
		//TODO: GIVE CLICK FUNCTIONALITY (MINI MATCH CONTAINER)
	
		public Match AttachedMatch;
	
		public UILabel MatchNameLabel;
		public UILabel Line1Label;
		public UILabel Line2Label;
		public UILabel Line3Label;
		private MatchControl matchControl;
	
		public GameObject Overlay;
		public Main main;
		public GraphControl graphControl;
	
	
	
		// Use this for initialization
		void Start ()
		{
		
				GameObject matchGO = GameObject.FindGameObjectWithTag ("MatchsPanel");
				matchControl = matchGO.GetComponent<MatchControl> ();
				GameObject rootGO = GameObject.FindGameObjectWithTag ("UIRoot");
				main = rootGO.GetComponent<Main> ();
				graphControl = main.GraphPanel.GetComponent<GraphControl> ();
		
		
				if (AttachedMatch == null) {
						Debug.LogError ("why is this null??");
						AttachedMatch = new Match ();
				}
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		public void SetAttachedMatch (Match match)
		{
				this.AttachedMatch = match;
				ResetValues ();
		
		}
	
		public void ResetValues ()
		{
				MatchNameLabel.text = AttachedMatch.Name;
				if (AttachedMatch.GetLineCount () == 0) {
						Line1Label.text = "(match is empty)";
						Line2Label.text = "";
						Line3Label.text = "";
				} else if (AttachedMatch.GetLineCount () > 3) {
						Line1Label.text = AttachedMatch.GetLineAt (0);
						Line2Label.text = AttachedMatch.GetLineAt (1);
						Line3Label.text = AttachedMatch.GetLineAt (2) + "  . . . ";
				} else {
						Line1Label.text = AttachedMatch.GetLineAt (0);
						Line2Label.text = AttachedMatch.GetLineAt (1);
						Line3Label.text = AttachedMatch.GetLineAt (2);
				}
		
		
		}
	
	
	
		//ON PRESS
		public void ShowOverlay ()
		{
				Overlay.SetActive (true);
		}
	
		//ON RELEASE
		public void ShowMatchGraph ()
		{
		
				Overlay.SetActive (false);
				string title = "";
				graphControl.ClearList ();
				foreach (Team t in AttachedMatch.TeamList) {
						Vector2[] points = t.GetEnergyPointsRange (0, 29);
						graphControl.AddToPointsList (t.Name, points);
				}
				
				main.ClearVectorLines ();
				main.SetBackMode (BackMode.MATCHES);
				graphControl.ShowGraphPanel ();
		
		}
	
		public void ShowOverflowPopup ()
		{
				matchControl.ShowOverflow (AttachedMatch);
		}
}
