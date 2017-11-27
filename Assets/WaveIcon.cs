using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIcon : MonoBehaviour
{
	private float _waveCd;
	private Vector3 target;
	private int _originalWaveNum;
	private Vector3 originalPos;
	
	// Use this for initialization
	void Start () {
		_waveCd = Assets.Code.Spawning.WaveCd;
		target = new Vector3(transform.position.x + 10000f, transform.position.y, transform.position.z);
		_originalWaveNum = Assets.Code.Spawning.wave;
		originalPos = new Vector3(34f, 37f, 8.8f);
		transform.position = originalPos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		int _waveNum = Assets.Code.Spawning.wave;
		if (_waveNum != _originalWaveNum)
		{
			transform.position = originalPos;
			_originalWaveNum = _waveNum;
		}
		else
		{
			float step = (800f / _waveCd) * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);

			if (transform.position.x > target.x - 10f)
			{
				transform.position = originalPos;
				return;
			}	
		}
	}
}
