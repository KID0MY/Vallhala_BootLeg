using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Application.Quit();
        }
    }
}
