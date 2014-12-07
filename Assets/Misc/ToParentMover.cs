using UnityEngine;
using System.Collections;

public class ToParentMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("---");
        this.rigidbody2D.MovePosition(this.transform.parent.position);
        Debug.Log(this.transform.position);
        Debug.Log(this.transform.parent.position);
	}
}
