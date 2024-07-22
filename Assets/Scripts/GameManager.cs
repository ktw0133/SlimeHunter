using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slimes;
    [SerializeField] private float damage;
    [SerializeField] private float criDamage;
    [SerializeField] private float criPercent;
    [SerializeField] private int gold = -1;       // 처음 몬스터 등장 순간에도 GetGold가 실행됨

    [SerializeField] private Text damageText;
    [SerializeField] private Text criDamageText;
    [SerializeField] private Text criPercentText;
    [SerializeField] private Text goldText;

    private Monster curSlime;

    public void SpawnSlime()
    {
        int spawnIndex = UnityEngine.Random.Range(0, slimes.Length);
        GameObject newSlime = Instantiate(slimes[spawnIndex].gameObject);
        curSlime = newSlime.GetComponent<Monster>();
    }

    private void Update()
    {
        if (curSlime == null)
        {
            SpawnSlime();
            GetGold();
        }

        damageText.text = "Damage : " + damage.ToString();
        criDamageText.text = "Critical Damage : " + criDamage.ToString();
        criPercentText.text = "Critical Percentage : " + criPercent.ToString() + "%";
    }

    public void HitSlime()
    {
        if (curSlime != null)
        {
            if (Random.Range(1, 101) <= criPercent)
            {
                curSlime.OnHit(criDamage);
                Debug.Log("Critical!");
            }
            else
            {
                curSlime.OnHit(damage);
            }
        }
    }

    private void GetGold()
    {
        gold++;
        goldText.text = "Gold : " + gold.ToString();
    }
}
