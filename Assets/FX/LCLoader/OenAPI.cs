using UnityEngine;
using System.Collections;

public class OenAPI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// 这样子使用哦
    /// </summary>
    public void StartLoad()
    {
        LoadSceneManager._instance.StartCoroutine("LoadScene", "next");
    }
}
