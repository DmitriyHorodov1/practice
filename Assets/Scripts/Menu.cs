using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image setup;
    int time;
    int train;
    
   
    public void Start()
    {
        setup.gameObject.SetActive(false);
      
    }
    public void OnTrainLevel()
    {

        string name = "SampleScene";
        Debug.Log("Loading" + name);
        SceneManager.LoadScene(name);

    }
    public void OnTimeLevel()
    {

        string name = "TimeScene";
        Debug.Log("Loading" + name);
        SceneManager.LoadScene(name);

    }
    public void OnExit()
    {
        Application.Quit();

    }
    public void gotomenu()
    {
        string name = "start";
        Debug.Log("Loading" + name);
        SceneManager.LoadScene(name);

    }
    // Настройки 
    public void Settings()
    {
        setup.gameObject.SetActive(true);
    }
    public void closeset()
    {
        setup.gameObject.SetActive(false);
    }
    public void deletData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Data reset complete");
        time = 0;
        train = 0;
        PlayerPrefs.SetInt("SavedScore", time);
        PlayerPrefs.SetInt("SavedInteger", train);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");

    }
    // справка
  
}
