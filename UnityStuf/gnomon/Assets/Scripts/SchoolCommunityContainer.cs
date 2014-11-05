using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SchoolCommunityContainer : MonoBehaviour
{

		
	
	
		public List<GameObject> communityList = new List<GameObject> ();
		
		//the parent object for all of the community containers
		public GameObject allCommunities;
		
		
		public GameObject prefabCommunityContainer;
	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
		public void DeleteSchool ()
		{
		
			
		}
		
		
		public void DeleteCommunity ()
		{
			
		}
	
	
	
		public void AddCommunity ()
		{
				//Add community 
				GameObject newContainer = NGUITools.AddChild (allCommunities, prefabCommunityContainer);
				CompareByHandler.needRefresh = true;
				UpdateCommunityList ();
		}
	
		private void UpdateCommunityList ()
		{
				communityList.Clear ();
				foreach (Transform child in allCommunities.transform) {
						communityList.Add (child.gameObject);
				}
		
		}
	
	
	
}
