using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedX;
    public float speedZ;
    public GameObject bullet;
    float bulletInterval;

	// Use this for initialization
	void Start () {
        bulletInterval = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey("up"))
        {
            MoveToUp (vertical);
        }
        if (Input.GetKey("right"))
        {
            MoveToRight(horizontal);
        }
        if (Input.GetKey("left"))
        {
            MoveToLeft(horizontal);
        }
        if (Input.GetKey("down"))
        {
            MoveToBack(vertical);
        }

        bulletInterval += Time.deltaTime;
        if (Input.GetKey("space"))
        {
            if(bulletInterval >= 0.2f)
            {
                GenerateBullet();
            }
        }
	}

    void MoveToUp(float vertical)
    {
        transform.Translate(0, 0, vertical * speedZ);
    }

    void MoveToRight(float horizontal)
    {
        transform.Translate(horizontal * speedX, 0, 0);
    }

    void MoveToLeft(float horizontal)
    {
        transform.Translate(horizontal * speedX, 0, 0);
    }

    void MoveToBack(float vertical)
    {
        transform.Translate(0, 0, vertical * speedZ);
    }

    void GenerateBullet()
    {
        bulletInterval = 0.0f;
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
