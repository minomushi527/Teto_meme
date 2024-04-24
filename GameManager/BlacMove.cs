using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//通常衣装
public class BlacMove : MonoBehaviour
{
    private float time;
    private float count;
    public Renderer hoge;
    private bool state = true; //trueは入力受付中
    public float speed = 1f;
    private Vector3 syokiti;
    private Vector3 closeiti;
    private Vector3 nowposi;
    public GameObject thisobj;
    public int shake = 50;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        count = 0;
        hoge.enabled = false;
        syokiti = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 54.0 && time < 54.3)
        {
            hoge.enabled = true;
        }
        if (time > 54.0 && time < 63.3)
        {
            if (state)
            {
                if (Input.GetMouseButton(0) || count != 0)
                {
                    // StartCoroutine(WaitProcess());
                    // state = false;
                    Vector3 movement = new Vector3(0f, 0.2f * Time.deltaTime * shake, 0f);
                    transform.Translate(movement);
                    count += Time.deltaTime;
                    if (count > 0.10)
                    {
                        state = false;
                        closeiti = this.transform.localPosition;
                    }
                }
            }
            else
            {
                if (!Input.GetMouseButton(0))
                {
                    // StartCoroutine(WaitProcess());
                    Vector3 movement = new Vector3(0f, -0.2f * Time.deltaTime * shake, 0f);
                    transform.Translate(movement);
                    if (this.transform.localPosition.y <= syokiti.y)
                    {
                        //Vector3 worldposi = teto.transform.TransformPoint(syokiti); //ローカル座標からワールド座標に変換
                        this.transform.localPosition = syokiti;
                        state = true;
                        count = 0;
                    }
                }
            }
        }
        if (time > 63.0 && time < 64.0)
        {
            nowposi = this.transform.localPosition;
            if (nowposi.y <= -6.7f)
            {
                Vector3 movement = new Vector3(0f, 0.2f * Time.deltaTime * shake, 0f);
                transform.Translate(movement);
            }
        }
        if (time > 64.5 && time < 65.0)
        {
            nowposi = this.transform.localPosition;
            if (nowposi.y <= -5.5f)
            {
                Vector3 movement = new Vector3(0f, 0.2f * Time.deltaTime * shake, 0f);
                transform.Translate(movement);
            }
        }
        if (time > 65.0 && time < 66.0)
        {
            Vector3 movement = new Vector3(0f, -0.5f * Time.deltaTime * shake, 0f);
            transform.Translate(movement);
        }
        if (time > 66.0)
        {
            Destroy(thisobj);
        }
    }
}
