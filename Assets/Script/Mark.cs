using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mark : MonoBehaviour
{
    public GameObject MarkImage;

    public Sprite Cardboard;//�i�{�[��
    public Sprite Paper;    //��
    public Sprite Plastic;  //�v���X�`�b�N
    public Sprite PET;      //�y�b�g�{�g��
    public Sprite Steel;    //�X�`�[��
    public Sprite Aluminum; //�A���~
    public Sprite PaperPack;//���p�b�N

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeMark(string str)
    {
        switch (str) 
        {
            case "�i�{�[��":
                MarkImage.GetComponent<Image>().sprite = Cardboard;
                break;

            case "��":
                MarkImage.GetComponent<Image>().sprite = Paper;
                break;
            case "�v���X�`�b�N":
                MarkImage.GetComponent<Image>().sprite = Plastic;
                break;
            case "�y�b�g�{�g��":
                MarkImage.GetComponent<Image>().sprite = PET;
                break;
            case "�X�`�[��":
                MarkImage.GetComponent<Image>().sprite = Steel;
                break;
            case "�A���~":
                MarkImage.GetComponent<Image>().sprite = Aluminum;
                break;
            case "���p�b�N":
                MarkImage.GetComponent<Image>().sprite = PaperPack;
                break;

            default:
                MarkImage.GetComponent<Image>().sprite = null;
                break;

        }

    }

}
