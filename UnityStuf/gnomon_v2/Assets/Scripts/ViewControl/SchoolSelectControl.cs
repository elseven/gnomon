using UnityEngine;
using System.Collections;

public class SchoolSelectControl : MonoBehaviour
{


		
		private School school;
		[HideInInspector]
		public bool
				isSelected = false;
		public GameObject OnSprite;
		public GameObject OffSprite;
		
		public GameObject OnLabel;
		public GameObject OffLabel;
		
		private TeamControl teamControl;
		
		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		
		void Awake ()
		{
				GameObject teamGO = GameObject.FindGameObjectWithTag ("TeamsPanel");
				teamControl = teamGO.GetComponent<TeamControl> ();
		}
		
		public void AttachSchool (School s)
		{
				//this.school = new School (s);
				this.school = s;
				isSelected = teamControl.SelectedTeam.SchoolList.Contains (this.school);
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
				OnLabel.SetActive (isSelected);
		
				OffLabel.SetActive (!isSelected);
		}
	
	
	
	
	
	
}
