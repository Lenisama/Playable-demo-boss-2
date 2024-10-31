using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss2Controller : MonoBehaviour
{
    public Skill1Spike skill1Spike;
    public Animator animator;
    public Damageable damageable;
    public GameObject[] skill2FireSpawnPoints;
    public GameObject skill2FirePrefab;
    public float startCooldownTime = 1f;
    private float cooldownTime;
    private bool isCooldown;
    private float timeSinceCast;
    void Start()
    {
        cooldownTime = startCooldownTime;
        isCooldown = true;
    }

    private void CastSkill()
    {
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                CastSkill1();
                break;
            case 2:
                CastSkill2();
                break;
            case 3:
                CastSkill1();
                break;
        }
    }

    private void CastSkill1()
    {
        animator.SetTrigger("CastSkill1");
    }
    private void CastSkill2()
    {
        animator.SetTrigger("CastSkill2");
        for (int i = 0; i < skill2FireSpawnPoints.Length; i++)
        {
            Instantiate(skill2FirePrefab, skill2FireSpawnPoints[i].transform.position, quaternion.identity);
        }
    }

    private void Skill1()
    {
        skill1Spike.RaiseSpikes();
    }

    private void Skill2()
    {
        foreach (var fire in FindObjectsOfType<Fire>())
        {
            fire.MoveToPlayer();
        }
    }

    private void Skill3()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            if (timeSinceCast > cooldownTime)
            {
                isCooldown = false;
                timeSinceCast = 0;
            }
            timeSinceCast += Time.deltaTime;
        }
        else
        {
            CastSkill();
            cooldownTime += Random.Range(-0.2f, 0.4f);
            isCooldown = true;
        }

        float healthPercent = (float) damageable.Health / damageable.MaxHealth * 100;
        if (healthPercent < 60 && healthPercent > 25)
        {
            cooldownTime = startCooldownTime * 0.6f;
        }
        else if (healthPercent < 25)
        {
            cooldownTime = startCooldownTime * 0.4f;
        }
    }
}
