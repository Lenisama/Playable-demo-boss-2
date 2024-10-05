using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    public Skill1Spike skill1Spike;
    public Animator animator;
    public Damageable damageable;
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
        animator.SetTrigger("CastSkill1");
    }

    private void Skill1()
    {
        skill1Spike.RaiseSpikes();
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
