﻿using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
	
		public void RunDelete ()
		{
				GameObject.Destroy (this.gameObject);
				CompareBySchool.needRefresh = true;
				
		}
	
	
	
	
}
