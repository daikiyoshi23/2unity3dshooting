using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speedX;
    public float speedZ;
    public GameObject bullet;
    float bulletInterval;

    public GameObject enemy;
    float enemynterval;

    public GameObject explosion;

    Slider slider;
    int playerLife;

	// Use this for initialization
	void Start () {
        bulletInterval = 0.0f;

        enemynterval = 0.0f;

        playerLife = 3;

        slider = GameObject.Find("Slider").GetComponent<Slider>();
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
        enemynterval += Time.deltaTime;
        if(enemynterval >= 0.5f)
        {
            GenerateEnemy();
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

    void GenerateEnemy()
    {
        Quaternion q = Quaternion.Euler(0, 180, 0);
        enemynterval = 0.0f;

        Instantiate(enemy, new Vector3(Random.Range(-100, 100), transform.position.y, transform.position.z + 200), q);

        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 200), q);

    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "EnemyBullet")
        {
            playerLife--;

            slider.value = playerLife;
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(coll.gameObject);
            if (playerLife <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
