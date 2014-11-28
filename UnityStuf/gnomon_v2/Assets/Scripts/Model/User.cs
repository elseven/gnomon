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
		
				for (int j=0; j<myMatches.Count; j++) {
						Match tempMatch = myMatches [j];
						for (int jj=0; jj<tempMatch.TeamList.Count; jj++) {
								if (tempMatch.TeamList [jj].id == toDelete.id) {
										tempMatch.TeamList.RemoveAt (jj);
										break;
								}
						}
				}
		
				for (int i=0; i<myTeams.Count; i++) {
						if (myTeams [i].id == toDelete.id) {
								myTeams.RemoveAt (i);
								return;
						}
				}
			
				Debug.LogError ("DOESNT EXIST");
			
		}
		
		
		public void UpdateTeam (Team toReplace)
		{
				for (int i=0; i<myTeams.Count; i++) {
						if (myTeams [i].id == toReplace.id) {
								myTeams [i] = toReplace;
								return;
						}
				}
		
				Debug.LogError ("DOESNT EXIST");
				
				myTeams.Add (toReplace);
		
		}
		
		
		
		public void DeleteMatch (Match toDelete)
		{
				for (int i=0; i<myMatches.Count; i++) {
						if (myMatches [i].id == toDelete.id) {
								myMatches.RemoveAt (i);
								return;
						}
				}
		
				Debug.LogError ("DOESNT EXIST");
		
		}
	
	
		public void UpdateMatch (Match toReplace)
		{
				for (int i=0; i<myMatches.Count; i++) {
						if (myMatches [i].id == toReplace.id) {
								myMatches [i] = toReplace;
								return;
						}
				}
		
				Debug.LogError ("DOESNT EXIST");
		
				myMatches.Add (toReplace);
		
		}
	
	
		
		
		
		
	
}
