using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject LevelMenu;
    public GameObject MainMenu;
    public GameObject Lvl1Btn;
    public GameObject Lvl2Btn;

    // Start is called before the first frame update
    void Start()
    {
        Lvl1Btn.SetActive(false);
        Lvl2Btn.SetActive(false);

    }

    public void ChoseLvl()
    {

        if (PlayerPrefs.HasKey("level"))
        {
            MainMenu.SetActive(false);
            LevelMenu.SetActive(true);

            switch (PlayerPrefs.GetInt("level"))
            {
                case 1:
                    Lvl1Btn.SetActive(true);
                    break;
                case 2:
                    Lvl1Btn.SetActive(true);
                    Lvl2Btn.SetActive(true);
                    break;
                case 3:
                    Lvl1Btn.SetActive(true);
                    Lvl2Btn.SetActive(true);
                    //space for next levels
                    break;
                default:
                    Lvl1Btn.SetActive(false);
                    Lvl2Btn.SetActive(false);
                    break;


            }
        }
        else
        {
            Debug.Log("there is no data about your progress");
        }
    }

}

