﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillBar : MonoBehaviour
{
    private Animator animController;
    void Start()
    {
        animController = GetComponent<Animator>();
    }


    public void Pulse()
    {
        animController.SetTrigger("Pulse");
    }
}
