using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSUI : MonoBehaviour
{

    public GameObject bossPanel;
    public GameObject Puerta2;
    public static BOSSUI instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bossPanel.SetActive(false);
        Puerta2.SetActive(false);
    }
    public void BossActivator()
    {
        bossPanel.SetActive(true);
        Puerta2.SetActive(true);
    }
    public void BossDesactivador()
    {
        bossPanel.SetActive(false);
        Puerta2.SetActive(false);
    }
}
