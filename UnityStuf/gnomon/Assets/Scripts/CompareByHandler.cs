using UnityEngine;
using System.Collections;

public class CompareByHandler : MonoBehaviour
{


	
		public string compareByMode = "School";
		public CompareBySchool cbsScript;
		public CompareByCommunity cbcScript;
		public static bool needRefresh = false;
		
		
		
		
		public GameObject cbsPanel;
		public GameObject cbcPanel;
		
		
		
		
		
	
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
				if (needRefresh) {
			
			
						switch (compareByMode) {
						case "School":
								cbsScript.Refresh ();
								break;
				
						case "Community":
								cbcScript.Refresh ();
								break;
						}
						needRefresh = false;
				}
		}
		
		
		public void AddButton ()
		{
		
				switch (compareByMode) {
				case "School":
						cbsScript.Spawn ();
						break;

				case "Community":
						cbcScript.Spawn ();
						break;
				}
		
		
		}
		
		public void SetMode (string mode)
		{
				compareByMode = mode;
				switch (compareByMode) {
				case "School":
						HideAllComparePanels ();
						cbsPanel.SetActive (true);		
						cbsScript.ResetPosition ();
						break;
			
				case "Community":
						HideAllComparePanels ();
						cbcPanel.SetActive (true);
						cbcScript.ResetPosition ();
						break;
				}
		}
		
		
		private void HideAllComparePanels ()
		{
		
				cbsPanel.SetActive (false);
				cbcPanel.SetActive (false);
		
		}
			
		
}
