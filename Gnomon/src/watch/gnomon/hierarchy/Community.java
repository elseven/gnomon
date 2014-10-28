package watch.gnomon.hierarchy;

import java.util.ArrayList;

public class Community {

	
	public String name;
	public ArrayList<Building> buildings = new ArrayList<>();
	
	public Community(String name, ArrayList<Building> buildings){
		this.name = name;
		this.buildings = buildings;
	}
	
	
	public int calculateEnergyToday(){
		int total = 0;
		
		for(Building b : buildings){
			total += b.calculateEnergyToday();
		}
		return total;
	}
	
	public int calculateEnergyLastWeek(){
		int total = 0;
		
		for(Building b : buildings){
			total += b.calculateEnergyLastWeek();
		}
		return total;		
		
	}
	
	public int calculateDay(int day){
		
		int total = 0;
		
		for(Building b: buildings){
			total += b.calculateDay(day);
		}
		
		return total;
		
	}
	
	
public ArrayList<Integer> calculatePastMonth(){
		
		ArrayList<Integer> lastMonth = new ArrayList<Integer>();
		for(int i=0;i<30;i++){
			lastMonth.add(0);
		}
		
		for(Building com : buildings){
			for(int j=0;j<30;j++){
				int temp = lastMonth.get(j)+com.calculateDay(j);
				lastMonth.set(j, temp);
			}
		}
		return lastMonth;

	}
	
}
