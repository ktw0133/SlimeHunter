using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slimes;
    [SerializeField] private float damage;
    [SerializeField] private float criDamage;
    [SerializeField] private float criPercent;
    [SerializeField] private int gold;

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
        }

        damageText.text = "Damage : " + damage.ToString();
        criDamageText.text = "Critical Damage : " + criDamage.ToString();
        criPercentText.text = "Critical Percentage : " + criPercent.ToString() + "%";
        goldText.text = "Gold : " + gold.ToString();
    }

    public void HitSlime()
    {
        if (curSlime != null)
        {
            curSlime.OnHit(damage, criDamage, criPercent, ref gold);
        }
    }
}
