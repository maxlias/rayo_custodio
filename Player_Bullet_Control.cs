using UnityEngine;
using System.Collections;

public class Player_Bullet_Control : MonoBehaviour {

    public int speed;
    public float lifeTime = 5;

    // Use this for initialization
    void Start () {

        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        Destroy(gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
