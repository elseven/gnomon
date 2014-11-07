using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

		private Color resetColor = new Color (61 / 255f, 50 / 255f, 31 / 255f);
		private Color selectedColor = Color.Lerp (Color.white, Color.gray, 0.4f);
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
				ImplSetTab (true, false, false);
		}
		
		
		public void ActivateTabHome ()
		{
				/*
CompareTabOverlay.SetActive (false);
				HomeTabOverlay.SetActive (true);
				SavedTabOverlay.SetActive (false);
				
				CompareContent.SetActive (false);
				HomeContent.SetActive (true);
				SavedContent.SetActive (false);
*/
				
				ImplSetTab (false, true, false);
		
		}
	
	
		public void ActivateTabSaved ()
		{
				/*
				CompareTabOverlay.SetActive (false);
				HomeTabOverlay.SetActive (false);
				SavedTabOverlay.SetActive (true);
				
				CompareContent.SetActive (false);
				HomeContent.SetActive (false);
				SavedContent.SetActive (true);
	
*/

				ImplSetTab (false, false, true);
		}
	
	
	
		private void ImplSetTab (bool isCompare, bool isHome, bool isSaved)
		{
		
				UILabel compareLabel = CompareTab.GetComponentInChildren<UILabel> ();
				UILabel homeLabel = HomeTab.GetComponentInChildren<UILabel> ();
				UILabel savedLabel = SavedTab.GetComponentInChildren<UILabel> ();
		
				CompareTabOverlay.SetActive (isCompare);
				HomeTabOverlay.SetActive (isHome);
				SavedTabOverlay.SetActive (isSaved);
		
				CompareContent.SetActive (isCompare);
				HomeContent.SetActive (isHome);
				SavedContent.SetActive (isSaved);
				
				compareLabel.color = resetColor;
				homeLabel.color = resetColor;
				savedLabel.color = resetColor;
				
				if (isCompare) {
						compareLabel.color = selectedColor;
				} else if (isHome) {
						homeLabel.color = selectedColor;
				} else {
						savedLabel.color = selectedColor;
				}
				
	
		}
	
		
	
	
	
}
