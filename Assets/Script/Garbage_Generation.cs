using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage_Generation : MonoBehaviour
{

    public List< GameObject> GenerationPoint;//ごみの生成点

    public GameObject[] Trash_Warehouse;//生成するごみのリスト

    public int num;


    // Start is called before the first frame update
    void Start()
    {
        G_Point_Catch();//生成点を放り込む
        Generat();//生成
    }




    void Update()
    {

    }

    public void G_Point_Catch()//生成点を放り込む
    {

        int num=0;
        foreach (Transform Obj in transform)
        {
            GenerationPoint.Add(  Obj.gameObject);

                num++;
        }
        PointManager.Max = num;
    }

    public void Generat()//ごみの生成　ごみの数が生成点を下回っている場合
    {
       var Standard_Trashs = GameObject.FindWithTag("Standard_Trashs");//放り込む親を取得
        for (int loop=0;loop< GenerationPoint.Count;loop++)//ごみの生成点のぶん回す
        {
            int rand = Random.Range(0, Trash_Warehouse.Length);//ランダムでごみを取得
            Instantiate(Trash_Warehouse[rand],GenerationPoint[loop].transform.position, Quaternion.identity, Standard_Trashs.transform);//ランダムなごみを　順番通りの生成点へ、角度0,0,0で、設定した親の子として生成
        }


    }


    public void GGG()
    {
        var Standard_Trashs = GameObject.FindWithTag("Standard_Trashs");//放り込む親を取得
        Instantiate(Trash_Warehouse[num], GenerationPoint[0].transform.position, Quaternion.identity, Standard_Trashs.transform);
    }
   
}
