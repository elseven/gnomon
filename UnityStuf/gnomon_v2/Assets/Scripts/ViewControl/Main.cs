using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{


		public static World world;
		// Use this for initialization
		void Start ()
		{
		
				Random.seed = 123;
				world = new World ();
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
