using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Effect : MonoBehaviour
{
    public Sprite[] WE_Sprite;
    public Sprite MissSprite;
    public Image Image;
    public float count = 0;
    public float num;

    public bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {

      

    }


    public void Effect_1()
    {
        Image = this.gameObject.GetComponent<Image>();
        StartCoroutine("Effect2");
    }


    public IEnumerator Effect2()
    {

        int ImageNum = 0;

        count = 0;


        Debug.Log(777777777777777777);
        while (count < num)
        {
            Image.sprite = WE_Sprite[ImageNum];
            yield return new WaitForSeconds(0.1f);
            count += 0.1f;
            if (count > (num / WE_Sprite.Length) * (ImageNum + 1))
            {


                Image.sprite = WE_Sprite[ImageNum];

                ImageNum += 1;
            }




        }

        yield return new WaitForSeconds(num / (WE_Sprite.Length + 1));
        gameObject.SetActive(false);


    }

    public void MissEffect_1()
    {
        Image = this.gameObject.GetComponent<Image>();
        StartCoroutine("MissEffect2");
    }



    public IEnumerator MissEffect2()
    {

        

        count = 0;


        Image.sprite = MissSprite;
        while (count < num)
        {

            yield return new WaitForSeconds(0.1f);
            count += 0.1f;
         

               

          



        }

        yield return new WaitForSeconds(num / (WE_Sprite.Length + 1));
        gameObject.SetActive(false);


    }
}
