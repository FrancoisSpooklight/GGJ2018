﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool _isContamined;
	public int _playerNumber;

	public bool _allowInput = true;
	public Color _playerColor;

	float _score;
	int _indexForMaterial = 0;

	public float Score {
		get { return _score; }
		set { _score = value; }
	}

	public int PlayerNumber {
		get { return _playerNumber;}
		set { _playerNumber = value;}
	}

	public void SetIsContamined(bool p_isSick) {
		int indexForMaterial = 0;

		if(p_isSick == _isContamined) return;
		_isContamined = p_isSick;

		if (_isContamined) {
			gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().materials [indexForMaterial].SetFloat (ResourcesData._shaderSickChannel, 1);
			GameObject g =  Resources.Load("IllParticle") as GameObject;
			Instantiate(g, transform);
			g.transform.position = g.transform.position;
		} else {
			gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().materials [indexForMaterial].SetFloat (ResourcesData._shaderSickChannel, 0);
		}
	}

	public void SetMaterial(string p_newMaterial) {
		Material[] materials = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials;
		materials[_indexForMaterial] = Resources.Load<Material>(p_newMaterial);
		gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().materials = materials;

		_playerColor = materials[_indexForMaterial].color;
	}
}
