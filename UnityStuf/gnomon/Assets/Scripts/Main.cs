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
		
		public UIPanel ComparePanel;
		public UIPanel HomePanel;
		public UIPanel SavedPanel;
		
		public GameObject GraphContent;
		
		
		public GameObject WeeklyTab;
		public GameObject MonthlyTab;
		
		public GameObject WeeklyOverlay;
		public GameObject MonthlyOverlay;
		
		
		
		
		//public string compName;
	
		public UILabel GraphTitle;
	
	
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
	
	
		
		
		
		public void ActivateGraphPage (string name)
		{
				if (name == null || name.Equals ("") || name.Equals ("World")) {
						name = "Title place holder";
				}
				
				
			
		
				
				
				GraphTitle.text = name;
				
				
				ComparePanel.alpha = 0f;
				HomePanel.alpha = 0f;
				SavedPanel.alpha = 0f;
				
				GraphContent.SetActive (true);
		
		}
		

		public void AddToComp ()
		{
				HideComp ();
				ActivateTabCompare ();
		
		
		}
	
	
	
		public void HideComp ()
		{
				ComparePanel.alpha = 1f;
				HomePanel.alpha = 1f;
				SavedPanel.alpha = 1f;
				GraphContent.SetActive (false);
		
		}
	
	
	
		
	
		public void SaveComp (string name)
		{
				//TODO: save name
				//TODO: FLASH SAVED!
			
		
		
		}
	
	
	
	
	
	
	
	
		private void ImplSetTab (bool isCompare, bool isHome, bool isSaved)
		{
		
		
				ComparePanel.alpha = 1f;
				HomePanel.alpha = 1f;
				SavedPanel.alpha = 1f;
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
