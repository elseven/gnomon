using UnityEngine;
using System.Collections;

public class HomeControl : MonoBehaviour
{


		//FIXME: CONSIDER MOVING TO MAIN INSTEAD? SINCE GRAPH PAGE WILL BE ACCESSABLE FROM ELSEWHERE?
		//FIXME: AND MAKE THE BUTTONS OPEN A GRAPHS PAGE.
		


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
				
				//FIXME: DISPLAY GRAPH PAGE FOR SCHOOL
				
		}
	
	
		public void ViewBuildingGraph ()
		{
				StartCoroutine ("ActivateBuildingOverlay");
				//FIXME: DISPLAY GRAPH PAGE FOR BUILDING
		}
	
	
		public void ViewRoomGraph ()
		{
				StartCoroutine ("ActivateRoomOverlay");
				//FIXME: NOT LINKED
				//FIXME: DISPLAY GRAPH PAGE FOR BUILDING
		
		}

		
	#region Coroutines
		
		IEnumerator ActivateSchoolOverlay ()
		{
				SchoolOverlay.SetActive (true);
				yield return new WaitForSeconds (.3f);
				SchoolOverlay.SetActive (false);	
		}
		
		IEnumerator ActivateBuildingOverlay ()
		{
				BuildingOverlay.SetActive (true);
				yield return new WaitForSeconds (.3f);
				BuildingOverlay.SetActive (false);	
		}
		
		
		IEnumerator ActivateRoomOverlay ()
		{
				RoomOverlay.SetActive (true);
				yield return new WaitForSeconds (.3f);
				RoomOverlay.SetActive (false);	
		}



#endregion
}

