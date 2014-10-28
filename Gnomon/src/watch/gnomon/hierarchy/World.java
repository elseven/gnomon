package watch.gnomon.hierarchy;

import java.util.ArrayList;

public class World {
	
	public ArrayList<School> schools = new ArrayList<>();
	
	
	/*
	 * UGA
	 * 	ECV
	 * 		BUSBEE
	 * 		MCWHOTER
	 *	CRESSWELL
	 *		CRESSWELL
	 */
	public World(){
		School uga = new School("University of Georgia");

		ArrayList<Building> ecv = new ArrayList<Building>();
		Building busbee = new Building("Busbee");
		ecv.add(busbee);
		Building mcw = new Building("McWhoter");
		ecv.add(mcw);
		
		
		
		uga.addCommunity("East Campus Village",ecv);
		
		
		School gt = new School("Georgia Tech");
		schools.add(uga);
		schools.add(gt);
		
		int schoolValue = schools.get(0).calculateEnergyLastWeek();
		if(schoolValue==0){
			System.out.println("asdf");
		}
		
	}
	
	public School getSchool(String name){
		
		for(School s : schools){
			if(s.name.equals(name)){
				return s;
			}
		}
		return schools.get(0);
		
	}
	

}
