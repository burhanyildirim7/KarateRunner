using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterSecimiVeLevel : MonoBehaviour
{
    [SerializeField] GameObject KarakterGrubu;
    public int KarakterLeveli;
    public static int tempKarakterLevel;
    // Start is called before the first frame update
    void Start()
    {
        tempKarakterLevel = KarakterLeveli;
        if (KarakterLeveli<=20)
        {
            KarakterGrubu.transform.GetChild(0).gameObject.SetActive(true);
            KarakterGrubu.transform.GetChild(1).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(2).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(3).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(4).gameObject.SetActive(false);

        }
        else if (KarakterLeveli<=40)
        {
            KarakterGrubu.transform.GetChild(0).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(1).gameObject.SetActive(true);
            KarakterGrubu.transform.GetChild(2).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(3).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (KarakterLeveli <= 60)
        {
            KarakterGrubu.transform.GetChild(0).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(1).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(2).gameObject.SetActive(true);
            KarakterGrubu.transform.GetChild(3).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (KarakterLeveli <= 80)
        {
            KarakterGrubu.transform.GetChild(0).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(1).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(2).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(3).gameObject.SetActive(true);
            KarakterGrubu.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (KarakterLeveli <= 100)
        {
            KarakterGrubu.transform.GetChild(0).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(1).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(2).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(3).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(4).gameObject.SetActive(true);
        }

        else
        {
            KarakterGrubu.transform.GetChild(0).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(1).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(2).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(3).gameObject.SetActive(false);
            KarakterGrubu.transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
