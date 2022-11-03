using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

[System.Serializable]
public class Node
{
    public string key;
    public string data;
}

[System.Serializable]
public class Nodes
{
    public List<Node> DataList = new List<Node>();
}

public class Bridge : MonoBehaviour
{

    private const string fileName = "/Bridge.txt";
    
    public Nodes nodes;

    public static Bridge Instance = null;

    private void Awake()
    {
        //Creates Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }            
    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        WriteData(JsonUtility.ToJson(nodes,true));
    }

    public string GetData(string key)
    {
        foreach (var item in nodes.DataList)
        {
            if(item.key == key)
            {
                return item.data;
            }
        }

        return "";
    }

    private void LoadData()
    {        
        var _data = File.ReadAllText(Application.streamingAssetsPath + fileName);        

        nodes = JsonUtility.FromJson<Nodes>(_data);
    }

    public void Initialize()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        if(!File.Exists(Application.streamingAssetsPath + fileName))
        {
            try
            {
                using (FileStream fs = File.Create(Application.streamingAssetsPath + fileName))
                {                    
                    fs.Write( new UTF8Encoding(true).GetBytes("{}"));
                }                
            }
            catch(IOException e)
            {
                Debug.LogError(e.Message);
            }            
        }

        LoadData();
    }

    private void WriteData(string datatowrite)
    {        
        File.WriteAllText(Application.streamingAssetsPath + fileName, datatowrite);
    }

}
