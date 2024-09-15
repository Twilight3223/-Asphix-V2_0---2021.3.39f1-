using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public GameObject newLevel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            newLevel.SetActive(true);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
        newLevel.SetActive(false);
    }
}
   
