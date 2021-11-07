using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuglaDavranis : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void IsKinematicOff()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile" || collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void Update()
    {
        if (TuglaYokEtme.yoketme==true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


}
