using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private GameObject _bullet;
    private float _canFire = 0.5f;
    private float _fireRate = .5f;

    private CharacterController _playerController;
    private float _speed = 5f;
    private float _gravity = 1f;
    private float _jumpHeight = 15f;
    private float _yVelocity;

    private void Start()
    {
        _playerController = gameObject.GetComponent<CharacterController>();    
    }


    void FixedUpdate()
    {
        CalculateMovement();

        if (Input.GetKey(KeyCode.Space) && _canFire < Time.time)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_bullet, new Vector3(transform.position.x,transform.position.y,1), Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        

        

        if (_playerController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("up pressed");
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;



        _playerController.Move(velocity * Time.deltaTime);

        if (transform.position.x <= -2.3f)
        {
            transform.position = new Vector3(-2.3f, transform.position.y, 0);
        }
        else if (transform.position.x >= 2.3f)
        {
            transform.position = new Vector3(2.3f, transform.position.y, 0);
        }

    }


}
