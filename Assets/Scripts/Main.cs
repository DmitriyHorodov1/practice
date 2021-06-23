using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{

    public GameObject CurrentCube;
    public GameObject LastCube;
    public GameObject Camera;
    public GameObject effect;
    public  TMP_Text text;
    public static int Level;
    public bool Done;
    public TMP_Text after_lose;
    public TMP_Text bestScore;
    public int bestlv;
    private int speed = 10;
    public Button button;

   [SerializeField] public GameObject music;
    

    // Use this for initialization
    void Start()
    {
       
        Level = 0;
        newBlock();
        text.gameObject.SetActive(false);
        after_lose.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        LoadGame();
        music.GetComponent<AudioSource>().enabled = true;

    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            bestlv = PlayerPrefs.GetInt("SavedInteger");

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    private void newBlock()

    {

        if (Level % 5 == 0)
        {
            speed += 2;
        }
        if (LastCube != null)
        {
            text.gameObject.SetActive(true);
            text.text = "Your Score " + Level;

            CurrentCube.transform.position = new Vector3(Mathf.Round(CurrentCube.transform.position.x ),
             CurrentCube.transform.position.y,
             Mathf.Round(CurrentCube.transform.position.z ));
            CurrentCube.transform.localScale = new Vector3(LastCube.transform.localScale.x - Mathf.Abs(CurrentCube.transform.position.x - LastCube.transform.position.x),
                                                           LastCube.transform.localScale.y,
                                                           LastCube.transform.localScale.z - Mathf.Abs(CurrentCube.transform.position.z - LastCube.transform.position.z));
            CurrentCube.transform.position = Vector3.Lerp(CurrentCube.transform.position, LastCube.transform.position, 0.5f) + Vector3.up * 0.5f;
           
            if (CurrentCube.transform.localScale.x <= 0f ||
               CurrentCube.transform.localScale.z <= 0f)
            {
                Done = true;
                
            
            }

        }
        LastCube = CurrentCube;
        CurrentCube = Instantiate(LastCube);
        CurrentCube.name = Level + "";
        CurrentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
        Level++;
        Camera.transform.position = CurrentCube.transform.position + new Vector3(21, 26, -39);
        Camera.transform.LookAt(CurrentCube.transform.position + Vector3.down * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Done )
        {
            After_lose();
            return;
        }
       

        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);

        var pos1 = LastCube.transform.position + Vector3.up * 1f;
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.right : Vector3.forward ) * speed; 
        var pos3 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * speed;

        if (Level % 2 == 0)
        {
            CurrentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
        }
        else
        {
             
            CurrentCube.transform.position = Vector3.Lerp(pos1, pos3, time);
        }


        if (Input.GetMouseButtonDown(0))
        {
            newBlock();
            Instantiate(effect, LastCube.transform.position, Quaternion.identity);
        }
    }

    void After_lose()
    {
        music.GetComponent<AudioSource>().enabled = false;

        after_lose.gameObject.SetActive(true);
        bestScore.gameObject.SetActive(true);
        if (Level > bestlv)
        {
            bestlv = Level;
            bestlv = bestlv - 1;

            PlayerPrefs.SetInt("SavedInteger", bestlv);
            PlayerPrefs.Save();
            Debug.Log("Game data saved!");
          
           
        }
        bestScore.text = "best score " + bestlv;
        after_lose.text = "Press Space to restart";
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
        button.gameObject.SetActive(true);
        
    }
    
}