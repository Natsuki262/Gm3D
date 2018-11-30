using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class CreateMap : MonoBehaviour {
    [SerializeField]
    private int numA, numB;

    [SerializeField]
    private GameObject[] MapObject;

    [SerializeField]
    private float MapX, MapY;//マップの初期
    [SerializeField]
    private int MapRangeX, MapRangeY;//マップのブロック間の距離を表す変数
    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[,] textWords; //テキストの複数列を入れる2次元は配列 
    private int rowLength; //テキスト内の行数を取得する変数
    private int columnLength; //テキスト内の列数を取得する変数
    string[][] MapDate;//マップのデータを格納するジャグ配列
    string[] tempWords;
    private int num;
   
    private void Start()
    {
        MapDate = Enumerable.Repeat<string[]>((Enumerable.Repeat<string>("0", numA).ToArray()), numB).ToArray();
        Load();
        Create();
    }
    void Load()
    {
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("map", typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n'); //
       
        
        //行数と列数を取得
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2次配列を定義
        textWords = new string[rowLength, columnLength];
        
        for (int j = 0; j < rowLength; j++)
        {

           tempWords = textMessage[j].Split('\t'); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入

            for (int n = 0; n < columnLength; n++)
            {
                textWords[j, n] = tempWords[n]; //2次配列textWordsにカンマごとに分けたtempWordsを代入していく
                
            }
        }
        for (int i = 0; i < rowLength; i++) {
            MapDate[i] = textWords[i,0].Split(',');
                }
    }
    void Create()
    {

        //Debug.Log(rowLength);
        // Debug.Log(columnLength);
        foreach (string[] array in MapDate)
        {
            foreach (string s in array)
            {
                stringint(s);
                Instantiate(MapObject[num], new Vector3(MapX,1 , MapY), Quaternion.identity);
                MapX += MapRangeX;
            }
            MapY += MapRangeY;
            MapX = 0;
        }

    }
    void stringint(string a)
    {
        
        switch (a)
        {
            case "1":
                num = 1;
                break;
            case "2":
                num = 2;
                break;
            case "3":
                num = 3;
                break;
            case "4":
                num = 4;
                break;
            case "5":
                num = 5;
                break;
            case "6":
                num = 6;
                break;
            case "7":
                num = 7;
                break;
            case "8":
                num = 8;
                break;
            case "9":
                num = 9;
                break;
            case "0":
                num = 0;
                break;
        }
    }

}