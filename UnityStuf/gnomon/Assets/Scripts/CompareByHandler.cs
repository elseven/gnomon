using UnityEngine;
using System.Collections;

public class CompareByHandler : MonoBehaviour
{


	
		public string compareByMode = "School";
		public CompareBySchool cbsPanel;
		public CompareByCommunity cbcPanel;
		public static bool needRefresh = false;
	
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
								cbsPanel.Refresh ();
								break;
				
						case "Community":
								cbcPanel.Refresh ();
								break;
						}
						needRefresh = false;
				}
		}
		
		
		public void AddButton ()
		{
		
				switch (compareByMode) {
				case "School":
						cbsPanel.Spawn ();
						break;

				case "Community":
						cbcPanel.Spawn ();
						break;
				}
		
		
		}
		
		public void SetMode (string mode)
		{
				compareByMode = mode;
				switch (compareByMode) {
				case "School":
						cbsPanel.ResetPosition ();
						break;
			
				case "Community":
						cbcPanel.ResetPosition ();
						break;
				}
		}
		
		
		
		
		
		
		
		
		
		
}
