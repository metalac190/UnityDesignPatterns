using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.TemplateMethod
{
	public class CameraFollow : MonoBehaviour
	{
		[SerializeField] GameObject _player;
		Vector3 _offset;

		void Start()
		{
			_offset = transform.position - _player.transform.position;
		}

		void LateUpdate()
		{
			transform.position = _player.transform.position + _offset;
		}
	}
}

