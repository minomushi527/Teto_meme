using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ステージ
public class BackgroundchangeToStage : MonoBehaviour
{
    private float time;
    public GameObject hoge;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        // if (time > 21.0 && time < 21.3)
        // {
        //     this.GetComponent<SpriteRenderer>().color = new Color32(100, 168, 133, 255);
        // }
        if (time > 65.0 && time < 65.3)
        {
            Destroy(hoge);
        }
    }
}
