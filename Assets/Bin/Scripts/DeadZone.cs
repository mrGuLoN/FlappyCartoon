using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public delegate void DeadZ();
    public static event DeadZ _deadZ;
   

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _deadZ();       
    }
}
