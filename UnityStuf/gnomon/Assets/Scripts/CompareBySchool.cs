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
		
				
				//GameObject newContainer = GameObject.Instantiate (SimpleSchoolContainer) as GameObject;
				//newContainer.transform.parent = CompareSchoolPanel.transform;
				//newContainer.transform.localScale = new Vector3 (1f, 1f, 1f);
				GameObject newContainer = NGUITools.AddChild (gameObject, SimpleSchoolContainer);
				//newContainer.transform.localPosition = leftOff;
				//leftOff += new Vector3 (0f, -space, 0f);
			
				
				
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
				gameObject.GetComponent<UIGrid> ().Reposition ();
				gameObject.GetComponent<UIScrollView> ().InvalidateBounds ();
				gameObject.GetComponent<UIScrollView> ().UpdateScrollbars ();
				
		
				
				/*float yPos = 0f;
				yPos += space + height;
				
				//newContainer.transform.Translate (0f, yPos, 0f);
				leftOff.y -= yPos;
				
				*/
				
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
