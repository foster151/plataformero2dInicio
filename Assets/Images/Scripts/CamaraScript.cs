using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public float duration = 1.5f, magnitud = 1.5f;
    public GameObject Personaje;
    public Vector2 minCamPos, maxCamPos;
    public Vector2 minCamPos2, maxCamPos2;
    public Vector2 minCamPos3, maxCamPos3;
    public float smoothTime;

    private Vector2 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, Personaje.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, Personaje.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(posX,minCamPos.x,maxCamPos.x), Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float posX = Mathf.SmoothDamp(transform.position.x, Personaje.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, Personaje.transform.position.y, ref velocity.y, smoothTime);
            transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), transform.position.z);
        }
    }

    public IEnumerator Shake()
    {
        Vector3 orinalPosition = transform.localPosition;
        float elpsed = 0f;
        while (elpsed<duration)
        {
            float x = Random.Range(-1f, 1f) * magnitud;
            float y = Random.Range(-1f, 1f) * magnitud;

            transform.localPosition = new Vector3(orinalPosition.x + x, orinalPosition.y + y, orinalPosition.z);
            elpsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = orinalPosition;
    }
}
