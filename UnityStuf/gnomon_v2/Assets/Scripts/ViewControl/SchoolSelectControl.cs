using UnityEngine;
using System.Collections;

/**
* This goes on the school switch containers
*/
public class SchoolSelectControl : MonoBehaviour
{


		
		private School school;
		public UILabel SchoolNameLabel;
		private bool isSelected = false;
		public GameObject OnSprite;
		public GameObject OffSprite;
		
		public GameObject OnLabel;
		public GameObject OffLabel;
		
		private TeamControl teamControl;
		
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
				GameObject uiRoot = GameObject.FindGameObjectWithTag ("UIRoot");
				Main main = uiRoot.GetComponent<Main> ();
				teamControl = main.teamControl;
				
		}
		
		public void AttachSchool (School s)
		{
				//this.school = new School (s);
				this.school = s;
				isSelected = teamControl.SelectedTeam.SchoolList.Contains (this.school);
				SchoolNameLabel.text = school.Name;
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
