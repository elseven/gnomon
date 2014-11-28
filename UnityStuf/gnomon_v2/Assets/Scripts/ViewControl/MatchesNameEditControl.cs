using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MatchesNameEditControl : MonoBehaviour
{

	
		public UISprite underline;
		public UIInput MatchNameField;
		public UILabel MatchNameLabel;
		public GameObject MatchCAB;
		public GameObject MatchEditHomeTop;
	
		public List<GameObject> NonTextLabels;
		public Match theMatch;
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
	
	
		public void Init (Match match)
		{
				this.theMatch = match;
				
		
				if (!MatchNameField.isSelected) {
			
						MatchNameField.label.text = theMatch.Name;
						MatchNameField.value = theMatch.Name;
						MatchNameField.isSelected = true;		
			
						MatchNameField.selectionStart = 0;
						MatchNameField.selectionEnd = theMatch.Name.Length;
				}
				
				MatchNameField.UpdateLabel ();
		
				underline.color = Tools.LIGHT_BLUE;
		
		
				foreach (GameObject go in NonTextLabels) {
						go.SetActive (false);
				}
		}
	
	
		public Match ImplDone ()
		{
				theMatch.Name = MatchNameLabel.text;
				OnDeselect ();
				return theMatch;
		
		}
	
		public void ImplCancel ()
		{
				
				MatchNameField.value = theMatch.Name;
				MatchNameField.UpdateLabel ();
				//MatchNameField.label.text = "asdffdas";
				OnDeselect ();
		}
	
	
		private void OnDeselect ()
		{
				underline.color = Color.white;
				underline.alpha = 100 / 255f;
				MatchCAB.SetActive (false);
				MatchEditHomeTop.SetActive (true);
		
				foreach (GameObject go in NonTextLabels) {
						go.SetActive (true);
				}
		}
}
