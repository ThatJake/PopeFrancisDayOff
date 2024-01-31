using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private void Start() 
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //when player reaches trigger plays sound and completes level
    {
        if (collision.CompareTag("Player"))
        {
            finishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel() // completing level -> naxt scene is loaded
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }


}
