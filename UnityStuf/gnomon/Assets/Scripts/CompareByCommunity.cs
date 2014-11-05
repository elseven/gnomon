using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompareByCommunity : MonoBehaviour
{

		public GameObject communityContainer;
		public UIGrid communityGrid;
		public UITable[] communityTables;
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
				
				communityGrid = gameObject.GetComponentInChildren<UIGrid> ();
				communityTables = gameObject.GetComponentsInChildren<UITable> ();
		
		}
	
	
		public void Spawn ()
		{
		
				Debug.Log ("SPAWNING community");

				GameObject newContainer = NGUITools.AddChild (gameObject, communityContainer);
		
		
	
				Refresh ();
			
		
		}
	
	
		public void Refresh ()
		{
				communityGrid = gameObject.GetComponentInChildren<UIGrid> ();
				communityTables = gameObject.GetComponentsInChildren<UITable> ();
		
		
				communityGrid.Reposition ();
				foreach (UITable communityTable in communityTables) {
						communityTable.Reposition ();
				}
				
				//GameObject allCom = GameObject.FindGameObjectsWithTag ("AllCommunities");
				
				
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
				
				//communityGrid.Reposition ();
				//communityTable.Reposition ();
				gameObject.GetComponent<UITable> ().Reposition ();
				gameObject.GetComponent<UIScrollView> ().InvalidateBounds ();
				gameObject.GetComponent<UIScrollView> ().UpdateScrollbars ();	
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
		}
		public void ResetPosition ()
		{
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
		}
	
}
