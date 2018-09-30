﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    Material _material;

	// Use this for initialization
	void Start () {
        _material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (_useBuffer)
        {
            //Orginal Code
            //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            transform.localScale = new Vector3((AudioPeer._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.y, transform.localScale.z);
            Color _color = new Color(AudioPeer._audioBandBuffer[_band] /2, AudioPeer._audioBandBuffer[_band] /2, AudioPeer._audioBandBuffer[_band] /2);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            //Orginal Code
            //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._audioBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            transform.localScale = new Vector3((AudioPeer._audioBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.y,  transform.localScale.z);
            Color _color = new Color(AudioPeer._audioBand[_band] / 2f, AudioPeer._audioBand[_band] /2f, AudioPeer._audioBand[_band] /2);
            _material.SetColor("_EmissionColor", _color);
        }


    }
}
