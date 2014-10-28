package watch.gnomon.hierarchy;

import java.util.ArrayList;

public class Room {

	public int number;
	public int lastWeek;
	public int today;
	private ArrayList<Integer> pastMonth = new ArrayList<>();
	
	
	public Room(int number){
		this.number = number;
		this.lastWeek = makeUpEnergy();
		this.today = makeUpEnergy();
		makeUpMonth();
	
	}
	
	
	public int calculateDay(int day){

		return pastMonth.get(day);

	}
	
	
	private void makeUpMonth(){
		pastMonth = new ArrayList<Integer>();
		for(int i=0;i<30;i++){
			pastMonth.add(makeUpEnergy());
		}
	}
	
	
	private int makeUpEnergy(){
		
		double raw = Math.random()*1000 + 500;
		int rounded = (int) Math.round(raw);
		
		return rounded;
	}
	
	
public ArrayList<Integer> calculatePastMonth(){
		
		ArrayList<Integer> lastMonth = new ArrayList<Integer>();
		for(int i=0;i<30;i++){
			lastMonth.add(calculateDay(i));
		}
		
		
		return lastMonth;

	}

	
}
