using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move_to_Start : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
