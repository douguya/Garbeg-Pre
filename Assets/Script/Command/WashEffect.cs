using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WashEffect : MonoBehaviour
{
    public Sprite[] WE_Sprite;
    public Image Image;
    public  float count = 0;
    public float num;

    public bool a=false;
    // Start is called before the first frame update
    void Start()
    {
        Image = this.gameObject.GetComponent<Image>();
        Effect();
    }

    // Update is called once per frame
    void Update()
    {
      
        Debug.Log(num / WE_Sprite.Length + 1);

        if (count > num)
        {
            a = true;
        }
        
    }


    public void Effect()
    {
        StartCoroutine("Effect2");
    }


    public IEnumerator  Effect2()
    {
       
        int ImageNum = 0;

        count = 0;

      
        
         while (count < num)
        {

            yield return new WaitForSeconds(0.1f);
            count += 0.1f;
            if (count > (num / WE_Sprite.Length) * (ImageNum + 1))
            {


                Image.sprite = WE_Sprite[ImageNum];

                ImageNum += 1;
            }




         }

        yield return new WaitForSeconds(num / (WE_Sprite.Length+1));
        gameObject.SetActive(false);
        

    }



}
