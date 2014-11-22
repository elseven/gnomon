using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class User
{
	
	
		public List<Team> myTeams = new List<Team> ();
		public List<Match> myMatches = new List<Match> ();
	
	
		public User (List<Team> teams, List<Match> matches)
		{
				this.myTeams = teams;
				this.myMatches = matches;
		}
		
		
		
		public void DeleteTeam (Team toDelete)
		{
				for (int i=0; i<myTeams.Count; i++) {
						if (myTeams [i].id == toDelete.id) {
								myTeams.RemoveAt (i);
								return;
						}
				}
			
				Debug.LogError ("DOESNT EXIST");
			
		}
		
		
		
		
		
	
}
