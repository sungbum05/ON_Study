using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum hpImages 
{
    NullHpBar,
    HpBar
}
public enum Texts
{
    DistanceText,
    ScoreText
}



public class HoneyComboGameManager : MonoBehaviour
{
    public float hp;
    private float maxHp;
    public float score;
    private float nowDistance;
    [SerializeField] private Image[] hpImage;
    [SerializeField] private Text[] texts;
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer sR;
    private bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        sR = player.GetComponent<SpriteRenderer>();
        maxHp = hp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HpMinus();
        TextsSetting();
        hpImage[(int)hpImages.HpBar].fillAmount = hp / maxHp; 
    }
    void HpMinus()
    {
        hp -= Time.deltaTime;
        nowDistance += Time.deltaTime;
        if (hp <= 0)
            SceneManager.LoadScene("HoneyComboGame");
    }
    void TextsSetting()
    {
        texts[(int)Texts.DistanceText].text = $"{nowDistance:N0} M";
        texts[(int)Texts.ScoreText].text = $"{score:N0} Á¡";
    }
    public void Hit(float damage)
    {
        if (isHit == false)
        {
            hp -= damage;
            isHit = true;
            StartCoroutine(HitInvincibility());
        }
    }
    private IEnumerator HitInvincibility()
    {
        sR.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(3f);
        sR.color = new Color(1, 1, 1, 1f);
        isHit = false;
    }
}
