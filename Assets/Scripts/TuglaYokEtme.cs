using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuglaYokEtme : MonoBehaviour
{
    public static bool yoketme;
    void Start()
    {
        yoketme = false;
    }

    // Update is called once per frame

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Duvar")
        {
            yoketme = true;
        }
    }
}
