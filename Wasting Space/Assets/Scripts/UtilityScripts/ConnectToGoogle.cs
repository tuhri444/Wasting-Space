﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToGoogle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Start"))
        {
            Sheets.ConnectToGoogle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
