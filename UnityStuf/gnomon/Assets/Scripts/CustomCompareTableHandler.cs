using UnityEngine;
using System.Collections;

public class CustomCompareTableHandler : MonoBehaviour
{

		public static bool needsRefresh = false;


		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		void LateUpdate ()
		{
		
				if (needsRefresh) {
						Refresh ();
						needsRefresh = false;
				}
		
		}
		
		public void Refresh ()
		{
				gameObject.GetComponent<UIGrid> ().Reposition ();
	
				gameObject.GetComponent<UIScrollView> ().InvalidateBounds ();
				gameObject.GetComponent<UIScrollView> ().UpdateScrollbars ();	
				gameObject.GetComponent<UIScrollView> ().ResetPosition ();
		}
}
