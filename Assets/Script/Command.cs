using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Command : MonoBehaviour
{
    private Vector2 StartPosi;//Commandyの初期位置
    public Vector3 EndPosi;//Commandの最終位置
    private Vector3 velocity = Vector3.zero;//SmoothDampに必要な速度保存用の変数
    private float M_Time = 0.2f;//Small_Categoryの移動時間
    private int dist = 1;//Small_Categoryの最大許容距離


    public GameObject WCommand;//洗浄フィールド
    public GameObject DCommand;//分解フィールド

    public Sprite[] WSprite;//洗浄写真
    public Sprite[] DSprite;//分解写真

    GameObject SoundManager;//サウンドマネージャー
    public GameObject WEffect;//洗浄効果
    public GameObject DEffect;//分解効果

    public GameObject W_Rite;//洗浄フィールドのあかるい
    public GameObject D_Rite;//分解フィールドのあかるい

    

    public bool Move = false;//Commandを動かすためのトリガー
    public bool Sink = false;//Commandを反対に動かすためのトリガー
    // Start is called before the first frame update
    void Start()
    {
        StartPosi = GetComponent<RectTransform>().anchoredPosition;


    }

    // Update is called once per frame
    void Update()
    {



        if (Move == true&& Sink == false)//作動許可
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndPosi.x, EndPosi.y)).magnitude < dist && Move == true)////Small_Categoryの最大許容距離まで到達したら、作動許可取り消し
        {
            Debug.Log("LLLLLLLLLLLLLLLLLLL");
            CanCommand();//コマンド動作可能
            Move = false;
        }
        if (Sink == true && Move == false)//作動許可
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, StartPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(StartPosi.x, StartPosi.y)).magnitude < dist && Sink == true)////Small_Categoryの最大許容距離まで到達したら、作動許可取り消し
        {
            CanNotCommand();
            Sink = false;
        }

    }

    

    public void CanCommand()//分解・洗浄コマンドを実行可能状態にする
    {
        WCommand.GetComponent<Image>().sprite = WSprite[1];//画像を相応のものにする、
        DCommand.GetComponent<Image>().sprite = DSprite[1];



        WCommand.GetComponent<BoxCollider2D>().enabled = true;//当たり判定を出す
        DCommand.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void CanNotCommand()//分解・洗浄コマンドを実行不可能状態にする
    {
        WCommand.GetComponent<Image>().sprite = WSprite[0];//画像を相応のものにする、
        DCommand.GetComponent<Image>().sprite = DSprite[0];
        On_WCommand_Sprite(false);
        On_DCommand_Sprite(false);

        WCommand.GetComponent<BoxCollider2D>().enabled = false;//当たり判定を消す
        DCommand.GetComponent<BoxCollider2D>().enabled = false;
    }








    public void On_WCommand_Sprite (bool bl)
    {
        W_Rite.SetActive(bl);
       
    }
    public void On_DCommand_Sprite(bool bl)
    {
        D_Rite.SetActive(bl);
    }


}
