package watch.gnomon.app;

import android.support.v4.app.FragmentActivity;
import android.util.TypedValue;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;

public class ProgressAdapter {
	
	View rootView;
	FragmentActivity parentActivity;
	int numOfButtons = 0;
	int mainSpinnerCount = 0;
	int maxSpinnerCount = 3;
	
	LinearLayout spinnerContainer1;
	LinearLayout spinnerContainer2;
	LinearLayout spinnerContainer3;
	LinearLayout buttonContainer1;
	LinearLayout buttonContainer2;
	
	TextView textViewTemplate;
	Spinner spinnerTemplate;
	Button outerButton;
	Button innerButton;
	
	
	public ProgressAdapter(View root, FragmentActivity parent) {
		
		rootView = root;
		parentActivity = parent;

		spinnerContainer1 = (LinearLayout) rootView.findViewById(R.id.spinnerContainer1);
		spinnerContainer2 = (LinearLayout) rootView.findViewById(R.id.spinnerContainer2);
		spinnerContainer3 = (LinearLayout) rootView.findViewById(R.id.spinnerContainer3);
		
		
		buttonContainer1 = (LinearLayout) rootView.findViewById(R.id.newCompareButton1Container);
		buttonContainer2 = (LinearLayout) rootView.findViewById(R.id.newCompareButton2Container);
		
		textViewTemplate = (TextView) View.inflate(parent, R.layout.text_view_template, null);
		spinnerTemplate = (Spinner) View.inflate(parent, R.layout.spinner_template, null);
		
		/**
		 * Setting up default view
		 */
		Spinner compareBySpinner = (Spinner) rootView.findViewById(R.id.compareSpinner);
		// Create an ArrayAdapter using the string array and a spinner layout
		ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(parentActivity.getBaseContext(),
		        R.array.compare_array, R.layout.compare_spinner);
		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		compareBySpinner.setAdapter(adapter);
		
		setSpinnerType(R.id.firstSpinner, R.array.list_of_schools);
		setSpinnerText(R.id.firstSpinnerText, "First School");
		//addButton("School");
		
		addNewSpinner(R.array.list_of_schools);
		addButton("Add School");
		/*
		addNewSpinner(R.array.list_of_schools);
		addNewSpinner(R.array.list_of_schools);
		addNewSpinner(R.array.list_of_schools);
		 */
		
	}

	public void addNewSpinner(int list_of_schools) { // Add new school spinner (Parent)
		
		textViewTemplate = (TextView) View.inflate(parentActivity, R.layout.text_view_template, null);
		spinnerTemplate = (Spinner) View.inflate(parentActivity, R.layout.spinner_template, null);
		
		LinearLayout spinnerContainerToUse = null;
		String title = null;
		int spinnerResource = 0;
		
		if (mainSpinnerCount < maxSpinnerCount) {
			mainSpinnerCount++;
			if (mainSpinnerCount == 1) {
				spinnerContainerToUse = spinnerContainer1;
				spinnerResource = 1111;
				title = "First School";
			} else if (mainSpinnerCount == 2) {
				spinnerContainerToUse = spinnerContainer2;
				spinnerResource = 2222;
				title = "Second School";
			} else if (mainSpinnerCount == 3) {
				spinnerContainerToUse = spinnerContainer3;
				spinnerResource = 3333;
				title = "Third School";
			
			}
			
			TextView newTextView = new TextView(parentActivity);
			Spinner newSpinner = new Spinner(parentActivity);
			newSpinner.setId(spinnerResource);
			
			spinnerContainerToUse.addView(newTextView);
			newTextView.setText(title);
			newTextView.setTextSize(TypedValue.COMPLEX_UNIT_SP,14);
			spinnerContainerToUse.addView(newSpinner);
			setSpinnerType(newSpinner.getId(), R.array.list_of_schools);
			
		}
		
	
		
		
	}

	private void addButton(String message) {
		
		numOfButtons++;
		LinearLayout buttonContainerToUse = null;
		int buttonResourceId = -1;
		Button buttonToUse;
		int containerId = -1;
		if (numOfButtons == 1) {
			button1 = new Button(parentActivity);
			buttonToUse = button1;
			containerId = R.id.newCompareButton1Container;
			buttonContainerToUse = buttonContainer1;
			buttonResourceId = 1000;
			
		} else if (numOfButtons == 2) {
//			buttonContainer1.removeAllViewsInLayout();
			
			buttonContainerToUse = buttonContainer2;
			containerId = R.id.newCompareButton2Container;
			buttonResourceId = 2000;
		}else{
			return;
		}
		
		
		Button newButton = new Button(parentActivity);
		if(button1.equals(newButton)){
			
		}
		buttonContainerToUse.addView(newButton);
		if (numOfButtons == 2) {
			buttonContainerToUse.removeView(newButton);
		}
		newButton.setId(buttonResourceId);
		
	}
	
	private void removeButton(int buttonToRemove) {
		
	}

	private void setSpinnerText(int firstspinnertext, String newText) {
		TextView textToChange = (TextView) rootView.findViewById(firstspinnertext);
		textToChange.setText(newText);
		
	}

	private void setSpinnerType(int spinner, int array) {

		Spinner spinnerToChange = (Spinner) rootView.findViewById(spinner);
		// Create an ArrayAdapter using the string array and a spinner layout
		ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(parentActivity.getBaseContext(),
		        array, R.layout.compare_spinner_additional);
		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinnerToChange.setAdapter(adapter);
		
	}

}
