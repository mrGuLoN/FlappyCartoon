using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksController : MonoBehaviour
{   
    public Transform _thisTR;
    private float _height;
    public BricksBilder bBilder;
    void Awake()
    {
        _thisTR = GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Moved(float speed, float timeDelta)
    {
        _thisTR.position += Vector3.right * speed * timeDelta;       
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void UpdateY()
    {
        _height = Random.Range(-2.4f, 2.4f);
        _thisTR.position = new Vector3(_thisTR.position.x, _height, _thisTR.position.z);
    }
}
