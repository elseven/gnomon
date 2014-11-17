﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Team
{


		private string name;
	
		private List<School> schoolList = new List<School> ();
		private List<Building> buildingList = new List<Building> ();
		private List<Room> roomList = new List<Room> ();
		
		

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