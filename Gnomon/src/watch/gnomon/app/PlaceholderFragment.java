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
        position = 0;
    	switch (position){
    	case 0:
    		rootView = inflater.inflate(R.layout.fragment_main, container, false);
    		break;
    	case 1:
    		break;
    	case 2:
    		break;
    		default:
    			Log.d("NOT A REAL PAGE", "Position: " + Integer.toString(MainActivity.currentPosition));
    	}
    	
        return rootView;
    }
}