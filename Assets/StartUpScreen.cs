using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
          
        }
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("TEST");
                SceneManager.LoadScene("PlayerCount");
            }
        }
    }
}
