using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;
    
    [SerializeField] TextMeshProUGUI recordText;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
        recordText.text = "Record " + gameManager.darNomeRecord() + ":" + gameManager.darPunteggioRecord();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Clickstart()
    {
        string inizio = GameObject.Find("Giocatore").GetComponent<TextMeshProUGUI>().text;

        if(inizio != "")
        {
            gameManager.Giocatore(inizio);
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
       
    }

    public void ClickExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        


    }
}
