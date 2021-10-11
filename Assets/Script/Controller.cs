using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private SurfaceEffector2D surfaceEffector2D;
    [SerializeField] private float torqueStat = 4.5f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        rotatePlayer();
        boostPlayer();
    }

    public void boostPlayer()
    {
        if (!CrashDetector.isCrashHead)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (surfaceEffector2D.speed < 55)
                    surfaceEffector2D.speed += 0.02f;
                else surfaceEffector2D.speed = 55;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (surfaceEffector2D.speed > 0)
                    surfaceEffector2D.speed -= 0.02f;
                else surfaceEffector2D.speed = 0;
            }
        }
    }

    public void rotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddTorque(torqueStat);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddTorque(-torqueStat);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
            if (CrashDetector.isCrashHead)
            {
                torqueStat = 0.1f;
                rigidbody2D.AddTorque(torqueStat);
            }
    }
}
