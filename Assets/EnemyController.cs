using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public int enemyLevel;
    public Text enemyLevelText;

    [SerializeField] private bool _idleEnemy;
    [SerializeField] private bool _runningEnemy;

    private PlayerController playerController;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        enemyLevelText.text = enemyLevel.ToString();
    }
    private void Update()
    {
        enemyLevelText.gameObject.transform.parent.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enemyLevel > playerController._toplananKusakSayisi * playerController.kusakLevelCarpani)
        {
            transform.LookAt(other.transform);
            GetComponent<Animator>().SetBool("isWalk", false);
            GetComponent<Animator>().SetBool("isAttack", true);
            playerController._toplananKusakSayisi--;

            if (playerController._toplananKusakSayisi % playerController._levelAtlamakIcinGerekenKusakSayisi == 0 && playerController._toplananKusakSayisi > 0)
            {
                playerController._karakterAnimators[playerController._karakterSeviyesi].gameObject.SetActive(false);
                playerController._karakterSeviyesi--;
                playerController._karakterAnimators[playerController._karakterSeviyesi].gameObject.SetActive(true);

                playerController._karakterAnimators[playerController._karakterSeviyesi].SetBool("isRunning", true);


            }
            if (playerController._toplananKusakSayisi >= 0)
                playerController._kusakSlider.value = playerController._toplananKusakSayisi % playerController._levelAtlamakIcinGerekenKusakSayisi;
        }
        else
        {
            Invoke("EnemyDead", 0.5f);
            //EnemyDead();
        }
    }

    private void EnemyDead()
    {
        GetComponent<Animator>().SetBool("isWalk", false);
        GetComponent<Animator>().SetBool("isDead", true);
    }
}

