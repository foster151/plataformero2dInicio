using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEn1 : MonoBehaviour
{
    public CamaraScript CameraShake;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            CameraShake.duration = 0.2f;
            CameraShake.magnitud = 0.5f;
            StartCoroutine(CameraShake.Shake());
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
