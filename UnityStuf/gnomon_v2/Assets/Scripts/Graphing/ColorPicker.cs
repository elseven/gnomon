using UnityEngine;
using System.Collections;

public class ColorPicker
{
		ColorWrapper[] ColorArray = new ColorWrapper[10];

		public ColorPicker ()
		{
				ColorArray [0] = new ColorWrapper (new Color (0f, .1f, 0f));
				ColorArray [1] = new ColorWrapper (new Color (0f, 0f, 1f));
				ColorArray [2] = new ColorWrapper (new Color (0f, .3f, 0.3f));
				ColorArray [3] = new ColorWrapper (new Color (0f, .6f, 0.8f));
				ColorArray [4] = new ColorWrapper (new Color (0f, .7f, 0.1f));
				ColorArray [5] = new ColorWrapper (new Color (0f, .8f, 0.4f));
				ColorArray [6] = new ColorWrapper (new Color (0f, 1f, 1f));
				ColorArray [7] = new ColorWrapper (new Color (0f, .3f, 0.7f));
				ColorArray [8] = new ColorWrapper (new Color (0f, 0f, 0.45f));
				ColorArray [9] = new ColorWrapper (new Color (0f, .5f, 0.1f));
				
		}
		
		public ColorWrapper GetColorWrapperAt (int index)
		{
				return ColorArray [index % 10];
		}
	
	
}
