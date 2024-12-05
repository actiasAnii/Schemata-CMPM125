using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class singlinton : MonoBehaviour
{
    // Start is called before the first frame update
    private static singlinton singl;
    uint flags = 0;
    void Awake()
    {
        if (singl == null)
        {
            singl = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }

    void Start()
    {
        StreamReader bleh = new StreamReader("SaveData.txt");
        if (File.Exists("SaveData.txt"))
        {
            flags = uint.Parse(bleh.ReadLine());
        }
    }

    // Update is called once per frame
    public void UpdateSingl(uint flag)
    {
        flags |= flag;
    }

    public void SaveGameData()
    {
        FileStream Save = File.Create("SaveData.txt");
        StreamWriter blehg = new StreamWriter(Save.Name);
        blehg.WriteLine(flags.ToString());
        Save.Close();
    }

    public uint getFlag()
    {
        return flags;
    }
}
