﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eplode : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    Vector3 startPos;
    Quaternion startRot;
    Hull hull;
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        hull = GetComponent<Hull>();
    }

    //void Update()
    //{
    // if(Input.GetKey(KeyCode.Space))
    //    {
    //        transform.position = startPos;
    //        transform.rotation = startRot;
    //        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("asteroid"))
        {
            hull.hp -= (int)Random.Range(1,10);
            GameObject explosionObj = GameObject.Instantiate(explosion, transform.position, transform.rotation);
            GetComponent<Rigidbody>().AddExplosionForce(1f, transform.position, 1, 1, ForceMode.Impulse);
        }
    }
}