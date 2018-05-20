using UnityEngine;
using System.Collections;

public class Enemy_Control : MonoBehaviour {

    Spaceship spaceship;
    public int point;

    void Start () {

        spaceship = GetComponent<Spaceship>();

        spaceship.Move(transform.up * -1);

        StartCoroutine("Shoot");

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            // All childs from objects 
             for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);
                 spaceship.Shot(shotPosition);
            }

            // shotDelay seconds
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }


    void OnTriggerEnter2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName != "Bullet Player") return;

        Destroy(c.gameObject);
        FindObjectOfType<Score>().AddPoint(point);
        spaceship.Explosion();
        Destroy(gameObject);
    }

}
