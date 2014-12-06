using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {


	// Use this for initialization
	void Start () {
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > 3.0f && this.renderer.material.color.a > 0 )
        {
            Color c = this.renderer.material.color;
            c.a -= 0.01f;
            this.renderer.material.color = c;
        }
	}
}
