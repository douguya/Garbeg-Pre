using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mark : MonoBehaviour
{
    public GameObject MarkImage;

    public Sprite Cardboard;//段ボール
    public Sprite Paper;    //紙
    public Sprite Plastic;  //プラスチック
    public Sprite PET;      //ペットボトル
    public Sprite Steel;    //スチール
    public Sprite Aluminum; //アルミ
    public Sprite PaperPack;//紙パック

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
            case "段ボール":
                MarkImage.GetComponent<Image>().sprite = Cardboard;
                break;

            case "紙":
                MarkImage.GetComponent<Image>().sprite = Paper;
                break;
            case "プラスチック":
                MarkImage.GetComponent<Image>().sprite = Plastic;
                break;
            case "ペットボトル":
                MarkImage.GetComponent<Image>().sprite = PET;
                break;
            case "スチール":
                MarkImage.GetComponent<Image>().sprite = Steel;
                break;
            case "アルミ":
                MarkImage.GetComponent<Image>().sprite = Aluminum;
                break;
            case "紙パック":
                MarkImage.GetComponent<Image>().sprite = PaperPack;
                break;

            default:
                MarkImage.GetComponent<Image>().sprite = null;
                break;

        }

    }

}
