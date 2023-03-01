using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    public delegate void OneScoreUp();
    public static event OneScoreUp _scoreUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _scoreUp();
        this.gameObject.SetActive(false);
    }

   

}
