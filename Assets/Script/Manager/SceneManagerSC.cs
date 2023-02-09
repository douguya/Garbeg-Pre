using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class SceneManagerSC : MonoBehaviour
{
    // Start is called before the first frame update
    public string Title;
    public string Main;
    public string Result;

    

    string str;
    // Update is called once per frame
    void Update()
    {
        
    }




    public void Transition_Title()
    {
        Debug.Log(1111);
        str = Title;
        StartCoroutine("Transition");
    }
    public void Transition_Main()
    {
        Debug.Log(222);
        str = Main;
        StartCoroutine("Transition");

    }
    public void Transition_Result()
    {
        Debug.Log(333);
        str = Result;
        StartCoroutine("Transition");

    }
    public IEnumerator Transition()
    {

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(str);

    }

    public void Finish()
    {
        str = Result;
        StartCoroutine("Finish_coroutine");

    }

    public IEnumerator Finish_coroutine()
    {

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(str);

    }

}
