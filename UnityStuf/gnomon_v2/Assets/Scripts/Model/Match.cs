using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Match : IComparable<Match>
{

		private string name;
		
		private List<Team> teamList = new List<Team> ();
		
		public int id = 0;
		private static int count = 0;
		
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
	
		public Match ()
		{
				this.Name = "<MATCH NAME>";
				this.TeamList = new List<Team> ();
				id = count;
				count++;
		}
	
		public Match (string name, List<Team> teams)
		{
				this.Name = name;
				this.TeamList = teams;
				id = count;
				count++;
		}
	
	#region IComparable implementation
		public int CompareTo (Match other)
		{
		
				return this.Name.CompareTo (other.Name);
		
		}
	
	
	#endregion

	
		public int GetLineCount ()
		{
			
				return TeamList.Count;
		
		}
	
	
		public string GetLineAt (int index)
		{
				List<string> names = new List<string> ();
				TeamList.Sort ();
				foreach (Team t in TeamList) {
						names.Add (t.Name);
				}
		
		
				if (index < names.Count) {
						return names [index];
				} else {
						return "";
				}
		}
	
	
	
}
