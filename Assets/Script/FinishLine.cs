using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            Invoke("restartScene", 3f);
        }
    }
    
    private void restartScene()
    {
        SceneManager.LoadScene(0);
    }
}
