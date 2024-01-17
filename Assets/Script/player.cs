using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Transform transform;
    public float speed, jumpPow;

    bool left = false, right = false, jump = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Va cham voi: " + other.gameObject.tag);
        if (other.gameObject.tag == "BackGound")
        {
            jump = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) left = true;
        if (Input.GetKeyUp(KeyCode.LeftArrow)) left = false;
        if (Input.GetKeyDown(KeyCode.RightArrow)) right = true;
        if (Input.GetKeyUp(KeyCode.RightArrow)) right = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump) rigidbody2D.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
            jump = false;
        }

        if (left)
        {
            rigidbody2D.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (right)
        {
            rigidbody2D.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
