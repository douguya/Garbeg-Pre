using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage_Generation : MonoBehaviour
{

    public List< GameObject> GenerationPoint;//���݂̐����_

    public GameObject[] Trash_Warehouse;//�������邲�݂̃��X�g

    public int num;


    // Start is called before the first frame update
    void Start()
    {
        G_Point_Catch();//�����_����荞��
        Generat();//����
    }




    void Update()
    {

    }

    public void G_Point_Catch()//�����_����荞��
    {

        int num=0;
        foreach (Transform Obj in transform)
        {
            GenerationPoint.Add(  Obj.gameObject);

                num++;
        }
        PointManager.Max = num;
    }

    public void Generat()//���݂̐����@���݂̐��������_��������Ă���ꍇ
    {
       var Standard_Trashs = GameObject.FindWithTag("Standard_Trashs");//���荞�ސe���擾
        for (int loop=0;loop< GenerationPoint.Count;loop++)//���݂̐����_�̂Ԃ��
        {
            int rand = Random.Range(0, Trash_Warehouse.Length);//�����_���ł��݂��擾
            Instantiate(Trash_Warehouse[rand],GenerationPoint[loop].transform.position, Quaternion.identity, Standard_Trashs.transform);//�����_���Ȃ��݂��@���Ԓʂ�̐����_�ցA�p�x0,0,0�ŁA�ݒ肵���e�̎q�Ƃ��Đ���
        }


    }


    public void GGG()
    {
        var Standard_Trashs = GameObject.FindWithTag("Standard_Trashs");//���荞�ސe���擾
        Instantiate(Trash_Warehouse[num], GenerationPoint[0].transform.position, Quaternion.identity, Standard_Trashs.transform);
    }
   
}
