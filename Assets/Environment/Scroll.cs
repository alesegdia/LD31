using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scroll : MonoBehaviour {

	public Vector2 times = new Vector2(0,0);
    public GameObject scrolledSprite;
    public Vector2 speed = new Vector2(3, 0);
    private Vector2 offset = new Vector2(0,0);
    private List<GameObject> instances = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for( int x = 0; x < times.x; x++ )
        {
			for( int y = 0; y < times.y; y++ )
            {
				Vector3 off = new Vector3( scrolledSprite.renderer.bounds.size.x * x, scrolledSprite.renderer.bounds.size.y * y, 0 );
                instances.Add(((GameObject)Instantiate(scrolledSprite, this.transform.position + off, Quaternion.identity)));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		foreach( GameObject inst in instances )
        {
			offset += speed * Time.deltaTime;
			inst.renderer.material.SetTextureOffset("_MainTex", offset);
        }
	}
}
