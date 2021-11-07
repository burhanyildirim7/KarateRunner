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

    [SerializeField] private Slider _kusakSlider;

    [SerializeField] private int _levelAtlamakIcinGerekenKusakSayisi;

    [SerializeField] private List<Animator> _karakterAnimators = new List<Animator>();

    [SerializeField] private LayerMask wallLayer;

    private int _karakterNumarasi;

    private int _karakterSeviyesi=0;

    private int _elmasSayisi;

    private int _kusakSayisi;

    private GameObject _player;

    private UIController _uiController;

    private int _toplananElmasSayisi;

    private int checkRadius = 4;





    void Start()
    {
        LevelStart();

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

        _karakterNumarasi = 0;
    }
    private void Update()
    {
        Debug.Log(_karakterSeviyesi);
        if (Physics.CheckSphere(transform.position, checkRadius, wallLayer))
        {
            //_karakterAnimators[_karakterSeviyesi].SetBool("isRunning", false);
            _karakterAnimators[_karakterSeviyesi].SetBool("isAttack", true);
            StartCoroutine(nameof(endAttackAnimation));
        }
    }
    IEnumerator endAttackAnimation()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        _karakterAnimators[_karakterSeviyesi].SetBool("isAttack", false);

    }

    private void OnCollisionEnter(Collision collision)
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
            _kusakSayisi++;
            if (_kusakSayisi % _levelAtlamakIcinGerekenKusakSayisi == 0)
            {
                _karakterAnimators[_karakterSeviyesi].gameObject.SetActive(false);
                _karakterSeviyesi++;
                _karakterAnimators[_karakterSeviyesi].gameObject.SetActive(true); 
                _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", true);

            }
            _kusakSlider.value = _kusakSayisi % _levelAtlamakIcinGerekenKusakSayisi;
            Destroy(collision.gameObject);
        }

    }

    private void WinScreenAc()
    {
        _uiController.WinScreenPanelOpen();
    }

    private void LoseScreenAc()
    {
        _uiController.LoseScreenPanelOpen();
    }
    public void LevelStart()
    {
        _toplananElmasSayisi = 1;
        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");
        _karakterPaketi.transform.position = new Vector3(0, 0, 0);
        _karakterPaketi.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player = GameObject.FindWithTag("Player");
        _player.transform.localPosition = new Vector3(0, 0.5f, 0);
    }

    public void RunningAnimationTrue()
    {
        _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", true);
    }

}
