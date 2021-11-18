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

    [SerializeField] private GameObject _sliderFill;

    [SerializeField] private List<Color> _sliderFillColors = new List<Color>();


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

    public static int _playerLevel;

    private int _oyunSonuXDegeri;

    private int _oyunSonuElmasDeger;


    void Start()
    {
        LevelStart();
        _karakterAnimators[_karakterSeviyesi].SetBool("isDead", false);

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

        _karakterNumarasi = 0;
        _toplananKusakSayisi = 0;
        _playerLevel = 0;
        _toplananElmasSayisi = 1;

        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");


    }
    private void Update()
    {


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
        else
        {
            //_playerLevel = _toplananKusakSayisi * kusakLevelCarpani;
        }

        if (_playerLevel > 0)
        {
            _playerLevel = _toplananKusakSayisi * kusakLevelCarpani;
        }
        else
        {

        }


        if (_kusakSlider.value <= 2)
        {
            _sliderFill.GetComponent<Image>().color = _sliderFillColors[0];
        }
        else if (_kusakSlider.value > 2 && _kusakSlider.value <= 4)
        {
            _sliderFill.GetComponent<Image>().color = _sliderFillColors[1];
        }
        else if (_kusakSlider.value > 4 && _kusakSlider.value <= 6)
        {
            _sliderFill.GetComponent<Image>().color = _sliderFillColors[2];
        }
        else if (_kusakSlider.value > 6 && _kusakSlider.value <= 8)
        {
            _sliderFill.GetComponent<Image>().color = _sliderFillColors[3];
        }
        else if (_kusakSlider.value > 8 && _kusakSlider.value <= 10)
        {
            _sliderFill.GetComponent<Image>().color = _sliderFillColors[4];
        }
        else
        {

        }


        karakterLevelText.text = "Lv. " + _playerLevel.ToString();
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Elmas")
        {
            _elmasSayisi += 1;
            _toplananElmasSayisi += 1;
            PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Kusak")
        {
            if (_playerLevel < 99)
            {
                _toplananKusakSayisi++;

                _playerLevel = _toplananKusakSayisi * kusakLevelCarpani;

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

            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "X1")
        {
            _oyunSonuXDegeri = 1;

            if (_playerLevel >= 0 && _playerLevel < 10)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X2")
        {
            _oyunSonuXDegeri = 2;

            if (_playerLevel >= 10 && _playerLevel < 20)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X3")
        {
            _oyunSonuXDegeri = 3;

            if (_playerLevel >= 20 && _playerLevel < 30)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X4")
        {
            _oyunSonuXDegeri = 4;

            if (_playerLevel >= 30 && _playerLevel < 40)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X5")
        {
            _oyunSonuXDegeri = 5;

            if (_playerLevel >= 40 && _playerLevel < 50)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X6")
        {
            _oyunSonuXDegeri = 6;

            if (_playerLevel >= 50 && _playerLevel < 60)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X7")
        {
            _oyunSonuXDegeri = 7;

            if (_playerLevel >= 60 && _playerLevel < 70)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X8")
        {
            _oyunSonuXDegeri = 8;

            if (_playerLevel >= 70 && _playerLevel < 80)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X9")
        {
            _oyunSonuXDegeri = 9;

            if (_playerLevel >= 80 && _playerLevel < 90)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }

        }
        else if (other.gameObject.tag == "X10")
        {
            _oyunSonuXDegeri = 10;

        }
        else if (other.gameObject.tag == "BitirmeCizgisi")
        {
            if (_playerLevel >= 90)
            {
                GameController._oyunAktif = false;
                WinScreenAc();
            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "FinishLevel")
        {
            GameController._finishlevel = true;
            _karakterPaketi.transform.position = new Vector3(0, 0, _karakterPaketi.transform.position.z);
            _player.transform.localPosition = new Vector3(0, 0.5f, 0);

        }
        else
        {

        }

    }

    private void OyunSonuElmasHesaplama()
    {
        _oyunSonuElmasDeger = 0;
        //_elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");
        _oyunSonuElmasDeger = (_oyunSonuXDegeri * _toplananElmasSayisi);
        //_oyunSonuElmasDeger = _elmasSayisi;
        //PlayerPrefs.SetInt("OyunSonuElmasDeger", _oyunSonuElmasDeger);
        //PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);

        _uiController.LevelSonuElmasSayisi(_oyunSonuElmasDeger);
    }

    private void WinScreenAc()
    {
        _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", false);
        _karakterAnimators[_karakterSeviyesi].SetBool("isIdle", true);
        OyunSonuElmasHesaplama();
        _uiController.WinScreenPanelOpen();
    }

    private void LoseScreenAc()
    {
        // _karakterAnimators[_karakterSeviyesi].SetBool("isRunning", false);
        // _karakterAnimators[_karakterSeviyesi].SetBool("isDead", true);
        OyunSonuElmasHesaplama();
        _uiController.LoseScreenPanelOpen();
    }
    public void LevelStart()
    {
        GameController._finishlevel = false;
        _toplananElmasSayisi = 1;
        _toplananKusakSayisi = 0;
        _oyunSonuXDegeri = 0;
        _playerLevel = 0;
        _kusakSlider.value = 0;
        _karakterAnimators[_karakterSeviyesi].gameObject.SetActive(false);
        _karakterSeviyesi = 0;
        _karakterAnimators[_karakterSeviyesi].gameObject.SetActive(true);
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
