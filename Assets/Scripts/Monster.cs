using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    [SerializeField] private Text nameText;

    [SerializeField] private string monsterName;
    [SerializeField] private float maxHp;
    private float curHp;

    private bool isDead = false;
    private Animator animator;

    private void Awake()
    {
        curHp = maxHp;
        animator = GetComponent<Animator>();
        nameText.text = monsterName;
    }

    public void OnHit(float damage, float criDamage, float criPercent, ref int gold)
    {
        if (Random.Range(1, 101) <= criPercent)
        {
            curHp -= criDamage;
            Debug.Log("Critical!");
        }
        else
        {
            curHp -= damage;
        }

        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
            gold++;
        }
        animator.SetTrigger("Hit");
        Debug.Log("Slime Hit!, Current Hp : " + curHp);
        hpBar.ChangeHpBarAmount(curHp / maxHp);

        if (isDead)
        {
            Debug.Log("Slime is Dead");
            animator.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
        }
    }
}
