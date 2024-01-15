using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Transform transform;
    float movePrefix = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log("Va cham voi: " + other.gameObject.tag);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        transform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(Vector2.up * movePrefix, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody2D.AddForce(Vector2.left * movePrefix, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody2D.AddForce(Vector2.right * movePrefix, ForceMode2D.Impulse);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
