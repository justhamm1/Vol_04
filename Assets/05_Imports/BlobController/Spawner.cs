using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour {

	[Header("Spawner Attributes")]
	[Range(0.001f, 1)]
	public float spawnInterval = 0.05f;
	[Range( 0, 60)]
	public int quantity = 20;

	[Space]
	[Header("Movement Attributes")]
	public bool pingPongMovement;
	[Range( 0, 100)]
	public float xSpeed;
	[Range( 0, 100)]
	public float ySpeed;
	[Range( 0, 100)]
	public float zSpeed;
	[Range( 0.01f, 100)]
	public float xRange;
	[Range( 0.01f, 100)]
	public float yRange;
	[Range( 0.01f, 100)]
	public float zRange;

	[Space]
	[Header("Blob Attributes")]
	public Mesh mesh;
	public Mesh meshForCollision;
	public Vector3 startSize = new Vector3 (1, 1, 1);
	[Range( 0, 0.1f)]
	public float colorFadeTime = 0.05f;
	[Range(0.001f, 0.1f)]
	public float shrinkSpeed = 0.05f;
	[Range( 0, 100)]
	public float rigidbodyDrag = 30;

	[Space]
	[Header("Material Attributes")]
	public Material baseMaterial;
	public Color startColor;
	public Color endColor;
	public bool castShadows;
	public bool receiveShadows;
	[Range( 0, 1)]
	public float metallic;
	[Range( 0, 1)]
	public float smoothness;
	public Color emissionColor;

	void Start () {
		StartCoroutine (Spawn ());
	}
	void Update(){

		baseMaterial.SetFloat ("_Metallic", metallic);
		baseMaterial.SetFloat ("_Glossiness", smoothness);
		baseMaterial.SetColor ("_EmissionColor", emissionColor);

		if(pingPongMovement)
		transform.position = new Vector3(Mathf.PingPong(Time.time *xSpeed, xRange), Mathf.PingPong(Time.time *ySpeed, yRange), Mathf.PingPong(Time.time *zSpeed, zRange));
	}

	IEnumerator Spawn(){
		
		yield return new WaitForSeconds (spawnInterval);


		for (int i = 0; i < quantity; i++) {
			
			GameObject blob = new GameObject ();
			blob.transform.position = gameObject.transform.position;
			blob.transform.localScale = startSize;
			blob.transform.rotation = gameObject.transform.rotation;
			blob.AddComponent<MeshFilter> ().mesh = mesh;
			blob.AddComponent<MeshCollider> ().sharedMesh = meshForCollision;
			blob.GetComponent<MeshCollider> ().convex = true;
			blob.AddComponent<MeshRenderer> ().material = baseMaterial;
			blob.GetComponent<MeshRenderer> ().material.color = startColor;
			if(!castShadows) blob.GetComponent<MeshRenderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			else blob.GetComponent<MeshRenderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;			
			if(!receiveShadows) blob.GetComponent<MeshRenderer> ().receiveShadows = false;
			else blob.GetComponent<MeshRenderer> ().receiveShadows = true;			
			blob.AddComponent<Rigidbody> ().drag = rigidbodyDrag;
			blob.AddComponent<Fader> ().endColor = endColor;
			blob.GetComponent<Fader> ().startColor = startColor;
			blob.GetComponent<Fader> ().colorFadeTime = colorFadeTime;
			blob.GetComponent<Fader> ().shrinkSpeed = shrinkSpeed;

		}

		StartCoroutine (Spawn ());

	}
}
