﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    private List<GameObject> BabyJunk;
    private float Worth = 1;
    private GameObject Explosion;
    private StopTheGame gameEnd;

    /// <summary>
    /// Creates and returns a gameobject with junk script attached to it. Prefab should be only a 3D model. Nothing more, nothing less.
    /// </summary>
    /// <param name="_junkPrefab"></param>
    /// <param name="_explosionEffect"></param>
    /// <param name="_position"></param>
    /// <param name="_isChild"></param>
    /// <param name="_amountOfChildren"></param>
    /// <returns></returns>
    public static GameObject CreateJunk(GameObject _junkPrefab, GameObject _explosionEffect, Vector3 _position, bool _isChild, float _worth = 1, int _amountOfChildren = 0)
    {
        GameObject JunkObject = Instantiate(_junkPrefab, _position, Quaternion.Euler(0,0,0));

        Junk junk = JunkObject.AddComponent<Junk>() as Junk;
        Rigidbody rigidbody = JunkObject.GetComponent<Rigidbody>();
        if ( rigidbody == null) 
        {
             rigidbody= JunkObject.AddComponent<Rigidbody>() as Rigidbody;
        }
        JunkObject.AddComponent<BoxCollider>();
        JunkObject.layer = 10;
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        junk.gameEnd = FindObjectOfType<StopTheGame>();

        junk.Explosion = _explosionEffect;
        JunkObject.tag = "RadarObject";
        JunkObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        if (!_isChild) junk.CreateChildren(_junkPrefab, _explosionEffect, _position,_amountOfChildren);
        return JunkObject;
    }

    private void Update()
    {
        if (gameEnd!= null && gameEnd.Activated)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().rotation = Quaternion.identity;
        }
    }
    private void CreateChildren(GameObject _junkPrefab, GameObject _explosionEffect, Vector3 _position, int _amount)
    {
        float newWorth = Worth / _amount;
        for (int i = 0; i < _amount; i++)
        {
            BabyJunk.Add(CreateJunk(_junkPrefab, _explosionEffect, _position, true, newWorth));
        }
    }
    //TODO
    public void Explode()
    {

    }
    public float GetWorth()
    {
        return Worth;
    }
    public void SetWorth(float _value)
    {
        Worth = _value;
    }

}
