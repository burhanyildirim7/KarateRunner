using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool _oyunAktif;

    public static bool _finishlevel;

    void Start()
    {
        _oyunAktif = false;
        _finishlevel = false;
    }


}
