using UnityEngine;
using System.Collections;

public class Printer : MonoBehaviour
{

		public UILabel debugger;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}
	
	
		public void Print (string msg)
		{
			
				debugger.text += "\n" + msg;
				
	
		}
}