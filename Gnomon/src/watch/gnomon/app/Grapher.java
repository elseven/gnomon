package watch.gnomon.app;

import java.util.ArrayList;

import com.jjoe64.graphview.BarGraphView;
import com.jjoe64.graphview.GraphView;
import com.jjoe64.graphview.GraphView.GraphViewData;
import com.jjoe64.graphview.GraphViewSeries;
import com.jjoe64.graphview.LineGraphView;

import android.content.Context;
import android.view.View;
import android.widget.LinearLayout;

public class Grapher {


	private Context context;
	private View view;
	/*new GraphViewData[] {
	    new GraphViewData(1, 2.0d)
	    , new GraphViewData(2, 1.5d)
	    , new GraphViewData(3, 2.5d)
	    , new GraphViewData(4, 1.0d)*/
	public Grapher(Context context, View view){
		this.context = context;
		this.view = view;
	}
	
	/*
	private LinearLayout plot(ArrayList<Integer> values){
		LinearLayout layout = new LinearLayout(context);
		GraphViewData[] data = new GraphViewData[values.size()];
		
		for(int i=0;i<values.size();i++){
			data[i]=new GraphViewData(i+0.0,values.get(i)+0.0);
			
		}


		// init example series data
		GraphViewSeries exampleSeries = new GraphViewSeries(data);

		GraphView graphView = new BarGraphView(
				this.context 
				, "GraphViewDemo" // heading
				);
		
		
		
		graphView.addSeries(exampleSeries); // data
		
		layout.addView(graphView);
		return layout;
	}*/
	
	public LinearLayout plot(ArrayList <ArrayList<Integer> > values){
		LinearLayout layout = new LinearLayout(context);

		GraphView graphView = new BarGraphView(
				this.context 
				, "GraphViewDemo" // heading
				);
		
		for(ArrayList<Integer> val : values){
			GraphViewData[] data = new GraphViewData[val.size()];
			
			for(int i=0;i<val.size();i++){
				data[i]=new GraphViewData(i+0.0,val.get(i)+0.0);
				
			}


			// init example series data
			GraphViewSeries exampleSeries = new GraphViewSeries(data);

			
			
			graphView.addSeries(exampleSeries); // data
		}
		
		
		layout.addView(graphView);
		return layout;
		
		
		
		
	}
}
