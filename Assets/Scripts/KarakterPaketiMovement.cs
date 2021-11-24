using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterPaketiMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _firstSpeed;

    void Start()
    {
        _firstSpeed = _speed;
    }


    void FixedUpdate()
    {
        if (GameController._oyunAktif == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else
        {

        }

    }

    public void KarakterHiziArtir()
    {
        _speed = _speed * 3;
    }

    public void KarakterHiziAzalt()
    {
        _speed = _firstSpeed;
    }

}
