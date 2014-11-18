using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building
{

	#region fields
		private string name;
		private string schoolName;
		private List<Room> rooms = new List<Room> ();

		private int maxHundredsPlace = 6;

		private int maxTensPlace = 4;
		private int maxOnesPlace = 9;
		
	#endregion
	
	#region properties
		public string Name {
				get {
						return name;
				}
				set {
						name = value;
				}
		}

		public string SchoolName {
				get {
						return schoolName;
				}
				set {
						schoolName = value;
				}
		}
	
	#endregion
	
	
		public Building (string name, string schoolName)
		{
				this.Name = name;
				this.SchoolName = schoolName;
				GenerateRooms ();
		}
		
		
		private void GenerateRooms ()
		{
		
				for (int hundrends=1; hundrends<=maxHundredsPlace; hundrends++) {
						for (int tens=0; tens<=maxTensPlace; tens++) {
								for (int ones=0; ones<=maxOnesPlace; ones++) {
					
										bool isPublished = ((Random.Range (0, 10) % 10) == 0);
										int roomNumber = hundrends * 100 + tens * 10 + ones;
										Room room = new Room (roomNumber, schoolName, name, isPublished);
										rooms.Add (room);
								}
				
				
				
						}
			
			
			
				}
		}
		
		public Room GetRoomAt (int index)
		{
				return this.rooms [index];
		}
		
		
		/*
		private int GenerateRoomNumber ()
		{
		
				int hundredsPlace = Random.Range (minHundredsPlace, maxHundredsPlace);
				int tensPlace = Random.Range (0, 6);
				int onesPlace = Random.Range (0, 10);
				int roomNumber = 100 * hundredsPlace + 10 * tensPlace + onesPlace;
				
				return roomNumber;
		}
	
		*/
		
		

			
			
			
		public Vector2[] GetEnergyPointsRange (int begin, int end)
		{
		
				Vector2[] points = new Vector2[end + 1 - begin];
		
				for (int i=0; i<points.Length; i++) {
						float y = this.GetEnergyAtDay (i);
						points [i] = new Vector2 (0f, y);
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
						foreach (Room r in rooms) {
								energyTotal += r.GetEnergyAtDay (dayIndex);
						}
			
						return energyTotal;
				}
		
		
		}
	
		public float[] GetEnergyRange (int begin, int end)
		{
				if (end < begin) {
						Debug.LogError ("BAD RANGE!!!!");
						return null;
				}
		
		
				float[] energyValues = new float[end + 1 - begin];
				for (int i=0; i<energyValues.Length; i++) {
						energyValues [i] += GetEnergyAtDay (i);
				}
		
				return energyValues;
		
		}
	
	
	
		/*
		public float[] GetEnergyRange (int begin, int end)
		{
				if (end < begin) {
						Debug.LogError ("BAD RANGE!!!!");
						return null;
				}
		
		
				float[] energyValues = new float[end + 1 - begin];
				
				
				foreach (Room r in rooms) {
		
						for (int i=0; i<energyValues.Length; i++) {
								energyValues [i] += r.GetEnergyAtDay (i);
			
						}
				}
				 
				
		
				return energyValues;
		
		}
	
*/


}
