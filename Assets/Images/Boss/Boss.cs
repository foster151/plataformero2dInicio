using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject Flame;
    public float timetoshoot, countdown;
    public float timetoTP, countdownTP;

    // Start is called before the first frame update
    void Start()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
        countdown = timetoshoot;
        countdownTP = timetoTP;
    }

    // Update is called once per frame
    void Update()
    {
        BossScale();
        countdown -= Time.deltaTime;
        countdownTP -= Time.deltaTime;
        if (countdown<0)
        {
            ShotPlayer();
            countdown = timetoshoot;
            
        }
        if (countdownTP <= 0)
        {
            countdownTP = timetoTP;
            Teleport();
        }
    }
    public void ShotPlayer()
    {
        GameObject spell = Instantiate(Flame, transform.position, Quaternion.identity);
    }
    public void Teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }
    public void BossScale()
    {
        if(transform.position.x> PersonajeMovimiento.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
