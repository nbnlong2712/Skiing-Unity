using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashEffect;
    public static bool isCrashHead = false;
    private bool isBrokenHead = false;

    void Start()
    {
        isCrashHead = false;
        isBrokenHead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (!isBrokenHead)
            {
                isCrashHead = true;
                isBrokenHead = true;
                crashEffect.Play();
                collision.GetComponent<SurfaceEffector2D>().speed = -1;
                GetComponent<AudioSource>().Play();
                Invoke("restartScene", 5f);
            }
        }
    }

    private void restartScene()
    {
        SceneManager.LoadScene(0);
        isCrashHead = false;
        isBrokenHead = false;
    }
}
