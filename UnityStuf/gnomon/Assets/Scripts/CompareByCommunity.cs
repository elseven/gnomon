using UnityEngine;
using System.Collections;

public class CompareByCommunity : MonoBehaviour
{

		public GameObject communityContainer;
		public UIGrid communityGrid;
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
		
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
				gameObject.GetComponent<UITable> ().Reposition ();
				communityGrid.Reposition ();
				gameObject.GetComponent<UIScrollView> ().InvalidateBounds ();
				gameObject.GetComponent<UIScrollView> ().UpdateScrollbars ();	
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
		}
		public void ResetPosition ()
		{
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
		}
	
}
