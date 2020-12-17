using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record{

    public string username;
    public int score;

    public Record(){}
    public Record(string username_, int score_){
        username = username_;
        score = score_;
    }

}

public class ScoreControl : MonoBehaviour
{
    
    public InputField username;
    public Text textError, Score, Username;

    SaveControl Save;

    

    void Start(){
        Save = FindObjectOfType<SaveControl>();
        
        Save.GetRecordsPrivate();
        username.text += Save.Username_;
        foreach (Record record in Save.records)
        {
            Username.text += record.username + "\n";
            Score.text += record.score + "\n";
        }

    }


    public void LoadMainGame()
    {
        if(username.text != ""){
            try
            {
                
                Save.writeUser(username.text);

                FindObjectOfType<Level>().LoadMainGame();
            }
            catch (System.Exception e)
            {
                textError.text = "" + e;
            }
            
        }
        else{
            textError.text = "Введите имя";
            Debug.Log(123);
        }
    }
    
}
