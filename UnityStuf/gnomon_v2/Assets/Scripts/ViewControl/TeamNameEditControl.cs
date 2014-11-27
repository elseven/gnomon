using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TeamNameEditControl : MonoBehaviour
{


		public UISprite underline;
		public UIInput TeamNameField;
		public UILabel TeamNameLabel;
		public GameObject TeamCAB;
		public GameObject TeamEditHomeTop;
		
		public List<GameObject> NonTextLabels;
		public Team theTeam;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		
		
		public void Init (Team team)
		{
				this.theTeam = team;
				TeamNameField.label.text = theTeam.Name;
				TeamNameField.value = theTeam.Name;
				TeamNameField.isSelected = true;
				TeamNameField.selectionStart = 0;
				TeamNameField.selectionEnd = theTeam.Name.Length;
				TeamNameField.UpdateLabel ();
				//TeamNameLabel.text = theTeam.Name;
				
				underline.color = Tools.LIGHT_BLUE;
				
				
				foreach (GameObject go in NonTextLabels) {
						go.SetActive (false);
				}
		}
		
		
		public Team ImplDone ()
		{
				theTeam.Name = TeamNameLabel.text;
				OnDeselect ();
				return theTeam;
			
		}
		
		public void ImplCancel ()
		{
				//URGENT: THROWS EXCEPTION!
				//TeamNameLabel.text = theTeam.Name;
				TeamNameField.value = theTeam.Name;
				TeamNameField.UpdateLabel ();
				OnDeselect ();
		}
		
		
		private void OnDeselect ()
		{
				underline.color = Color.white;
				underline.alpha = 100 / 255f;
				TeamCAB.SetActive (false);
				TeamEditHomeTop.SetActive (true);
		
				foreach (GameObject go in NonTextLabels) {
						go.SetActive (true);
				}
		}
}
