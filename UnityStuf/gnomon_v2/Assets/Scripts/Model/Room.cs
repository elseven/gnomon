using UnityEngine;
using System.Collections;

public class Room
{



	#region fields
		private int number;
		private float[] energyByDay = new float[365];
		private int minEnergy = 3000;
		private int maxEnergy = 4000;
		private int energyTrend = 15;
	#endregion
	
	#region members
		public int Number {
				get {
						return number;
				}
				set {
						number = value;
				}
		}
		
	
	
	#endregion
	
	
	
		public Room (int number)
		{
				PopulateEnergyByDay ();
		}
		
		
		
		private void PopulateEnergyByDay ()
		{
		
		
				for (int i=0; i<energyByDay.Length; i++) {
						energyByDay [i] = 1.0f * Random.Range (minEnergy, maxEnergy) - energyTrend * i;
						Debug.Log (energyByDay [i]);
				}
		
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
						energyValues [i] = GetEnergyAtDay (i);
				}
				
				return energyValues;
			
		}


}
