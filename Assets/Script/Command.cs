using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Command : MonoBehaviour
{
    private Vector2 StartPosi;//Commandy�̏����ʒu
    public Vector3 EndPosi;//Command�̍ŏI�ʒu
    private Vector3 velocity = Vector3.zero;//SmoothDamp�ɕK�v�ȑ��x�ۑ��p�̕ϐ�
    private float M_Time = 0.2f;//Small_Category�̈ړ�����
    private int dist = 1;//Small_Category�̍ő勖�e����


    public GameObject WCommand;//���t�B�[���h
    public GameObject DCommand;//�����t�B�[���h

    public Sprite[] WSprite;//���ʐ^
    public Sprite[] DSprite;//�����ʐ^

    GameObject SoundManager;//�T�E���h�}�l�[�W���[
    public GameObject WEffect;//������
    public GameObject DEffect;//��������

    public GameObject W_Rite;//���t�B�[���h�̂����邢
    public GameObject D_Rite;//�����t�B�[���h�̂����邢

    

    public bool Move = false;//Command�𓮂������߂̃g���K�[
    public bool Sink = false;//Command�𔽑΂ɓ��������߂̃g���K�[
    // Start is called before the first frame update
    void Start()
    {
        StartPosi = GetComponent<RectTransform>().anchoredPosition;


    }

    // Update is called once per frame
    void Update()
    {



        if (Move == true&& Sink == false)//�쓮����
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndPosi.x, EndPosi.y)).magnitude < dist && Move == true)////Small_Category�̍ő勖�e�����܂œ��B������A�쓮��������
        {
            Debug.Log("LLLLLLLLLLLLLLLLLLL");
            CanCommand();//�R�}���h����\
            Move = false;
        }
        if (Sink == true && Move == false)//�쓮����
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, StartPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(StartPosi.x, StartPosi.y)).magnitude < dist && Sink == true)////Small_Category�̍ő勖�e�����܂œ��B������A�쓮��������
        {
            CanNotCommand();
            Sink = false;
        }

    }

    

    public void CanCommand()//�����E���R�}���h�����s�\��Ԃɂ���
    {
        WCommand.GetComponent<Image>().sprite = WSprite[1];//�摜�𑊉��̂��̂ɂ���A
        DCommand.GetComponent<Image>().sprite = DSprite[1];



        WCommand.GetComponent<BoxCollider2D>().enabled = true;//�����蔻����o��
        DCommand.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void CanNotCommand()//�����E���R�}���h�����s�s�\��Ԃɂ���
    {
        WCommand.GetComponent<Image>().sprite = WSprite[0];//�摜�𑊉��̂��̂ɂ���A
        DCommand.GetComponent<Image>().sprite = DSprite[0];
        On_WCommand_Sprite(false);
        On_DCommand_Sprite(false);

        WCommand.GetComponent<BoxCollider2D>().enabled = false;//�����蔻�������
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
