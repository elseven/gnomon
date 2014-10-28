package watch.gnomon.hierarchy;

import java.util.ArrayList;

public class Floor {
	
	
	public String name;
	public int id;
	public ArrayList<Room> rooms = new ArrayList<>();
	
	public Floor(String name,int id){
		this.name = name;
		this.id = id;
		
	}
	
	public void addRoom(int roomNumber){
		Room room = new Room(roomNumber);
		rooms.add(room);
	}
	public void addRoom(Room r){
		rooms.add(r);
	}
	
	
	public int calculateEnergyToday(){
		int total = 0;
		
		for(Room  r: rooms){
			total += r.today;
		}
		return total;
	}
	
	public int calculateEnergyLastWeek(){
		int total = 0;
		
		for(Room  r: rooms){
			total += r.lastWeek;
		}
		return total;	
		
	}
	
	
	public int calculateDay(int day){

		int total = 0;

		for(Room r: rooms){
			total += r.calculateDay(day);
		}

		return total;

	}
	
	
public ArrayList<Integer> calculatePastMonth(){
		
		ArrayList<Integer> lastMonth = new ArrayList<Integer>();
		for(int i=0;i<30;i++){
			lastMonth.add(0);
		}
		
		for(Room com : rooms){
			for(int j=0;j<30;j++){
				int temp = lastMonth.get(j)+com.calculateDay(j);
				lastMonth.set(j, temp);
			}
		}
		return lastMonth;

	}
}
