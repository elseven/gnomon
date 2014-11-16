using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Match
{

		private string name;
		
		private List<Team> teamList = new List<Team> ();
		
		
		
		#region properties
		public string Name {
				get {
						return name;
				}
				set {
						name = value;
				}
		}

		public List<Team> TeamList {
				get {
						return teamList;
				}
				set {
						teamList = value;
				}
		}
		#endregion
	
		public Match (string name, List<Team> teams)
		{
				this.Name = name;
				this.TeamList = teams;
		}
	
	
	
		
	
	
	
	
	
}
