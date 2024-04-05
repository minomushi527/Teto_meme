using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tufts : MonoBehaviour
{
    private bool state = true; //trueは入力受付中
    public float speed = 1f;
    private Vector3 syokiti;
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
            if (Input.GetMouseButton(0))
            {
                // state = false;
                transform.Rotate(0, 0, -50, Space.World);
                // transform.Rotate(0, 0, 50, Space.World);
                state = false;
            }
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                transform.Rotate(0, 0, 50, Space.World);
                // transform.Rotate(0, 0, 50, Space.World);
                if (this.transform.localPosition.y >= syokiti.y)
                {
                    state = true;
                }
            }
        }
    }
}
