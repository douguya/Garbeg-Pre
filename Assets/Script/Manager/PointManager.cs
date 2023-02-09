using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PointManager : MonoBehaviour
{

    public static int MissPoint;//間違えた回数
    public static int CorectPoint;//正解の回数
    public static int Max;//最大値


    public int p;
    public int c;
    public int m;
    public GameObject Scene_Manager;
    public Text RisultText;

    // Start is called before the first frame update
    void Start()
    {
     
        if (SceneManager.GetActiveScene().name == Scene_Manager.GetComponent<SceneManagerSC>().Main)
        { 
            MissPoint = 0;
            CorectPoint = 0;
        }
        else if((SceneManager.GetActiveScene().name == Scene_Manager.GetComponent<SceneManagerSC>().Result))
        {
            if (MissPoint==0)
            {

                RisultText.text ="全問正解";
            }
            else
            {

                RisultText.text = "" + MissPoint + "ミス";
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        p = MissPoint;
        c = CorectPoint;
        m = Max;



    }
}
