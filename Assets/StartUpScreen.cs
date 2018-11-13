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
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Space))
        {
                SceneManager.LoadScene("ConnectionScreen");
=======
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene("PlayerCount");
            }
>>>>>>> 96d2ba2af1a234019317f93b29ae05384d60fd1c
        }
        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //    {
        //        SceneManager.LoadScene("ConnectionScreen");
        //    }
        //}
    }
}
