using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Goals : MonoBehaviour
{
    public Image gold_time;
    public Image silver_time;
    public Image bronze_time;
    public Image gold_train;
    public Image silver_train;
    public Image bronze_train;
    public int score_train;
    public int score_time;



    void Start()
    {
        LoadGame(); 
    }
    //Time
   public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            score_time = PlayerPrefs.GetInt("SavedScore");
           

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
        //Tain
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            score_train = PlayerPrefs.GetInt("SavedInteger");
            

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    void Update()
    {
        LoadGame();
        //time
        if (score_time >= 30 )
        {
            gold_time.gameObject.SetActive(true);
        }
        else 
        {
            gold_time.gameObject.SetActive(false);
        }

        if (score_time >= 20 )
        {
            silver_time.gameObject.SetActive(true);
        }
        else 
        {
            silver_time.gameObject.SetActive(false);
        }

        if(score_time >= 10 ) {
            bronze_time.gameObject.SetActive(true);
        }
        else
        {
            bronze_time.gameObject.SetActive(false);
        }
        //trian
        if (score_train >= 30)
        {
            gold_train.gameObject.SetActive(true);
        }
        else
        {
            gold_train.gameObject.SetActive(false);
        }

        if (score_train >= 20)
        {
            silver_train.gameObject.SetActive(true);
        }
        else
        {
            silver_train.gameObject.SetActive(false);
        }

        if (score_train >= 10)
        {
            bronze_train.gameObject.SetActive(true);
        }
        else
        {
            bronze_train.gameObject.SetActive(false);
        }
    }
}
