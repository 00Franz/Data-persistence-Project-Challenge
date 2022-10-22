using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] string nomeGiocatore;
    [SerializeField] string nomeRecord = "";
    [SerializeField] int punteggioRecord = 0;
    

    //savedata
    [System.Serializable]
    class SaveData
    {
        //variabili che voglio salvare

        //heigh score

        public string nomeRecord;
        public int punteggioRecord;
        
    }

    public void Giocatore(string nome)
    {
        nomeGiocatore = nome;
    }

    public async void SaveNameAndHeighScore(int punteggio)
    {

        nomeRecord = nomeGiocatore;
        punteggioRecord = punteggio;

        SaveData data = new SaveData();
        data.nomeRecord = nomeGiocatore;
        data.punteggioRecord = punteggio;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        await Task.Yield();
    }

    //carica nuova giocata e ritrasforma save color in 
    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nomeRecord = data.nomeRecord;
            punteggioRecord = data.punteggioRecord;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecord();
        
    }

    public string darNome()
    {
        return nomeGiocatore;
    }

    public string darNomeRecord()
    {
        return nomeRecord;
    }

    public int darPunteggioRecord()
    {
        return punteggioRecord;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
