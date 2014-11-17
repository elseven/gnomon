using UnityEngine;
using System.Collections;

public class Room
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
		
		
		
		private void PopulateEnergyByDay ()
		{
		
		
				for (int i=0; i<energyByDay.Length; i++) {
						energyByDay [i] = Random.Range (minEnergy, maxEnergy) - energyTrend * i;
						
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
