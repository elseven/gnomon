using UnityEngine;
using System.Collections;

public class AddSchool : MonoBehaviour
{



		public GameObject SimpleSchoolContainer;
		public GameObject CompareSchoolPanel;
		private Vector3 leftOff = new Vector3 (52f, 648f, 0f);
		public float space = 1f;
		public float height = 5f;
		
		
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
		
		public void Spawn ()
		{
		
				Debug.Log ("SPAWNING");
		
				
				//GameObject newContainer = GameObject.Instantiate (SimpleSchoolContainer) as GameObject;
				//newContainer.transform.parent = CompareSchoolPanel.transform;
				//newContainer.transform.localScale = new Vector3 (1f, 1f, 1f);
				GameObject newContainer = NGUITools.AddChild (CompareSchoolPanel, SimpleSchoolContainer);
				newContainer.transform.localPosition = leftOff;
				leftOff += new Vector3 (0f, -70f, 0f);
				
				CompareSchoolPanel.GetComponent<UIScrollView> ().InvalidateBounds ();
				CompareSchoolPanel.GetComponent<UIScrollView> ().UpdateScrollbars ();
				/*float yPos = 0f;
				yPos += space + height;
				
				//newContainer.transform.Translate (0f, yPos, 0f);
				leftOff.y -= yPos;
				
				*/
				
		}
}
