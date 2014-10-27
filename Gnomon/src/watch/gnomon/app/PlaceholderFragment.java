package watch.gnomon.app;

import java.util.Locale;
import java.util.concurrent.Callable;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.app.FragmentPagerAdapter;
import android.os.Bundle;
import android.provider.DocumentsContract.Root;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
enum Funk {
	ADD_NEW_SCHOOL,
	ADD_NEW_COM,
	ADD_NEW_FLOOR,
	ADD_NEW_BUILDING,
	ADD_NEW_ROOM

}
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
    
    
    
    public View rootView = null;
    
    /**
     * Adapter for Progress Tab
     */
    public ProgressAdapter progAdapter;
    public PlaceholderFragment() {
    }
    
    /**
     * Returns a new instance of this fragment for the given section
     * number.
     */
    public PlaceholderFragment (int sectionNumber) {
        position = sectionNumber;
    }

   
    //Switching on tabs
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
        
    	switch (position){
    	//progress tab
    	case 0:
    		//show whatever is in xml stuff
    		rootView = inflater.inflate(R.layout.progress, container, false);
    		
    		progAdapter = new ProgressAdapter(rootView, getActivity());
    		
    		
    		makeClickable(1000,Funk.ADD_NEW_SCHOOL);
    		break;
    	case 1:
    		rootView = inflater.inflate(R.layout.home, container, false);
    		break;
    	case 2:
    		rootView = inflater.inflate(R.layout.saved, container, false);
    		break;
    		
    		default:
    			Log.d("NOT A REAL PAGE", "Position: " + Integer.toString(MainActivity.currentPosition));
    	}
    	
        return rootView;
    }
    
    
    private void makeClickable(int buttonId,final Funk functionId){
    	Log.d("asdf","buttonid= " + buttonId);
    	final Button button = (Button) rootView.findViewById(buttonId);
    	
         button.setOnClickListener(new View.OnClickListener() {
             public void onClick(View v) {
            	 buttonLogic(functionId);
             }
         });
    }

    
    public void buttonLogic(Funk functionId){
    	switch(functionId){
    	case ADD_NEW_BUILDING:
    		break;
    	case ADD_NEW_COM:
    		break;
    	case ADD_NEW_FLOOR:
    		break;
    	case ADD_NEW_ROOM:
    		break;
    	case ADD_NEW_SCHOOL:
    		progAdapter.addNewSpinner(R.array.list_of_schools);
    		//TODO Remove Previous Button
    		//TODO Add new buttton
    		
    		break;
    		
    		
    	}
    }
    
    
    
    
    
}