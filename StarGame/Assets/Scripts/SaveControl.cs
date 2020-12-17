using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveControl : MonoBehaviour
{

    public string Username_;

    public List<Record> records = new  List<Record>();
    string path;

    void Start(){
        path = Application.persistentDataPath + "/states.txt";
    }

    // Start is called before the first frame update
    public void GetRecordsPrivate(){
        records = new  List<Record>();
        try{
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    Username_ = reader.ReadString();
                    while (reader.PeekChar() > -1)
                    {
                        string username = reader.ReadString();
                        int score = reader.ReadInt32();
                        records.Add(new Record(username, score));
                    }
                }
        }
        catch (System.Exception) {}
    } 

    public void writeUser(string username){
        
        
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(username);

                foreach (Record record in records){
                    writer.Write(record.username);
                    writer.Write(record.score); 
                } 
            }
    }
    public string getUser(){
         using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    return reader.ReadString();
                   
                }
       
    }


    public void writeRecord(int score){
        string username = getUser();
        // создаем объект BinaryWriter
        GetRecordsPrivate();
        bool b = false;
        List<Record> records2 = new  List<Record>();
        foreach(Record record in records){

            if (record.username == username){
                if(record.score < score) records2.Add(new Record(username, score));
                b = true;
                break;
            }
            else{
                records2.Add(record);
            }
        }
        if(b==false) records2.Add(new Record(username, score));
        records = records2;
        
        
        try
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(username);

                foreach (Record record in records2){
                    writer.Write(record.username);
                    writer.Write(record.score); 
                } 
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        
    }
}
