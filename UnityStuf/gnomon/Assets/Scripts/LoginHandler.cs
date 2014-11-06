﻿using UnityEngine;
using System.Collections;

public class LoginHandler : MonoBehaviour
{


		private string correctEmail = "bob@uga.edu";
		private string correctPassword = "p@ssword1";
	
		public string email;
		public string password;
		
		public UILabel emailUI;
		public UILabel passwordUI;
	
	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
		public void Submit ()
		{
			
				Debug.Log ("Email = " + email);
				Debug.Log ("Password = " + password);
				
				/*
		emailUI.color = Color.black;
		passwordUI.color = Color.black;*/
		
				if (CheckLogin ()) {
						//TODO: LOAD SCENE
				} else {
						//TODO: ADD ERROR MESSAGE
						emailUI.color = Color.red;
						passwordUI.color = Color.red;
				}
	
		
		}
		
		public void SetEmail (string tempEmail)
		{
				email = tempEmail;
		}
		
		public void SetPassword (string tempPassword)
		{
				password = tempPassword;
		}
		
		private bool CheckLogin ()
		{
				return email.Equals (correctEmail) && password.Equals (correctPassword);
		}
}