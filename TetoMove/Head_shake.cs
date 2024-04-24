using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_shake : MonoBehaviour
{
	private bool state = true; //trueは入力受付中
	public float speed = 1f;
	private Vector3 syokiti;
	public int shake = 50;
	private float time = 0;
	// Start is called before the first frame update
	void Start()
	{
		syokiti = this.transform.localPosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (state)
		{
			if (Input.GetMouseButton(0) || time != 0)
			{
				// state = false;
				Vector3 movement = new Vector3(0f, -0.03f * Time.deltaTime * shake, 0f);
				transform.Translate(movement);
				time += Time.deltaTime;
				if (time > 0.08)
				{
					state = false;
				}
			}
		}
		else
		{
			if (!Input.GetMouseButton(0))
			{
				Vector3 movement = new Vector3(0f, 0.05f * Time.deltaTime * shake, 0f);
				transform.Translate(movement);
				if (this.transform.localPosition.y >= syokiti.y)
				{
					state = true;
					time = 0;
				}
			}
		}
	}
}
