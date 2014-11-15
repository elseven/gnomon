using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building
{

	#region fields
		private string name;
		private List<Room> rooms = new List<Room> ();
		private int minRoomCount = 1;
		private int maxRoomCount = 5;
		

		private int minHundredsPlace = 1;
		private int maxHundredsPlace = 6;

		
	#endregion
	
	#region members
		public string Name {
				get {
						return name;
				}
				set {
						name = value;
				}
		}
	
	#endregion
	
	
		public Building (string name)
		{
				this.Name = name;
				
				int roomCount = Random.Range (minRoomCount, maxRoomCount);
				List<int> existingRoomNumbers = new List<int> ();
				for (int i=0; i<roomCount; i++) {
						
						int roomNumber = -1;
						
						//keep generating room number until it is unique
						while (existingRoomNumbers.Contains(roomNumber = GenerateRoomNumber())) {
						}
						
						
						existingRoomNumbers.Add (roomNumber);
						Room room = new Room (roomNumber);
						rooms.Add (room);
						
						
				}
				
				
				string debugstring = this.name + "  ";
				
				for (int j=0; j<rooms.Count; j++) {
						Room temproom = rooms [j];
						debugstring += "\nRoom number " + temproom.Number + " : " 
								+ temproom.GetEnergyAtDay (0) + " "
								+ temproom.GetEnergyAtDay (1) + " "
								+ temproom.GetEnergyAtDay (2) + " "
								+ temproom.GetEnergyAtDay (3) + " ";
				}	
				
				Debug.Log (debugstring);
		
				
	
		}
		
		
		public Room GetRoomAt (int index)
		{
				return this.rooms [index];
		}
		
		
		
		private int GenerateRoomNumber ()
		{
		
				int hundredsPlace = Random.Range (minHundredsPlace, maxHundredsPlace);
				int tensPlace = Random.Range (0, 6);
				int onesPlace = Random.Range (0, 10);
				int roomNumber = 100 * hundredsPlace + 10 * tensPlace + onesPlace;
				
				return roomNumber;
		}
	
		
			
			
			
			
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
