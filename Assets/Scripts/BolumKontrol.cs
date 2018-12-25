using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BolumKontrol : MonoBehaviour {

   public GameObject canvas;
	
	void Start () {
		
	}

    public void ButonSec(int gelenbuton)
    {
        if(gelenbuton == 1)// pause
        {
            Time.timeScale = 0f;
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(1).GetChild(2).GetComponent<Button>().interactable = true;
        }

        if (gelenbuton == 2)// restart
        {
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            


        }
        if (gelenbuton == 3)// play
        {
            
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        if (gelenbuton == 4)// home
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
