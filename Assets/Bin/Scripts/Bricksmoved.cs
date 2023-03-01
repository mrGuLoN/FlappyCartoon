using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricksmoved : MonoBehaviour
{
    private float _speed = 1f;
    private Transform _thisTR;
    private bool _up;
    void Start()
    {
        _thisTR = GetComponent<Transform>();
        if (_thisTR.position.y > 0) _up = false;
        else _up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_up == true)
        {
            _thisTR.position += Vector3.up * _speed * Time.deltaTime;
            if (_thisTR.position.y > 2.4f) _up = false;
        }
        else 
        {
            _thisTR.position -= Vector3.up * _speed * Time.deltaTime;
            if (_thisTR.position.y < -2.4f) _up = true;
        }
    }
}
