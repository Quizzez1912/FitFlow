using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;


// Codebasis ist von https://www.youtube.com/watch?v=Wu4SGitck7M


public class SaveJSON : MonoBehaviour
{
   // public Slider levelSlider;
    private PlayerData playerData;
    private  PlayerData newPlayerData;
    


    // Start is called before the first frame update
    void Start()
    {
       playerData = PlayerData.Instance;

      

        
        //levelSlider.onValueChanged.AddListener(delegate { SaveData(); });
    }

    // Update is called once per frame
    void Update()
    {
     
        

    }
    

    // Speichern des Spielstandes
    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerData);
        Debug.Log("saved " + json);
        
        using(StreamWriter write = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json" )) { 
        
            write.Write(json);
        }
        
        
       
      
    }

    // Laden des Spielstandes
    public void LoadData()
    {
        string json = string.Empty;

        using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            json = reader.ReadToEnd();
        }

        Debug.Log("loaded save: " + json);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        playerData.SetPlayerData(data.playerLevel,data.xp, data.streak, data.rank, data.levelExc1, data.levelExc2, data.levelExc3, data.levelExc4, data.levelExc5);

    }

}
