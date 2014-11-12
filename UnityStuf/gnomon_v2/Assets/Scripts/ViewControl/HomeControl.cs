using UnityEngine;
using System.Collections;

public class HomeControl : MonoBehaviour
{

		//FIXME: MINI GRAPHS! AND MAKE THE BUTTONS OPEN A GRAPHS PAGE.
		


		public GameObject SchoolOverlay;
		public GameObject BuildingOverlay;
		public GameObject RoomOverlay;
		
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
		
		
		}
	
	
	
		public void ViewSchoolGraph ()
		{
				StartCoroutine ("ActivateSchoolOverlay");
				
				//FIXME: NOT IMPL
				//DISPLAY GRAPH PAGE
		}
	
	
		public void ViewBuildingGraph ()
		{
				//FIXME: NOT IMPL
				//FIXME: NOT LINKED
		}
	
	
		public void ViewRoomGraph ()
		{
				//FIXME: NOT IMPL
				//FIXME: NOT LINKED
		}

		
	#region Coroutines
		
		IEnumerator ActivateSchoolOverlay ()
		{
				SchoolOverlay.SetActive (true);
				yield return new WaitForSeconds (.3f);
				SchoolOverlay.SetActive (true);
		}



#endregion
}

