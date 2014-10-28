package watch.gnomon.hierarchy;

import java.util.ArrayList;

public class Building {


	public String name;
	public ArrayList<Floor> floors = new ArrayList<>();
	public ArrayList<Room> rooms = new ArrayList<>();

	public Building(String name){
		this.name =name;



		Floor first = new Floor("First",1);

		first.addRoom(101);
		first.addRoom(107);
		first.addRoom(147);

		Floor second = new Floor("Second",2);
		second.addRoom(231);
		second.addRoom(257);
		second.addRoom(297);

		Floor third = new Floor("Third",3);
		third.addRoom(338);
		third.addRoom(344);
		third.addRoom(366);



		floors.add(first);
		floors.add(second);
		floors.add(third);

		
		for(Floor f : floors){

			for(Room r : f.rooms){
				rooms.add(r);
			}
	
		}
		
		
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
		
		for(Floor com : floors){
			for(int j=0;j<30;j++){
				int temp = lastMonth.get(j)+com.calculateDay(j);
				lastMonth.set(j, temp);
			}
		}
		return lastMonth;

	}




}
