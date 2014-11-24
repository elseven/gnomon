using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Team : IComparable<Team>
{

		
		
		private string name;
		
		private List<School> schoolList = new List<School> ();
		private List<Building> buildingList = new List<Building> ();
		private List<Room> roomList = new List<Room> ();
		
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

		public List<School> SchoolList {
				get {
						return schoolList;
				}
				set {
						schoolList = value;
				}
		}

		public List<Building> BuildingList {
				get {
						return buildingList;
				}
				set {
						buildingList = value;
				}
		}

		public List<Room> RoomList {
				get {
						return roomList;
				}
				set {
						roomList = value;
				}
		}
		
		
		
		#endregion

		#region IComparable implementation
		public int CompareTo (Team other)
		{
		
				return this.Name.CompareTo (other.Name);
		
		}
		
		
		#endregion
		public Team ()
		{
				this.Name = "Default Name";
				
		}
		
		public Team (string name)
		{
				this.Name = name;
				id = count;
				count++;
		}		
		
		public Team (Team other)
		{
				this.Name = other.Name;
				foreach (School s in other.SchoolList) {
						this.SchoolList.Add (s);
				}
				foreach (Building b in other.BuildingList) {
						this.BuildingList.Add (b);
				}
				foreach (Room r in other.RoomList) {
						this.RoomList.Add (r);
				}
		}
		
		
		public string GenerateGraphTitle ()
		{
				return "Team " + this.Name;
		
		}
		
		public int GetLineCount ()
		{
				return SchoolList.Count + BuildingList.Count + RoomList.Count;
		}
		
		public string GetLineAt (int index)
		{
				List<string> names = new List<string> ();
				foreach (School s in SchoolList) {
						names.Add (s.Name);
				}
				
				foreach (Building b in BuildingList) {
						names.Add (b.GetFullName ());
				}
				
				foreach (Room r in RoomList) {
						names.Add (r.GetFullName ());
				}
				
				
				if (index < names.Count) {
						return names [index];
				} else {
						return "";
				}
		}



		
		public Vector2[] GetEnergyPointsRange (int begin, int end)
		{
		
				Vector2[] points = new Vector2[end + 1 - begin];
		
				for (int i=0; i<points.Length; i++) {
						float y = this.GetEnergyAtDay (i);
						points [i] += new Vector2 (0f, y);
				}
		
				return points;
		}
	
		public float GetEnergyAtDay (int dayIndex)
		{
				if (dayIndex >= 365 || dayIndex < 0) {
						Debug.LogError ("NOT A REAL DAY: " + dayIndex);
						return -1;
				} else {
						float energyTotal = 0;
						foreach (School s in schoolList) {
								energyTotal += s.GetEnergyAtDay (dayIndex);
						}
						
						foreach (Building b in buildingList) {
								energyTotal += b.GetEnergyAtDay (dayIndex);
						}
						
						
						foreach (Room r in roomList) {
								energyTotal += r.GetEnergyAtDay (dayIndex);
						}
			
						return energyTotal;
				}
		
		
		}



}
