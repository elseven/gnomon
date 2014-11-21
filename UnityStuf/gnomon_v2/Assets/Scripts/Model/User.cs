using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class User
{
	
		//URGENT: USER SHOULD HAVE LIST OF SAVED TEAMS AND MATCHES
		//URGENT: USER SHOULD BE CREATED AT STARTUP WITH DEFAULTS SETUP (FROM
	
		public List<Team> myTeams = new List<Team> ();
		public List<Match> myMatches = new List<Match> ();
	
	
		public User (List<Team> teams, List<Match> matches)
		{
		
				this.myTeams = teams;
				this.myMatches = matches;
	
		}
		
		
		
		
		
		
		
		
		
	
}
