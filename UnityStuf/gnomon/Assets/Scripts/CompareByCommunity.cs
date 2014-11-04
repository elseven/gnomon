using UnityEngine;
using System.Collections;

public class CompareByCommunity : MonoBehaviour
{

		public GameObject communityContainer;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
		public void Spawn ()
		{
		
				Debug.Log ("SPAWNING community");
		
		
				//GameObject newContainer = GameObject.Instantiate (SimpleSchoolContainer) as GameObject;
				//newContainer.transform.parent = CompareSchoolPanel.transform;
				//newContainer.transform.localScale = new Vector3 (1f, 1f, 1f);
				GameObject newContainer = NGUITools.AddChild (gameObject, communityContainer);
				//newContainer.transform.localPosition = leftOff;
				//leftOff += new Vector3 (0f, -space, 0f);
		
		
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
				gameObject.GetComponent<UITable> ().Reposition ();
				gameObject.GetComponent<UIScrollView> ().InvalidateBounds ();
				gameObject.GetComponent<UIScrollView> ().UpdateScrollbars ();
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
				/*float yPos = 0f;
				yPos += space + height;
				
				//newContainer.transform.Translate (0f, yPos, 0f);
				leftOff.y -= yPos;
				
				*/
		
		}
	
	
		public void Refresh ()
		{
		
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
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
