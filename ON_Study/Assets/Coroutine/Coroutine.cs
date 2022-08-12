using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coroutine : MonoBehaviour
{
    public Text Text;
    public Image image;

    public float Delay = 2;
    public float CurTime;

    void Start()
    {
        //StartCoroutine(CDelay(2));
        //StartCoroutine(CTextTyping(Text, "용하는 탈모다. 용하는 내일 자빠져 머리박고 웃긴 자세로 모두에게 보여지며 죽는다."));
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        CurTime += Time.deltaTime;
        if (CurTime >= Delay)
        {
            Debug.Log("용하의 탈모와 머머리에 대한 정의, 용용용");
            CurTime = 0;
        }
    }

    //Fade In
    IEnumerator FadeIn()
    {
        var wait = new WaitForSeconds(0.01f);
        Color color = image.color;
        while(color.a > 0f)
        {
            color.a -= 0.01f;
            image.color = color;
            yield return wait;
        }
    }

    //Fade Out
    IEnumerator FadeOut()
    {
        var wait = new WaitForSeconds(0.01f);
        Color color = image.color;
        while (color.a < 1f)
        {
            color.a += 0.01f;
            image.color = color;
            yield return wait;
        }
    }

    //N초마다 어떤 작업을 할때
    IEnumerator CDelay(int waitsecond)
    {
        var wait = new WaitForSeconds(waitsecond);

        while (true)
        {
            yield return wait;

            Debug.Log("용하의 탈모와 머머리에 대한 정의, 용용용");
        }

    }

    //어떤 작업이 수행되기까지 기다리기
    //미연시 만들때 대화넘어갈때 썼음
    IEnumerator CWait()
    {
        while (true)
        {
            yield return StartCoroutine(CWaitClick());

            Debug.Log("용하의 탈모와 머머리에 대한 정의, 용용용");
        }
    }

    IEnumerator CWaitClick()
    {
        WaitForSeconds Waits = new WaitForSeconds(0.0005f);
        var wait = new WaitForSeconds(0.005f);

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                yield break;
            }
            yield return wait;
        }
    }

    //이런 효과를 줄 텍스트가 한개면 그냥 인자로 받지않고 쓰고
    //여러개라면 인자로 받아서 써라
    IEnumerator CTextTyping(Text text, string newString)
    {
        var wait = new WaitForSeconds(0.05f);

        for (int i = 0; i <= newString.Length; i++)
        {
            text.text = newString.Substring(0, i);//StringBuilder
            if (Input.GetKey(KeyCode.X))
                continue;
            yield return wait;
        }

        yield return null;
    }
}
