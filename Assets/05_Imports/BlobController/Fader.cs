using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

	Renderer rend;
	Material currentMat;
	public float colorFadeTime;
	public float shrinkSpeed;
	public Color startColor;
	public Color endColor;
	bool done;
	float t;

	void Start () {

		rend = GetComponent<Renderer> ();
		currentMat = rend.material;
		//currentMat.color = startColor;
	}


	void FixedUpdate () {
		
			t += colorFadeTime;

			currentMat.color = Color.Lerp (currentMat.color, endColor, t);

			if (transform.localScale.z > 0) {
				transform.localScale -= new Vector3 (shrinkSpeed, shrinkSpeed, shrinkSpeed);

			}
			if (transform.localScale.z < 0.0001f) {
				Destroy (gameObject);
			}
	}
}
