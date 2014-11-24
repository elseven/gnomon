using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TeamNameEditControl : MonoBehaviour
{


		//QUESTION: HOW TO STOP USER FROM PRESSING SOMETHING ELSE WHILE EDITING NAME?
		public UISprite underline;
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
				TeamNameLabel.text = theTeam.Name;
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
