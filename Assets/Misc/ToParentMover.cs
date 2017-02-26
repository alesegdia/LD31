using UnityEngine;
using System.Collections;

public class ToParentMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().MovePosition(this.transform.parent.position);
	}
}
