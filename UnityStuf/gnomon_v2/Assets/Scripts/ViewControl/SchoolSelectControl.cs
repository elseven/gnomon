using UnityEngine;
using System.Collections;

/**
* This goes on the school switch containers
*/
public class SchoolSelectControl : MonoBehaviour
{


		
		public School AttachedSchool;
		public UILabel SchoolNameLabel;
		private bool isSelected = false;
		public GameObject OnSprite;
		public GameObject OffSprite;
		
		public GameObject OnLabel;
		public GameObject OffLabel;
		
		public Team theTeam;

		public bool IsSelected {
				get {
						return isSelected;
				}
		}
		
		// Use this for initialization
		void Start ()
		{
				Refresh ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		
		void Awake ()
		{
				/*
				GameObject uiRoot = GameObject.FindGameObjectWithTag ("UIRoot");
				Main main = uiRoot.GetComponent<Main> ();
				teamControl = main.teamControl;*/
				
		}
		
		public void SetAttachedSchool (Team team, School s)
		{
				//this.school = new School (s);
				this.theTeam = team;
				this.AttachedSchool = s;
				isSelected = theTeam.SchoolList.Contains (this.AttachedSchool);
				SchoolNameLabel.text = AttachedSchool.Name;
				Refresh ();
		}
	
	
		public void Toggle ()
		{
				isSelected = !isSelected;
				Refresh ();
		}
	
		public void Refresh ()
		{
				OnSprite.SetActive (isSelected);
				OffSprite.SetActive (!isSelected);
				OnLabel.SetActive (isSelected);
		
				OffLabel.SetActive (!isSelected);
		}
	
	
	
	
	
	
}
