using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public GameObject teto;
    private bool state = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            if (Input.GetMouseButton(0))
            {
                // state = false;
                teto.transform.localScale = Vector3.one * 0.98f;
                state = false;
            }
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                teto.transform.localScale = Vector3.one / 0.98f;
                state = true;
            }
        }
    }
}

