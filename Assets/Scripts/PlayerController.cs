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

    private int _karakterSeviyesi;

    private int _elmasSayisi;

    private int _kusakSayisi;

    private GameObject _player;

    private UIController _uiController;

    private int _toplananElmasSayisi;

    private int checkRadius = 2;





    void Start()
    {
        LevelStart();

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

        _karakterNumarasi = 0;
    }
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, 3, wallLayer))
        {
            _karakterAnimators[0].SetBool("isRunning", false);
            _karakterAnimators[0].SetBool("isPunch", true);
        }
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
                _karakterSeviyesi++;
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
        _karakterAnimators[0].SetBool("isRunning", true);
    }

}
