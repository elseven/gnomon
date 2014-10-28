package watch.gnomon.app;

import android.content.Context;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

public class TextAdapter extends BaseAdapter {
	private Context mContext;
	String[] leaders = new String[]{"Abemelek","Justin","Elliot","Mark"};
	String[] leaderstat = new String[]{"100 pts","99 pts","40 pts","3 pts"};

	public TextAdapter(){
	}
	public TextAdapter(Context context){
		mContext = context;
	}
	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		View leaderView = convertView;
		if (convertView == null) { // if it's not recycled, initialize some attributes
			leaderView = new View(mContext);

        } else {
        		leaderView = (View) convertView;
        }
        LayoutInflater inflater = LayoutInflater.from(mContext);
        leaderView = inflater.inflate(R.layout.item_list,parent,false);

        LinearLayout parentContainer = ((LinearLayout) leaderView.findViewById(R.id.parentContainer));
        TextView name = ((TextView) leaderView.findViewById(R.id.leadername));
        name.setText(leaders[position]);
        name.setGravity(Gravity.CENTER);

        TextView stat = ((TextView) leaderView.findViewById(R.id.leaderStat));
        stat.setText(leaderstat[position]);
        stat.setGravity(Gravity.CENTER);
        return leaderView;
	}


}