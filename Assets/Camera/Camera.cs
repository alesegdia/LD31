using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private int currentColor = 1;
	public Color[] colors;
	public float[] times;
    public Color initialColor;
    public Color finalColor;



	// Use this for initialization
	void Start () {
        initialColor = this.GetComponent<UnityEngine.Camera>().backgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
        float t = 0;
		for( int i = 1; i < times.Length-2; i++ )
        {
            t = times[i];
			if( Time.time < t )
            {
                //float lerpval = Time.time / t;
                float lerpval = (Time.time - times[i-1]) / ( t - times[i-1]);
                //Debug.Log(i + "lerp, " + lerpval); 
                this.GetComponent<UnityEngine.Camera>().backgroundColor = Color.Lerp(colors[i], colors[i + 1], lerpval);
				break;
			}
		}
	}
}
