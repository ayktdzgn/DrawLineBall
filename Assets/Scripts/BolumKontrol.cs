using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class BolumKontrol : MonoBehaviour {

   public GameObject canvas;
	
	void Start () {
        //PlayerPrefs.DeleteAll();
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

        if (gelenbuton ==5) { Application.OpenURL("https://play.google.com/store/apps/details?id=com.powersx.JGolf"); }//Jgolf
        if (gelenbuton ==6) { Application.OpenURL("https://play.google.com/store/apps/details?id=com.MillGames.JUBE"); }//Jube
        if (gelenbuton ==7) { Application.OpenURL("https://play.google.com/store/apps/details?id=com.MillGames.DefendTheKing"); }//KingDefense

    }
}
