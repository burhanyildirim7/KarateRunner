using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
            GetComponent<Animator>().SetBool("isWalk", false);
            GetComponent<Animator>().SetBool("isPunch", true);
        }
    }
}

