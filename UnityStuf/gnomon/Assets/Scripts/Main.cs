using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{


		public GameObject CompareTab;
		public GameObject HomeTab;
		public GameObject SavedTab;
		
		public GameObject CompareTabOverlay;
		public GameObject HomeTabOverlay;
		public GameObject SavedTabOverlay;
		
		
		public GameObject CompareContent;
		public GameObject HomeContent;
		public GameObject SavedContent;
	
	
	
		//public Mode currentMode = Mode.COMPARE;
		// Use this for initialization
		void Start ()
		{
				ActivateTabHome ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void ActivateTabCompare ()
		{
				CompareTabOverlay.SetActive (true);
				HomeTabOverlay.SetActive (false);
				SavedTabOverlay.SetActive (false);
		
				CompareContent.SetActive (true);
				HomeContent.SetActive (false);
				SavedContent.SetActive (false);
		}
		
		
		public void ActivateTabHome ()
		{
				CompareTabOverlay.SetActive (false);
				HomeTabOverlay.SetActive (true);
				SavedTabOverlay.SetActive (false);
				
				CompareContent.SetActive (false);
				HomeContent.SetActive (true);
				SavedContent.SetActive (false);
		}
	
	
		public void ActivateTabSaved ()
		{
				CompareTabOverlay.SetActive (false);
				HomeTabOverlay.SetActive (false);
				SavedTabOverlay.SetActive (true);
				
				CompareContent.SetActive (false);
				HomeContent.SetActive (false);
				SavedContent.SetActive (true);
	
		}
	
	
	
		
	
	
	
}
