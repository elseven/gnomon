using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class World
{


		private List<School> schools = new List<School> ();
		
		


	
		public World ()
		{
		
		
				//GEORGIA TECH
				List<string> gtBuildings = new List<string> ();
				gtBuildings.Add ("Armstrong");
				gtBuildings.Add ("Brown");
				gtBuildings.Add ("Caldwell");
				gtBuildings.Add ("Center Street South");
				gtBuildings.Add ("Woodruff South");
				School gt = new School ("Georgia Tech", gtBuildings);
				
				
				
				//UNIVERSITY OF GEORGIA
				List<string> ugaBuildings = new List<string> ();
				ugaBuildings.Add ("Brumby Hall");
				ugaBuildings.Add ("Building 1516");
				ugaBuildings.Add ("Creswell Hall");
				ugaBuildings.Add ("Busbee Hall");
				ugaBuildings.Add ("McWhoter Hall");
				ugaBuildings.Add ("Vandiver Hall");
				School uga = new School ("The University of Georgia", ugaBuildings);
				
				
				
				
				
				//ADD SCHOOLS
				schools.Add (gt);
				schools.Add (uga);
				
				
	
		}
	
	
		
		
		/*
		public Vector2[] GetEnergyPointsRange (int begin, int end)
		{
				
				Vector2[] points = new Vector2[end + 1 - begin];
				
				for (int i=0; i<points.Length; i++) {
						float y = GetEnergyAtDay (school, i);
						points [i] = new Vector2 (0f, y);
				}
				
				return points;
		}
		
		
		
		
		public float GetEnergyAtDay (School school, int dayIndex)
		{		
				
				return school.GetEnergyAtDay (dayIndex);
		}
	
		public float[] GetEnergyRange (School school, int begin, int end)
		{		
				
				return school.GetEnergyRange (begin, end);
		}
		*/
		
		public School GetSchoolByName (string schoolName)
		{
			
				foreach (School s in schools) {
						if (s.Name.Equals (schoolName)) {
								return s;
						}
				}
			
				Debug.LogError ("NO SUCH SCHOOL");
				return null;
		}
		
		public Building GetBuildingByNames (string schoolName, string buildingName)
		{
				School s = GetSchoolByName (schoolName);
				Building building = s.GetBuildingByName (buildingName);
			
				return building;
		}
		
		public Room GetRoomByNames (string schoolName, string buildingName, int roomIndex)
		{
				Building building = GetBuildingByNames (schoolName, buildingName);
				Room room = building.GetRoomAt (roomIndex);
				
				return room;
	
	
		}
}
