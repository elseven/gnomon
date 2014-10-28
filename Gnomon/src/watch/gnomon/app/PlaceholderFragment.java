package watch.gnomon.app;

import java.util.ArrayList;
import java.util.Locale;

import watch.gnomon.hierarchy.*;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.app.FragmentPagerAdapter;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

/**
 * A placeholder fragment containing a simple view.
 */
public class PlaceholderFragment extends Fragment {
    /**
     * The fragment argument representing the section number for this
     * fragment.
     */
    private static final String ARG_SECTION_NUMBER = "section_number";
    private int position = 0;
    private Context mContext;
    public PlaceholderFragment() {
    }
    
    /**
     * Returns a new instance of this fragment for the given section
     * number.
     */
    public PlaceholderFragment (int sectionNumber, Context context) {
        position = sectionNumber;
        mContext = context;
    }

   

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
        View rootView = null;
    	switch (position){
    	case 0:
    		rootView = inflater.inflate(R.layout.progress, container, false);
    		break;
    	case 1:
    		rootView = inflater.inflate(R.layout.home, container, false);
    		homeView(rootView); //Easier to maintain code
    		break;
    	case 2:
    		rootView = inflater.inflate(R.layout.saved, container, false);
    		break;
    		
    		default:
    			Log.d("NOT A REAL PAGE", "Position: " + Integer.toString(MainActivity.currentPosition));
    	}
    	
        return rootView;
    }
    /**
     * setup for the progress tab
     * @param rootView
     */
    private void progressView(View rootView){
    	
    }
    /**
     * setup for the home tab
     * @param rootView
     */
    private void homeView(final View rootView){
    	World world = new World();
    	final School uga = world.getSchool("University of Georgia");
    	Community com = uga.communities.get(0);
    	Building buil = com.buildings.get(0);
    	Floor flo = buil.floors.get(0);
    	Room roo = flo.rooms.get(0);
    	
    	String schoolString = uga.name;
    	String communityString = com.name;
    	String buildingString = buil.name;
    	String floorString = flo.name;
    	String roomString = "Room " + roo.number;
    	
    	/**
    	 * Names that are on top of the home view
    	 */
    	TextView schoolName = (TextView) rootView.findViewById(R.id.schoolName);
		TextView communityName = (TextView) rootView.findViewById(R.id.communityName);
		TextView buildingName = (TextView) rootView.findViewById(R.id.buildingName);
		TextView floorName = (TextView) rootView.findViewById(R.id.floorName);
		TextView roomName = (TextView) rootView.findViewById(R.id.roomName);
    	
		//Dynamically set the names
		schoolName.setText(schoolString);
    	communityName.setText(communityString);
    	buildingName.setText(buildingString);
    	floorName.setText(floorString);
    	roomName.setText(roomString);
    	
    	Button school = (Button) rootView.findViewById(R.id.school);
		Button community = (Button) rootView.findViewById(R.id.community);
		Button building = (Button) rootView.findViewById(R.id.building);
		Button floor = (Button) rootView.findViewById(R.id.floor);
		Button room = (Button) rootView.findViewById(R.id.room);
		
		//Dynamically set the names
		school.setText(schoolString);
    	community.setText(communityString);
    	building.setText(buildingString);
    	floor.setText(floorString);
    	room.setText(roomString);
    	
    	
		/**
		 * BUTTON LISTENERS
		 */
        school.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Toast.makeText(rootView.getContext(), "Graph will show now school", Toast.LENGTH_SHORT).show();
				Grapher graph = new Grapher(rootView.getContext(),rootView);
				LinearLayout layout = (LinearLayout) rootView.findViewById(R.id.graphLayout);
				ArrayList<ArrayList<Integer>> tempPlot = new ArrayList< ArrayList<Integer> >();
				tempPlot.add(uga.calculatePastMonth());
				layout = graph.plot(tempPlot);
			}
		} );
        
        community.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Toast.makeText(rootView.getContext(), "Graph will show now community", Toast.LENGTH_SHORT).show();
			}
		} );
        
        building.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Toast.makeText(rootView.getContext(), "Graph will show now building", Toast.LENGTH_SHORT).show();
			}
		} );
        
        floor.setOnClickListener(new OnClickListener() {
	
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Toast.makeText(rootView.getContext(), "Graph will show now floor", Toast.LENGTH_SHORT).show();
			}
		} );
        
		room.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Toast.makeText(rootView.getContext(), "Graph will show now for room", Toast.LENGTH_SHORT).show();
			}
		} );
		
		/**
		 * TextViews for the average and total usage
		 */
		TextView schoolAverage = (TextView) rootView.findViewById(R.id.schoolAverage);
		TextView schoolTotal = (TextView) rootView.findViewById(R.id.schoolTotal);
		schoolAverage.setText(uga.calculateEnergyLastWeek() + " ");
		schoolTotal.setText(uga.calculateEnergyToday() + " ");

		TextView communityAverage = (TextView) rootView.findViewById(R.id.communityAverage);
		TextView communityTotal = (TextView) rootView.findViewById(R.id.communityTotal);
		communityAverage.setText(com.calculateEnergyLastWeek() + " ");
		communityTotal.setText(com.calculateEnergyToday() + " ");
		
		TextView buildingAverage = (TextView) rootView.findViewById(R.id.buildingAverage);
		TextView buildingTotal = (TextView) rootView.findViewById(R.id.buildingTotal);
		buildingAverage.setText(buil.calculateEnergyLastWeek() + " ");
		buildingTotal.setText(buil.calculateEnergyToday() + " ");
		
		TextView floorAverage = (TextView) rootView.findViewById(R.id.floorAverage);
		TextView floorTotal = (TextView) rootView.findViewById(R.id.floorTotal);
		floorAverage.setText(flo.calculateEnergyLastWeek() + " ");
		floorTotal.setText(flo.calculateEnergyToday() + " ");
		
		TextView roomAverage = (TextView) rootView.findViewById(R.id.roomAverage);
		TextView roomTotal = (TextView) rootView.findViewById(R.id.roomTotal);		
		roomAverage.setText(roo.lastWeek + " ");
		roomTotal.setText(roo.today + " ");
    }
    /**
     * setup for saved tab
     * @param rootView
     */
    private void savedView(View rootView){
    	
    }
    
}