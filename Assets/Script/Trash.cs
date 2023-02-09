using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Trash : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    // �ȉ����݂̃X�e�[�^�X


    public enum Select_largeCategory
    {

        �܂��g�������,
        ������,
        ������,
        ����,
        �z��,
        �o�C�I�}�X��,
        �v���X�`�b�N,
        �r����,
        ��Ȃ����̗�,
        �e�傲��,
        �ǂ����Ă��R�₳�Ȃ���΂Ȃ�Ȃ�����,
        �ǂ����Ă����ߗ��ĂȂ���΂Ȃ�Ȃ�����,
        ���������������,
    }
    public enum Select_SmallCategory
    {

        ______________�܂��g������� = 1000,//�}�W�b�N�i���o�[�@�{���͗ǂ��Ȃ��񂾂��ǐ����̃_�u���h�����߂ɂ��蓾�Ȃ������ɂȂ��Ă�@�Ȃ獀�ڂ������ȂƂ����b�����������������₷������d���Ȃ��@�҂��Ă��G�f�B�^�g��
        �܂��g������� = 0,

        ______________������ = 1000,
        ������ = 10,

        ______________������ = 1000,
        �A���~�� = 20,
        �X�`�[���� = 21,
        �X�v���[�� = 22,
        �������L���b�v = 23,
        �G���� = 24,

        ______________���� = 1000,
        �V����_�`���V = 30,
        �i�{�[�� = 31,
        �G��_�G�� = 32,
        ���p�b�N_�� = 33,
        ���p�b�N_�� = 34,
        ���J�b�v_�� = 35,
        �d�����c = 36,
        �V�����b�_�[���� = 37,
        ���̑��̎� = 38,

        ______________�z�� = 1000,
        �ߗ�_�ѕz = 40,
        ���̑��̕z�� = 41,

        ______________�o�C�I�}�X�� = 1000,
        ����΂�_�ؒ|���i = 50,
        �p�H�� = 51,

        ______________�v���X�`�b�N = 1000,
        �v���X�`�b�N���e�� = 60,
        ���̑��̃v���X�`�b�N = 61,
        ���g���C = 62,
        �y�b�g�{�g�� = 63,
        �v���X�`�b�N���L���b�v = 64,

        ______________�r���� = 1000,
        �����r = 70,
        ���F�r = 71,
        ���̑��̐F�r = 72,
        �ꏡ�r_�r�[���r = 73,

        ______________��Ȃ����̗� = 1000,
        �K���X_������� = 80,
        ��_����̉��v = 81,
        �d��_�u���� = 82,
        ���d�r = 83,
        �p�o�b�e���[ = 84,
        ���C�^�[ = 85,

        ______________�e�傲�� = 1000,
        �e�傲��_������ = 90,
        �e�傲��_�ؐ� = 91,
        �e�傲��_�z�c_�O�~_�J�[�y�b�g_�� = 92,
        �e�傲��_���r���i_�S�~���i�Ȃ� = 93,

        ______________�ǂ����Ă��R�₳�Ȃ���΂Ȃ�Ȃ����� = 1000,
        �v���i_�S�����i_���r���i = 100,
        ���ނ�_�S�����p�i_�y�b�g�V�[�g = 101,

        ______________�ǂ����Ă����ߗ��ĂȂ���΂Ȃ�Ȃ����� = 1000,
        �ǂ����Ă����ߗ��ĂȂ���΂Ȃ�Ȃ����� = 110,

        ______________��������������� = 1000,
        �p�^�C�� = 120,
        �p���Ί� = 121,
        ����Ɠd = 122

    }
    public enum Marks
    {

       �i�{�[��,
       ��,
       �v���X�`�b�N,
       �y�b�g�{�g��,
       �X�`�[��,
       �A���~,
       ���p�b�N,
       �}�[�N�Ȃ�
    }



    [Header("�\�\�\�\�\�\�\�\�\�\�\�\���݂̃X�e�[�^�X�\�\�\�\�\�\�\�\�\�\�\")]


    public string Name;


    [Tooltip("��J�e�S��")]
    public Select_largeCategory L_Category;
    [Tooltip("���J�e�S��")]
    public Select_SmallCategory S_Category;
    [Tooltip("�}�[�N")]
    public Marks MarkName;




    [Tooltip("�������Ȃ���΂����Ȃ����ǂ���")]
    public bool NeedDisa;//�������Ȃ���΂����Ȃ����ǂ���
    [Tooltip("��򂵂Ȃ���΂����Ȃ����ǂ���")]
    public bool NeedWash;//��򂵂Ȃ���΂����Ȃ����ǂ���



    [Tooltip("������̃p�[�c�@������Ή�������")]
    public GameObject[] Parts;//������̃p�[�c�@������Ή�������
    [Tooltip("����̕�����̃p�[�c�@������Ή�������")]
    public GameObject[] WashedParts;//����̕�����̃p�[�c�@������Ή�������

    [Tooltip("�������̉摜 �Ȃ��̂������炻�̂܂܂̂ő��v")]
    public Sprite WashedSprite;



    [NonSerialized]
    public bool Disassemblyed;//�������ꂽ�ォ�ǂ���
    [NonSerialized]
    public bool Washed;//���ꂽ�ォ�ǂ���



    //�\�\�\�\�\�\�\�\�\�\�\�������ꂽ�I�u�W�F�N�g�̎��Ɏg���X�e�[�^�X�\�\�\�\�\�\�\�\�\�\�\�\�\�\

    // [NonSerialized]
    [Tooltip("������̃p�[�c�̐�")]
    public int PartsCount;

    // [NonSerialized]
    [Tooltip("������̃p�[�c�̂������Ԗڂ�")]
    public int PartsNum;




    [Header("�\�\�\�\�\�\�\�\�\�\�\���O�ɂ��ݔ��ɓ��ꂽ���̉摜�\�\�\�\�\�\�\�\�\�\�\")]

    [Tooltip("����O")]
    public Sprite Before_Dissa;
    [Tooltip("���O")]
    public Sprite Before_Wash;


    //��J�e�S�����ԈႦ���Ƃ��̉摜�@�܂肽����ł�
    #region LCategory
    [Header("�\�\�\�\�\�\�\�\�\�\�\��J�e�S���[���ԈႦ���Ƃ��̉摜�\�\�\�\�\�\�\�\�\�\�\")]

    [Tooltip("�܂��g�������")]
    public Sprite Miss_Usable;

    [Tooltip("������")]
    public Sprite Miss_Garbage;

    [Tooltip("������")]
    public Sprite Miss_metals;


    [Tooltip("����")]
    public Sprite Miss_paper;


    [Tooltip("�z��")]
    public Sprite Miss_cloth;


    [Tooltip("�o�C�I�}�X��")]
    public Sprite Miss_biomass;


    [Tooltip("�v���X�`�b�N")]
    public Sprite Miss_plastic;


    [Tooltip("�r����")]
    public Sprite Miss_bottles;


    [Tooltip("��Ȃ����̗�")]
    public Sprite Miss_Dangerous;


    [Tooltip("�e�傲��")]
    public Sprite Miss_Oversized_Garbage;


    [Tooltip("�ǂ����Ă��R�₳�Ȃ���΂Ȃ�Ȃ�����")]
    public Sprite Miss_Burnable;


    [Tooltip("�ǂ����Ă����ߗ��ĂȂ���΂Ȃ�Ȃ�����")]
    public Sprite Miss_landfill;


    [Tooltip("���������������")]
    public Sprite Miss_Costs_money;

    #endregion //��J�e�S��
    //��J�e�S�����ԈႦ���Ƃ��̉摜�@�܂肽����ł�


    [Header("�\�\���J�e�S���[���ԈႦ���Ƃ��̖��O�Ɖ摜 ���������S���͂���Ă��Ȃ��̂Ŕz��ɂ����\�\")]

    [Tooltip("")]
    public Sprite[] MissImages;

    [Header("�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\������̃p�[�c�̖ڕW�n�_�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\")]
    [Tooltip("������̃p�[�c�̖ڕW�n�_�@�p�[�c�̐���ݒ肷��")]
    public Vector3[] PartDisaPosi;

    [Tooltip("�ڕW�n�_�@�����ړ���ɕW���ɖ߂��悤")]
    public Vector3 DisaPosi_keep;

    [Header("�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�������牺�͂�����Ȃ��Ł\�\�\�\�\�\�\�\�\�\�\�\�\�\�\")]
    // �ȏゲ�݂̃X�e�[�^�X

    [Tooltip("�����̑҂�����")]
    float DissaTiem = 2.5f;
    [Tooltip("���̑҂�����")]
    float WashTiem = 1.5f;

    public Vector3 befor_Drag;//�Ȃ�₩���Ō��̈ʒu�ɖ߂����߂̂��
    public Vector3 CorectPosition=new Vector3 (500,500,500);//���������I�u�W�F�N�g�̒Ǖ������@���݂ɑS��������������Destroy�ŏ����Ə��������邢�@�ł����ݔ����ׂĂɐ��딻��t������͂܂����Ǝv�����@�S����43��H���ݔ��B �S�~�Ȃ�܂�12�͒����Ȃ����낤��


    public GameObject Commentary;//�ԈႦ���Ƃ��̉���I�u�W�F�N�g

    GameObject Large_Category;//��J�e�S��
    GameObject Command;//
    GameObject Other;//���
    GameObject Standard_Trashs;//�ʏ��Ԃ̂��݂̋��ꏊ
    GameObject Ondrag_Trashs;//�h���b�O��Ԃ̂��݂̋��ꏊ
    GameObject WEffect;//������
    GameObject DEffect;//��������
   public GameObject Box_Strage;//���ݔ�

    GameObject Scene_Manager;//�V�[���}�l�[�W���[

    public GameObject Category_Strage;//���ޔ��̈ꎞ�ۑ�
    public  bool Indrag = false;

    //�ȉ�������{�^���ɂ������ϐ�
    [NonSerialized]
    public bool CanDiss;
    [NonSerialized]
    public bool CanWash;

    // [NonSerialized]
    public bool OnDissField;
    //  [NonSerialized]
    public bool OnWashField;

    [NonSerialized]
    Vector3 DisaPosi = new Vector3(775, -68, 0);//���𒆂̃|�W�V����
    [NonSerialized]
    Vector3 WashPosi = new Vector3(775, 156, 0);//��򒆂̃|�W�V����

    [NonSerialized]
    Vector3 EndDisaPosi = new Vector3(490, -68, 0);//������̖ڕW�n�_
    [NonSerialized]
    Vector3 EndWashPosi = new Vector3(490, 156, 0);//����̖ڕW�n�_

    //[NonSerialized]
    public bool OneTime_Disassemblyed;//�������ꂽ�ォ�ǂ���(�ꎞ�I)
    [NonSerialized]
    public bool OneTime_Washed;//��򂳂ꂽ�ォ�ǂ���(�ꎞ�I)
    [NonSerialized]
    private Vector3 velocity = Vector3.zero;//SmoothDamp�ɕK�v�ȑ��x�ۑ��p�̕ϐ�
    [NonSerialized]
    private float M_Time = 0.2f;//Small_Category�̈ړ�����
    [NonSerialized]
    private int dist = 1;//Small_Category�̍ő勖�e����



    [NonSerialized]
    public int TrueScale = 1;//���̃T�C�Y
    [NonSerialized]
    public float LargeScale = 1.5f;//�g��T�C�Y


    //�ȉ��}�E�X�h���b�O�p

    Vector2 point;//�␳�p���W
    private Vector3[] Mouse = new Vector3[2];  //�}�E�X�̈ʒu(�ω��O�ƌ���)
                                               //[NonSerialized]
    public bool CanTrach = false;
    //�ȉ��}�E�X�h���b�O�p
    [Header("�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�T�E���h�p�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\")]
    GameObject SoundManager;//�T�E���h�}�l�[�W���[
    public bool WashSound_bool = false;
    public bool DissaSound_bool = false;




    public GameObject NameText;//�e�X�g�p�Ƀe�L�X�g�u����
    public Text Text;
    public static bool Warld_Drag;//�V�[���S�̂ō��h���b�O�����ǂ���


    //�ȉ��e�X�g�p
    public bool Corect;//����
    public bool OutingBox = true;
    void Awake()
    {
        DisaPosi_keep = EndDisaPosi;//������̈ړ���̈ꎞ���
    }
    void Start()
    {

        Commentary = transform.parent.parent.transform.GetChild(6).gameObject;//�K�w�̏��Ԃŕʂ̂��̂������Ă��܂��̂ŋC��t���邱��
        SoundManager = GameObject.FindWithTag("Sound");
        Large_Category = GameObject.FindWithTag("Large_Category");
        Command = GameObject.FindWithTag("Command");
        WEffect = Command.GetComponent<Command>().WEffect;
        DEffect = Command.GetComponent<Command>().DEffect;
        Other = GameObject.FindWithTag("Other");
        Standard_Trashs = GameObject.FindWithTag("Standard_Trashs");
        Ondrag_Trashs = GameObject.FindWithTag("Ondrag_Trashs");
        NameText = GameObject.FindWithTag("Text");
        Text = NameText.GetComponent<Text>();
        Scene_Manager= GameObject.FindWithTag("SceneManager");

        Mouse[0] = Input.mousePosition;//mouse�̍��W�̎擾
        point = new Vector2(Screen.width / 2, Screen.height / 2);



    }

    // Update is called once per frame
    void Update()
    {
        //�ȉ�������t�B�[���h�ɓ��ꂽ�Ƃ��Ɉꏏ�ɓ���
        if (CanDiss == true)//�����@�쓮����
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, DisaPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
            CanTrach = false;
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(DisaPosi.x, DisaPosi.y)).magnitude < dist && CanDiss)//�ő勖�e�����܂œ��B������A�쓮��������
        {

            CanDiss = false;

            DissaSound();//�����T�E���h

            if (NeedDisa == false)
            {
                //  OneTime_Disassemblyed = true;
            }



        }

        if (CanWash == true)//���@�쓮����
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, WashPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
            CanTrach = false;
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(WashPosi.x, WashPosi.y)).magnitude < dist && CanWash == true)//�ő勖�e�����܂œ��B������A�쓮��������
        {
            CanWash = false;



            WashSound();//���T�E���h

            StartCoroutine("Wash2");
        }

        //i�ȏ㕪����t�B�[���h�ɓ��ꂽ�Ƃ��Ɉꏏ�ɓ���


        //�ȉ������򂳂�ăI�u�W�F�N�g���ړ�������ɍ쓮


        if (OneTime_Disassemblyed == true)//�쓮���� �������ꂽ�I�u�W�F�N�g���������ꂽ��
        {

            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndDisaPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndDisaPosi.x, EndDisaPosi.y)).magnitude < dist)//�ő勖�e�����܂œ��B������A�쓮��������
        {
            EndDisaPosi = DisaPosi_keep;
            OneTime_Disassemblyed = false;

        }

        if (OneTime_Washed == true)//�쓮����
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndWashPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndWashPosi.x, EndWashPosi.y)).magnitude < dist)//�ő勖�e�����܂œ��B������A�쓮��������
        {
            OneTime_Washed = false;

        }

        //�ȏ㕪����t�B�[���h�ɓ��ꂽ�Ƃ��Ɉꏏ�ɓ���



    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "CategoryBox")//��J�e�S���ւ̐ڐG
        {
            
            collision.GetComponent<Outline>().enabled = true;//���ݔ��I�u�W�F�N�g�̉����Ƃ�
            Large_Category.GetComponent<BoxManager>().ReMove();//��J�e�S���̔��������l�Ɉړ�
            Large_Category.GetComponent<BoxManager>().BoxChange(collision.gameObject.name);//����ڐG�����J�e�S���̖��O�Ŕ��肵�ď��J�e�S���̕ϑJ
            Large_Category.GetComponent<BoxManager>().Move = true;//���J�e�S���̈ړ�
            Large_Category.GetComponent<BoxManager>().Sink = false;//���J�e�S���̈ړ�

            if (Category_Strage != null) {
                
                if (Category_Strage != collision.gameObject)//�v����ɕʂ̃J�e�S���[box�ɓ��������ɈȑO�̃J�e�S���[box�̉���������
                {
                   

                    Category_Strage.GetComponent<Outline>().enabled = false;
                }
            }
            Category_Strage = collision.gameObject;//�J�e�S���[box�̕ۑ����X�V

            Command.GetComponent<Command>().CanNotCommand();//�R�}���h����s�\
            Command.GetComponent<Command>().Sink = true;
            Command.GetComponent<Command>().Move = false;
        }

        if (collision.tag == "Box" && Indrag && Large_Category.GetComponent<BoxManager>().Move == false)//CanTrash�͂���Ӗ��Ńh���b�O���̔���̔��]�ɂȂ�
        {
            if (Box_Strage!=null)
            {

                if (Category_Strage != collision.gameObject)//�v����ɕʂ̃J�e�S���[box�ɓ��������ɈȑO�̃J�e�S���[box�̉���������
                {

                    Box_Strage.GetComponent<Outline>().enabled = false;


                }

            }
        
            Box_Strage = collision.gameObject;
            Box_Strage.GetComponent<Outline>().enabled = true;//���ݔ��I�u�W�F�N�g�̉����Ƃ�

        }
      
 
 


    }
    public void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.tag == "CategoryBox")
        {
            Large_Category.GetComponent<BoxManager>().Move = true;


        }
        if (collision.tag == "Right")//���̏�
        {

            Large_Category.GetComponent<BoxManager>().OnArrow(-1);

        }
        if (collision.tag == "Left")//���̏�
        {

            Large_Category.GetComponent<BoxManager>().OnArrow(1);

        }
        if (collision.tag == "Box")
        {


            CanTrach = true;


            //  Large_Category.GetComponent<BoxManager2>().ReMove();

        }
        else if(collision.tag != "Trash")
        {
         
           
            CanTrach = false;
        }
       
        if (collision.tag == "Disassembly" && Indrag)//  �����{�^���̏�
        {
            OnDissField = true;
            OnWashField = false;
            Command.GetComponent<Command>().On_DCommand_Sprite(true);
            Command.GetComponent<Command>().On_WCommand_Sprite(false);
        }
        else
        {
            OnDissField = false;
        }
        if (collision.tag == "Wash" && Indrag)//  ���{�^���̏�
        {
            OnWashField = true;
            OnDissField = false;
            Command.GetComponent<Command>().On_WCommand_Sprite(true);
            Command.GetComponent<Command>().On_DCommand_Sprite(false);
        }
        else
        {
            OnWashField = false;

        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        OutingBox = true;
        if (collision.tag == "CategoryBox" && Indrag)
        {
           // Large_Category.GetComponent<BoxManager>().Move = false;


        }



        if (collision.tag == "Disassembly" && Indrag)//  �����{�^���̏�
        {

            OnDissField = false;
            Command.GetComponent<Command>().On_DCommand_Sprite(false);
        }


        if (collision.tag == "Wash" && Indrag)//  ���{�^���̏�
        {
            OnWashField = false;
            Command.GetComponent<Command>().On_WCommand_Sprite(false);
        }
        if (collision.tag == "Box" && Indrag)//CanTrash�͂���Ӗ��Ńh���b�O���̔���̔��]�ɂȂ�
        {
           
            collision.GetComponent<Outline>().enabled = false;//���ݔ��I�u�W�F�N�g�̉����Ƃ�
        }


    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        Warld_Drag = true;
        Indrag = true;//�h���b�O���̔���
        //SoundManager.GetComponent<SoundManager>().CommandSound_Play();//�R�}���h�T�E���h
        befor_Drag = GetComponent<RectTransform>().anchoredPosition;//�h���b�O�J�n�ʒu�̋L�^

        Mouse[0] = Input.mousePosition;//�h���b�O�J�n�ʒu���L�^
      
        Other.GetComponent<Other>().TrashDrag = true;//���̓_�ŊJ�n
        OnDissField = false;
        OnWashField = false;

    }

    public void OnDrag(PointerEventData eventData)
    {




        // transform.position = eventData.position;
        // Overlay �̏ꍇ
        Mouse[1] = Input.mousePosition;//�ړ���̈ʒu���L�^

        if (Mouse[0] != Mouse[1])//�H��������獷�����ړ�
        {
            transform.position += (Mouse[1] - Mouse[0]);//�����ňړ�
            Mouse[0] = Input.mousePosition;//���݈ʒu���L�^
        }








    }
    public void OnEndDrag(PointerEventData eventData)//�h���b�O����Ȃ��Ƃ����Ȃ����̂�����
    {
        //SoundManager.GetComponent<SoundManager>().CommandSound2_Play();//�R�}���h�Q


        Warld_Drag = false;
       
        Other.GetComponent<Other>().TrashDrag = false;//���̓_�ŏI��
        transform.localScale = new Vector3(TrueScale, TrueScale, TrueScale);//���݂̊g��\���̏I��
       

        

    }

    public void ClickDown()
    {

        Indrag = true;//�h���b�O������̏I��
        OnDissField = false;
        OnWashField = false;
        Command.GetComponent<Command>().Move = true;
        Command.GetComponent<Command>().Sink = false;
        transform.localScale = new Vector3(LargeScale, LargeScale, LargeScale);
        transform.SetParent(Ondrag_Trashs.transform);//Ondrag�Ƃ������Ă��邯�ǁ@�����N���b�N�i�K�œ���������
    }
    public void ClickUP()
    {
        Indrag = false;//�h���b�O������̏I��
        Command.GetComponent<Command>().Sink = true;
        Command.GetComponent<Command>().Move = false;

        transform.SetParent(Standard_Trashs.transform);//Ondrag�Ƃ������Ă��邯�ǁ@�����N���b�N�i�K�œ���������

        Large_Category.GetComponent<BoxManager>().Sink = true;
        Large_Category.GetComponent<BoxManager>().Move = false;
        transform.localScale = new Vector3(TrueScale, TrueScale, TrueScale);

        if (Category_Strage != null)
        {
            Category_Strage.GetComponent<Outline>().enabled = false;//���ݔ��̋����\���̏I��
        }

        if (OnDissField)
        {
            Disas();
        }
        if (OnWashField)
        {
            Wash();
        }

        if (OnDissField == false && OnWashField == false)
        {
            Command.GetComponent<Command>().CanNotCommand();
        }



        if (CanTrach == true && Box_Strage != null)//�h���b�O���I��������A
        {
            Incorrect(Box_Strage);//�������ǂ����̔���
        }

        CanTrach = false;

        OnDissField = false;
        OnWashField = false;
    }

    public void ChangeImage()
    {

    }


    public void Disas()
    {

        if (NeedDisa)
        {
            DissaSound_bool = true;
        }
        CanDiss = true;
        Disassemblyed = true;

        StartCoroutine("Disas_2");//�p�[�c�������R���[�`���ŋN��

    }

    public IEnumerator Disas_2()//������ɍ쓮
    {
        yield return new WaitForSeconds(DissaTiem);

        if (NeedDisa == true)
        {

            GameObject[] PObj;//�p�[�c�I�u�W�F�N�g����
            if (Washed == false)//���O���ǂ���
            {
                PObj = Parts;
            }
            else
            {
                PObj = WashedParts;
            }

            int num = 1;
            foreach (var obj in PObj)//�������
            {


                GameObject Invited_Parts = Instantiate(obj, DisaPosi, transform.rotation, Standard_Trashs.transform);

                Invited_Parts.GetComponent<RectTransform>().anchoredPosition = DisaPosi;//�ꏊ��ύX
                Invited_Parts.GetComponent<Trash>().PartsCount = Parts.Length;//�p�[�c����ύX
                Invited_Parts.GetComponent<Trash>().PartsNum = num;//�p�[�c�̒��ŉ��Ԗڂ�
                Invited_Parts.GetComponent<Trash>().ChengeDisaPosi();//�������ꂽ�p�[�c�̍s�����ύX
                Invited_Parts.GetComponent<Trash>().OneTime_Disassemblyed = true;//�������ꂽ�z���ړ�������
                num++;

            }
            Destroy(this.gameObject);
        }

        OneTime_Disassemblyed = true;
    }

    public void DissaSound()//�����T�E���h�̐ݒ�
    {
        DEffect.SetActive(true);


        if (DissaSound_bool)
        {
            DEffect.GetComponent<Effect>().Effect_1();//�����̉����ɍ��킹���A�j���[�V����
            if (L_Category.ToString() == "������")
            {
                SoundManager.GetComponent<SoundManager>().DissaSound_metal_Play();
            }
            if (L_Category.ToString() == "����")
            {
                SoundManager.GetComponent<SoundManager>().DissaSound_paper_Play();
                StartCoroutine("Paper2");
            }
            if (L_Category.ToString() == "�v���X�`�b�N")
            {
                SoundManager.GetComponent<SoundManager>().DissaSound_pla_Play();
            }




        }
        else
        {
            DEffect.GetComponent<Effect>().MissEffect_1();//�����̉����ɍ��킹�����s�A�j���[�V����
            SoundManager.GetComponent<SoundManager>().Dissa_MissSound_Play();
        }

        DissaSound_bool = false;
    }


    public IEnumerator Paper2()
    {

        yield return new WaitForSeconds(0.5f);
        SoundManager.GetComponent<SoundManager>().DissaSound_paper2_Play();

    }

    public void Wash()
    {

        CanWash = true;//��򋖉�
        Washed = true;//����

        if (NeedWash == true)
        {
            WashSound_bool = true;
            NeedWash = false;
            this.gameObject.GetComponent<Image>().sprite = WashedSprite;
            Name = "���ꂽ" + Name;
        }

    }



    public IEnumerator Wash2()
    {

        yield return new WaitForSeconds(WashTiem);
        OneTime_Washed = true;
    }

    public void WashSound()//���T�E���h�̐ݒ�
    {
        WEffect.SetActive(true);

        if (WashSound_bool)
        {
            WEffect.GetComponent<Effect>().Effect_1();//���̉����ɍ��킹���A�j���[�V����
            SoundManager.GetComponent<SoundManager>().WashSound_Play();
        }
        else
        {
            WEffect.GetComponent<Effect>().MissEffect_1();//���̉����ɍ��킹�����s�A�j���[�V����
            SoundManager.GetComponent<SoundManager>().Wash_MissSound_Play();
        }

        WashSound_bool = false;
    }


    public void ChengeDisaPosi()//������p�[�c�̍s�����ύX
    {
        if (PartsCount == 3)//������̃p�[�c����3�������ꍇ
        {
            if (PartsNum == 1)
            {
                EndDisaPosi = PartDisaPosi[0];
            }
            if (PartsNum == 2)
            {
                EndDisaPosi = PartDisaPosi[1];
            }
            if (PartsNum == 3)
            {
                EndDisaPosi = PartDisaPosi[2];
            }
        } else if (PartsCount == 2)
        {
            if (PartsNum == 1)
            {
                EndDisaPosi = PartDisaPosi[0];
            }
            if (PartsNum == 2)
            {
                EndDisaPosi = PartDisaPosi[1];
            }
        }

    }


    public void Incorrect(GameObject obj)//�������ǂ����̔���
    {
        CanTrach = false;
        bool Corect = true;//���딻��o�O�������̂��߂Ƀf�t�H���g�Œʉ߂ł���悤�ɂ��Ă���
        Sprite IncorrectSprite = null;
        if (NeedDisa)//�����̕K�v��������Ƃ�
        {
            IncorrectSprite = Before_Dissa;
            Corect = false;
        } else if (NeedWash)//���̕K�v������Ƃ�
        {
            IncorrectSprite = Before_Wash;
            Corect = false;
        } else if (obj.transform.parent.parent.name != Conect_LCategory(L_Category.ToString()))//��J�e�S�����Ⴄ�Ƃ��@�e�̖��O��Enum�Ŕ���
        {
            IncorrectSprite = Miss_LCategory(obj.transform.parent.parent.name);
            Corect = false;
        }
        else if ("" + ((int)S_Category % 10) != obj.name)//�{�b�N�X�̖��O��Enum�Ƃ��ݍ���Ȃ��ꍇ
        {
            Debug.Log((int)S_Category+" "+((int)S_Category % 10)+""+obj.name);
            IncorrectSprite = MissImages[System.Int32.Parse(obj.name)];//�{�b�N�X�̖��O�̉摜���o��
            Corect = false;
        }

        if (Corect == false) {
           
            SoundManager.GetComponent<SoundManager>().Incorrect_Play();
            Commentary.GetComponent<Image>().sprite = IncorrectSprite;
            Commentary.SetActive(true);
            PointManager.MissPoint++;
            obj.GetComponent<Outline>().enabled = false;//���ݔ��̋����\���̏I��
        }
        else
        {
            obj.GetComponent<Outline>().enabled = false;//���ݔ��̋����\���̏I��
            GameObject[] Trash = GameObject.FindGameObjectsWithTag("Trash");
            int Trashes= Trash.Length;
            befor_Drag = CorectPosition;

            PointManager.CorectPoint++;

            SoundManager.GetComponent<SoundManager>().Correct_Play();
            if (Trashes <= PointManager.CorectPoint)
            {
                Scene_Manager.GetComponent<SceneManagerSC>().Finish();
            }

         
        }
        GetComponent<RectTransform>().anchoredPosition = befor_Drag;
    }


    public string Conect_LCategory(string str)//��J�e�S����Enum����Ή�����͂��̐e�̖��O�𔲂��o��
    {
        switch (str) {
            case "�܂��g�������":
                return "Usable";

            case "������":
                return "Garbage";

            case "������":
                return "metals";

            case "����":
                return "paper";

            case "�z��":
                return "cloth";

            case "�o�C�I�}�X��":
                return "biomass";

            case "�v���X�`�b�N":
                return "plastic";

            case "�r����":
                return "bottles";

            case "��Ȃ����̗�":
                return "Dangerous";

            case "�e�傲��":
                return "Oversized_Garbage";

            case "�ǂ����Ă��R�₳�Ȃ���΂Ȃ�Ȃ�����":
                return "Burnable";

            case "�ǂ����Ă����ߗ��ĂȂ���΂Ȃ�Ȃ�����,":
                return "landfill";

            case "���������������":
                return "Costs_money";


        }

        return "";

    }

    public Sprite Miss_LCategory(string str)//�{�b�N�X�̐e�̖��O����ԈႦ�̉摜����������
    {


        switch (str)
        {

            case "Usable":
                return Miss_Usable;

            case "Garbage":
                return Miss_Garbage;

            case "metals":
                return Miss_metals;

            case "paper":
                return Miss_paper;

            case "cloth":
                return Miss_cloth;

            case "biomass":
                return Miss_biomass;

            case "plastic":
                return Miss_plastic;

            case "bottles":
                return Miss_bottles;

            case "Dangerous":
                return Miss_Dangerous;

            case "Oversized_Garbage":
                return Miss_Oversized_Garbage;

            case "Burnable":
                return Miss_Burnable;

            case "landfill":
                return Miss_landfill;

            case "Costs_money":
                return Miss_Costs_money;

        }

        return null;

    }




    public void Name_MarkChange()
    {

        Text.text = Name;
        NameText.GetComponent<Mark>().ChangeMark(MarkName.ToString());
      
    }

    public void Name_MarkLost()
    {


    }

    public void OnMouseEnter()
    {
        if (Warld_Drag == false) {
          
            Text.text = Name;
            NameText.GetComponent<Mark>().ChangeMark(MarkName.ToString());
        }
    }
    public void OnMouseExit()
    {
        if (Warld_Drag == false)
        {
          
            Text.text = "";
            NameText.GetComponent<Mark>().ChangeMark("--");
        }
    }
}
