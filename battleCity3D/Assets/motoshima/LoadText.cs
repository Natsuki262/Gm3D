using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class LoadText  :SingletonMonoBehaviour<LoadText>
{
    int leng;
    int[] map;
    private List<string> al = new List<string>();
    void Start()
    {
        string line = "";
        using (StreamReader sr = new StreamReader(
            "map", Encoding.GetEncoding("Shift_JIS")))
        {
            while ((line = sr.ReadLine()) != null)
            {
                al.Add(line);
                leng++;
            }
        }
        string[] memodate;
        memodate = al.ToArray();
        Debug.Log(memodate);
        string json = Resources.Load<TextAsset>("map").ToString();
        getTextFileData(json);
        
    }
    public static string[] getTextFileData(string aaaaaa)
    {
         
        string[] line = ((Resources.Load(aaaaaa, typeof(TextAsset)) as TextAsset).text).Split(char.Parse("\n"));
        
        string[] text = new string[line.Length];

        for (int i = 0; i <= line.Length; i++)
        {
            string[] SplitText = line[i].Split(char.Parse(","));
            text[Convert.ToInt32(SplitText[0])] = SplitText[1];
        }
        Debug.Log(text);
        return text;
    }
}
