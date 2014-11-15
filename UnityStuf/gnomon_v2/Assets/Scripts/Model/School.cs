using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class School
{

		#region fields
		private string name;
		private List<Building> buildings = new List<Building> ();
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
		public List<Building> Buildings {
				get {
						return buildings;
				}
		
		}		
		
		

		#endregion
		
		
		public School (string name, List<string> buildingNames)
		{
				this.Name = name;
				foreach (string bn in buildingNames) {
						Building building = new Building (bn);
						this.buildings.Add (building);
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
						float energyTotal = 0;
						foreach (Building b in buildings) {
								energyTotal += b.GetEnergyAtDay (dayIndex);
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
		
		public Building GetBuildingByName (string buildingName)
		{
		
				foreach (Building b in buildings) {
						if (b.Name.Equals (buildingName)) {
								return b;
						}
				}
		
				Debug.LogError ("NO SUCH BUILDING");
				return null;
		}
	
	
	
}
