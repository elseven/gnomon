using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class User
{
		//URGENT: ALPHABETIZE teams and matches on add/update
		//TODO: ADD DRAGS TO STUFF
	
		public List<Team> myTeams = new List<Team> ();
		public List<Match> myMatches = new List<Match> ();
	
	
		public User (List<Team> teams, List<Match> matches)
		{
				this.myTeams.AddRange (teams);
				this.myMatches.AddRange (matches);
		}
		
		
		
		public void DeleteTeam (Team toDelete)
		{
		
				Debug.LogWarning ("id to delete: " + toDelete.id);
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
								Debug.LogWarning ("yay!");
								return;
						}
				}
			
				Debug.LogError ("DELETE DOESNT EXIST");
			
		}
		
		
		public void UpdateTeam (Team toReplace)
		{
				for (int i=0; i<myTeams.Count; i++) {
						if (myTeams [i].id == toReplace.id) {
								myTeams [i] = toReplace;
								return;
						}
				}
		
				Debug.LogError ("UPDATE DOESNT EXIST");
				
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
