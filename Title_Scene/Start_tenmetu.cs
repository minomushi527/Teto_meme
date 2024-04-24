using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_tenmetu : MonoBehaviour
{
    public GameObject start_moji;
    private float time;
    private bool active;
    public float tenmetutime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
            if (time >= tenmetutime)
            {
                start_moji.gameObject.SetActive(false);
                active = false;
                time = 0;
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time >= tenmetutime)
            {
                start_moji.gameObject.SetActive(true);
                active = true;
                time = 0;
            }
        }
    }
}
