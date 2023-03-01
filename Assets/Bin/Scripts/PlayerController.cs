using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxForce, updateForce;
    private AudioSource _audio;
    private Rigidbody2D _rb;
    private Transform _thisTR;
    private float _currentForce, _lockX;
    public bool _inputJump, _live;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _thisTR = GetComponent<Transform>();
        _live = true;
        _currentForce = 0;
        _lockX = _thisTR.position.x;
        _audio = GetComponent<AudioSource>();
        DeadZone._deadZ += Dead;
    }

    // Update is called once per frame
    void Update()
    {
        if (_live == true)
        {
            PlayerUpForce();
        }
    }

    private void PlayerUpForce()
    {
        _thisTR.position = new Vector3(_lockX, _thisTR.position.y, _thisTR.position.z);
        if (Input.touchCount>0 && _currentForce <= maxForce)
        {
            _currentForce += updateForce * Time.deltaTime;
            _inputJump = true;
        }
        else if (_currentForce >= maxForce && _inputJump == true)
        {
            _rb.AddForce(Vector2.up * _currentForce, ForceMode2D.Impulse);
            _audio.Play();
            _inputJump = false;
        }
        else if (Input.touchCount == 0 && _currentForce <= maxForce && _inputJump == true)
        {
            _rb.AddForce(Vector2.up * _currentForce, ForceMode2D.Impulse);
            _audio.Play();
            _currentForce = 0;
            _inputJump = false;
        }
        else if (Input.touchCount == 0)
        {
            _inputJump = false;
            _currentForce = 0;
        }
    }

    public void Dead()
    {
        _rb.velocity = Vector2.zero;
        _rb.gravityScale = 0;
        _live = false;
    }
}
