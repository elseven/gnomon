using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompareBySchool : MonoBehaviour
{

		

		public GameObject SimpleSchoolContainer;
		//public GameObject CompareSchoolPanel;
		private Vector3 leftOff = new Vector3 (0f, 590f, 0f);
		private float space = 70f;
	
		
		private List<string> schools;
		
		
		// Use this for initialization
		void Start ()
		{
			
		}
		void Awake ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}
		
		void LateUpdate ()
		{
				
		
		
		}
		
		public void Spawn ()
		{
		
				Debug.Log ("SPAWNING");
		
				
	
				GameObject newContainer = NGUITools.AddChild (gameObject, SimpleSchoolContainer);
		
				
				
		
				
				Refresh ();
				
		}
		
		
		public void Refresh ()
		{
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
				gameObject.GetComponent<UIGrid> ().Reposition ();
				gameObject.GetComponent<UIScrollView> ().InvalidateBounds ();
				gameObject.GetComponent<UIScrollView> ().UpdateScrollbars ();	
		}
		
		public void ResetPosition ()
		{
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
		}
}
