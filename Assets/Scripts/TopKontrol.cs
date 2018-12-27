using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour {

    public GameObject canvas;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("kacincilevel"))
        {
            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Diken")
        {
            Destroy(gameObject, 0f);
            
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(1).GetChild(2).GetComponent<Button>().interactable = false;
        }

        if(col.gameObject.tag == "Testere")
        {
            Destroy(gameObject, 0f);
            
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(1).GetChild(2).GetComponent<Button>().interactable = false;
        }

        if(col.gameObject.tag == "Lazer")
        {
            Destroy(gameObject, 0f);

            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(1).GetChild(2).GetComponent<Button>().interactable = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().buildIndex < 20)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
