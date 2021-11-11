using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private int _iyiToplanabilirDeger;

    [SerializeField] private int _kötüToplanabilirDeger;

    [SerializeField] private GameObject _karakterPaketi;


    private int _karakterNumarasi;

    private int _elmasSayisi;

    private GameObject _player;

    private UIController _uiController;

    private int _toplananElmasSayisi;


    public int _levelAtlamakIcinGerekenKusakSayisi;

    public int _toplananKusakSayisi;

    public int kusakLevelCarpani = 1;

    public List<Animator> _karakterAnimators = new List<Animator>();

    public int _karakterSeviyesi = 0;

    public Slider _kusakSlider;

    public Text karakterLevelText;

    private int _playerLevel;


    void Start()
    {
        LevelStart();
        _karakterAnimators[_karakterSeviyesi].SetBool("isDead", false);

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

        _karakterNumarasi = 0;
        _toplananKusakSayisi = 0;
        _playerLevel = 0;


    }
    private void Update()
    {
        _playerLevel = _toplananKusakSayisi * kusakLevelCarpani;
        karakterLevelText.text = "Lv " + _playerLevel.ToString();
        if (GameController._oyunAktif == true && _toplananKusakSayisi < 0)
        {
            GameController._oyunAktif = false;
            _playerLevel = 0;
            _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", false);
            //_karakterAnimators[_karakterSeviyesi].SetBool("isDead", true);
            //_karakterAnimators[_karakterSeviyesi].SetBool("isDead", false);
            Invoke("PlayerDeadAnimation", 0.5f);
            Invoke("LoseScreenAc", 2f);
        }
    }
    IEnumerator endAttackAnimation()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        _karakterAnimators[_karakterSeviyesi].SetBool("isAttack", false);

    }

    private void PlayerDeadAnimation()
    {
        _karakterAnimators[_karakterSeviyesi].SetBool("isDead", true);
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Elmas")
        {
            _elmasSayisi += 1;
            _toplananElmasSayisi += 1;
            PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Kusak")
        {
            if (_playerLevel < 100)
            {
                _toplananKusakSayisi++;
                if (_toplananKusakSayisi % _levelAtlamakIcinGerekenKusakSayisi == 0)
                {

                    _karakterAnimators[_karakterSeviyesi].gameObject.SetActive(false);
                    _karakterSeviyesi++;
                    _karakterAnimators[_karakterSeviyesi].gameObject.SetActive(true);
                    _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", true);
                }
                _kusakSlider.value = _toplananKusakSayisi % _levelAtlamakIcinGerekenKusakSayisi;
            }
            else
            {
                _playerLevel = 99;
            }

            Destroy(collision.gameObject);
        }

    }

    private void WinScreenAc()
    {
        _uiController.WinScreenPanelOpen();
    }

    private void LoseScreenAc()
    {
        // _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", false);
        // _karakterAnimators[_karakterSeviyesi].SetBool("isDead", true);
        _uiController.LoseScreenPanelOpen();
    }
    public void LevelStart()
    {
        _toplananElmasSayisi = 1;
        _toplananKusakSayisi = 0;
        _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", false);
        _karakterAnimators[_karakterSeviyesi].SetBool("isDead", false);
        _karakterAnimators[_karakterSeviyesi].SetBool("isIdle", true);
        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");
        _karakterPaketi.transform.position = new Vector3(0, 0, 0);
        _karakterPaketi.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player = GameObject.FindWithTag("Player");
        _player.transform.localPosition = new Vector3(0, 0.5f, 0);
    }

    public void RunningAnimationTrue()
    {
        _karakterAnimators[_karakterSeviyesi].SetBool("isIdle", false);
        _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", true);
    }

}
