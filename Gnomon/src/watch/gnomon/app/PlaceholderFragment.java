package watch.gnomon.app;

import java.util.Locale;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.app.FragmentPagerAdapter;
import android.os.Bundle;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.TextView;

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
    
    public PlaceholderFragment() {
    }
    
    /**
     * Returns a new instance of this fragment for the given section
     * number.
     */
    public PlaceholderFragment (int sectionNumber) {
        position = sectionNumber;
    }

   

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
        View rootView = null;
    	switch (position){
    	case 0:
    		rootView = inflater.inflate(R.layout.progress, container, false);
    		Spinner spinner = (Spinner) rootView.findViewById(R.id.compareSpinner);
    		// Create an ArrayAdapter using the string array and a default spinner layout
    		ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(getActivity().getBaseContext(),
    		        R.array.compare_array, android.R.layout.simple_spinner_item);
    		// Specify the layout to use when the list of choices appears
    		adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
    		// Apply the adapter to the spinner
    		spinner.setAdapter(adapter);
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
}