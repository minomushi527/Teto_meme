using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetoChange : MonoBehaviour
{
    private float time;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Debug.Log(count + "time" + time);
            count++;
        }
    }
}