using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class anaMenuKontrol : MonoBehaviour {
    public GameObject leveller, canvas;
    public Sprite smallarea;
    GameObject locks;
    
	void Start () {
        
      

       
        
	}
    public void ButonSec(int gelenbuton)
    {
        if (gelenbuton == 1)
        {
            if (PlayerPrefs.GetInt("kacincilevel") < 1)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("kacincilevel"));
            }
        }
        if (gelenbuton == 2)
        {
            canvas.transform.GetChild(4).gameObject.SetActive(true);

            for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
            {
                leveller.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }

            for (int i = 0; i < leveller.transform.childCount; i++)
            {
                if (leveller.transform.GetChild(i).GetComponent<Button>().interactable == true)
                {
                    leveller.transform.GetChild(i).GetComponent<Image>().sprite = smallarea;
                    leveller.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                }
            }

        }
        if(gelenbuton == 3)
        {
            canvas.transform.GetChild(4).gameObject.SetActive(false);
        }
        if (gelenbuton == 666)
        {
            Application.Quit();
        }
     
    }

    public void LevellerButon(int gelenLevel)
    {
        SceneManager.LoadScene(gelenLevel);
    }

}
