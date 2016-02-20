using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public float rotate_sped;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(0, 0, rotate_sped * Time.deltaTime));
	}
}
