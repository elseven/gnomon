using UnityEngine;
using System.Collections;
using System;
public class Room : IComparable<Room>
{



	#region fields
		private int number;
		private float[] energyByDay = new float[365];
		private float minEnergy = 3f;
		private float maxEnergy = 5f;
		private float energyTrend = .01f;
		private string buildingName;
		private string schoolName;
		private bool isPublished;
	#endregion
	
	#region properties
		public int Number {
				get {
						return number;
				}
				set {
						number = value;
				}
		}

		public string BuildingName {
				get {
						return buildingName;
				}
				set {
						buildingName = value;
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

		public bool IsPublished {
				get {
						return isPublished;
				}
				set {
						isPublished = value;
				}
		}

	#endregion
	
	
	
		public Room (int number, string schoolName, string buildingName, bool isPublished)
		{
				this.Number = number;
				this.SchoolName = schoolName;
				this.BuildingName = buildingName;
				this.IsPublished = isPublished;
				PopulateEnergyByDay ();
				
		}

		#region IComparable implementation
		public int CompareTo (Room other)
		{
		
				int schoolOrder = string.Compare (this.SchoolName, other.SchoolName);
				int buildingOrder = string.Compare (this.BuildingName, other.BuildingName);
				int roomOrder = this.Number.CompareTo (other.Number);
				
				int compResult = schoolOrder * 100 + buildingOrder * 10 + roomOrder;
				Debug.LogWarning ("comp " + this.GetFullName () + "  " + other.GetFullName () + " =>" + compResult);
				
				return compResult;
				
		}
		#endregion		
		
		public string GetFullName ()
		{
				return "Room #" + this.Number + "   " + this.BuildingName + "   (" + this.SchoolName + ")";
		}
		
		
		private void PopulateEnergyByDay ()
		{
		
		
				for (int i=0; i<energyByDay.Length; i++) {
						//URGENT: FIX BACK
						//energyByDay [i] = UnityEngine.Random.Range (minEnergy, maxEnergy) - energyTrend * i;
						energyByDay [i] = i * 10;
				}
				
			
		
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
						return energyByDay [dayIndex];
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


}
