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
        //StartCoroutine(CTextTyping(Text, "���ϴ� Ż���. ���ϴ� ���� �ں��� �Ӹ��ڰ� ���� �ڼ��� ��ο��� �������� �״´�."));
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        CurTime += Time.deltaTime;
        if (CurTime >= Delay)
        {
            Debug.Log("������ Ż��� �ӸӸ��� ���� ����, ����");
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

    //N�ʸ��� � �۾��� �Ҷ�
    IEnumerator CDelay(int waitsecond)
    {
        var wait = new WaitForSeconds(waitsecond);

        while (true)
        {
            yield return wait;

            Debug.Log("������ Ż��� �ӸӸ��� ���� ����, ����");
        }

    }

    //� �۾��� ����Ǳ���� ��ٸ���
    //�̿��� ���鶧 ��ȭ�Ѿ�� ����
    IEnumerator CWait()
    {
        while (true)
        {
            yield return StartCoroutine(CWaitClick());

            Debug.Log("������ Ż��� �ӸӸ��� ���� ����, ����");
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

    //�̷� ȿ���� �� �ؽ�Ʈ�� �Ѱ��� �׳� ���ڷ� �����ʰ� ����
    //��������� ���ڷ� �޾Ƽ� ���
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
