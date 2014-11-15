using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building
{

	#region fields
		private string name;
		private List<Room> rooms = new List<Room> ();
		private int minRoomCount = 3;
		private int maxRoomCount = 30;
		

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
				
	
		}
		
		private int GenerateRoomNumber ()
		{
		
				int hundredsPlace = Random.Range (minHundredsPlace, maxHundredsPlace);
				int tensPlace = Random.Range (0, 9);
				int onesPlace = Random.Range (0, 9);
				int roomNumber = 100 * hundredsPlace + 10 * tensPlace + onesPlace;
				
				return roomNumber;
		}
	
		public float[] GetEnergyRange (int begin, int end)
		{
				if (end < begin) {
						Debug.LogError ("BAD RANGE!!!!");
						return null;
				}
		
		
				float[] energyValues = new float[end + 1 - begin];
				
				
				foreach (Room r in rooms) {
		
						for (int i=0; i<energyValues.Length; i++) {
								energyValues [i] = r.GetEnergyAtDay (i);
			
						}
				}
				 
				
		
				return energyValues;
		
		}
	


}
