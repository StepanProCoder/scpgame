using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        int level;

        using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt", true))
        {

            level = System.Convert.ToInt32(reader.ReadLine());
            reader.Close();


        }

        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.txt", false))
        {
            level++;
            writer.WriteLine(level);
            writer.Close();
        }
    }

}
