package watch.gnomon.hierarchy;

import java.util.ArrayList;

public class School {
	
	public String name = "";
	public ArrayList<Community> communities = new ArrayList<>();
	public ArrayList<Building> buildings = new ArrayList<>();
	
	
	
	public School(String name){
		this.name = name;
	}
	
	public void addCommunity(String communityName,ArrayList<Building> buildings){
		Community c = new Community(communityName,buildings);
		
		this.communities.add(c);
		this.buildings.addAll(buildings);	
	}
	
	
	public int calculateEnergyToday(){
		int total = 0;
		
		for(Community com : communities){
			total += com.calculateEnergyToday();
		}
		return total;
	}
	
	public int calculateEnergyLastWeek(){
		int total = 0;
		
		for(Community com : communities){
			total += com.calculateEnergyLastWeek();
		}
		return total;		
	}
	
	
	public ArrayList<Integer> calculatePastMonth(){
		
		ArrayList<Integer> lastMonth = new ArrayList<Integer>();
		for(int i=0;i<30;i++){
			lastMonth.add(0);
		}
		
		for(Community com : communities){
			for(int j=0;j<30;j++){
				int temp = lastMonth.get(j)+com.calculateDay(j);
				lastMonth.set(j, temp);
			}
		}
		return lastMonth;

	}
	
	
	
	

}
