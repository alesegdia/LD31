using UnityEngine;
using System.Collections;

public class SinusMover : MonoBehaviour {

    public enum Type { X, Y, Z };
    public Type type;
    float pos;
    public float alpha = 1.0f;
    public float amplitude = 1.0f;
    public float offset = 0.0f;

	// Use this for initialization
	void Start () {
        
        pos = this.transform.position.y + offset;
	}

	void SetProperAxis(float val)
    {
        Vector3 pos = this.transform.localPosition;
		switch(type)
        {
            case Type.X: pos.x = val; break;
            case Type.Y: pos.y = val; break;
            case Type.Z: pos.z = val; break;
        }
        this.transform.localPosition = pos;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float delta = amplitude * Mathf.Sin(Time.time * alpha);
        SetProperAxis(pos + delta);
	}
}
