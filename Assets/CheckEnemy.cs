using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Duvar")
        {
            playerController._karakterAnimators[playerController._karakterSeviyesi].SetBool("isAttack", true);
            StartCoroutine(nameof(endAttackAnimation));
        }
        if (other.tag == "Enemy" && other.gameObject.GetComponent<EnemyController>().enemyLevel <= playerController._toplananKusakSayisi * playerController.kusakLevelCarpani)
        {
            playerController._karakterAnimators[playerController._karakterSeviyesi].SetBool("isAttack", true);
            StartCoroutine(nameof(endAttackAnimation));
        }
    }
    IEnumerator endAttackAnimation()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        playerController._karakterAnimators[playerController._karakterSeviyesi].SetBool("isAttack", false);

    }

}
