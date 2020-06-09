using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {


	//Update is called every frame
	void Update () 
	{
		this.transform.Rotate (new Vector3 (0, 0, 1.0f));
	}
}
