using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed = 8f;

    void Update()
    {
        transform.Translate(new Vector3(0 , 1, .75f) * _bulletSpeed * Time.deltaTime);
        if(transform.position.y > 18)
        {
            Destroy(gameObject);
        }
    }
    
}
