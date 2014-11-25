using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
*HOLDS ALL THE DATA. PART OF MODEL
*/
public class World
{


		public List<School> schools = new List<School> ();
		
		//private List<Team> teams = new List<Team> ();
		
		//private List<Match> matches = new List<Match> ();
		
		public User TheUser;

	
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
				
				#region Team1
				Team t1 = new Team ("GT and some UGA");
				
				//SCHOOLS LIST
				t1.SchoolList = new List<School> ();
				t1.SchoolList.Add (gt);
				
				//BUILDING LIST
				t1.BuildingList = new List<Building> ();
				Building b1 = uga.Buildings [0];
				Building b2 = uga.Buildings [1];
				t1.BuildingList.Add (b1);
				t1.BuildingList.Add (b2);
				
				//ROOM LIST
				t1.RoomList = new List<Room> ();
				#endregion
			
			
			
				#region Team2
				Team t2 = new Team ("UGA and a room");
		
				//SCHOOLS LIST
				t2.SchoolList = new List<School> ();
				t2.SchoolList.Add (uga);
		
				//BUILDING LIST
				t2.BuildingList = new List<Building> ();
		
				//ROOM LIST
				t2.RoomList = new List<Room> ();
				Room r1 = uga.Buildings [0].GetRoomAt (0);
				t2.RoomList.Add (r1);
				
				#endregion
		
				List<Team> myTeams = new List<Team> ();
				myTeams.Add (t1);
				myTeams.Add (t2);
				
				
				List<Match> myMatches = new List<Match> ();
				Match m1 = new Match ("Awesome match", myTeams);
				myMatches.Add (m1);
				
		
		
		
		
				TheUser = new User (myTeams, myMatches);
				
				
				
	
		}
	
	
	
		
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
