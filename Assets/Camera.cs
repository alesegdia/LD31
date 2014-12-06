using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private int currentColor = 0;
	public Color[] colors;
	public float[] times;
    public Color initialColor;
    public Color finalColor;



	// Use this for initialization
	void Start () {
        initialColor = this.camera.backgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
        float t = 0;
		for( int i = 0; i < times.Length-1; i++ )
        {
            t += times[i];
			if( Time.time < t )
            {
				this.camera.backgroundColor = Color.Lerp(colors[i], colors[i+1], Time.time / times[i]);
				break;
			}
		}
	}
}
