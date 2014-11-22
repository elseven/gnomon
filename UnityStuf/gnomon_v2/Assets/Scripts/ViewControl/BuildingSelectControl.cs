using UnityEngine;
using System.Collections;

public class BuildingSelectControl : MonoBehaviour
{

		public Building AttachedBuilding;
		public UILabel BuildingNameLabel;
		private bool isSelected = false;
		public GameObject OnSprite;
		public GameObject OffSprite;
	
		public GameObject OnLabel;
		public GameObject OffLabel;
	
		public Team theTeam;
		public School theSchool;
	
	
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
	
	
		public void SetAttachedBuilding (Team team, School s, Building b)
		{
				//this.school = new School (s);
				this.theTeam = team;
				this.theSchool = s;
				isSelected = theSchool.Buildings.Contains (this.AttachedBuilding);
				BuildingNameLabel.text = AttachedBuilding.Name;
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
