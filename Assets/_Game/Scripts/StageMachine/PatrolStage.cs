using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStage : IStage
{
    private float time;
    private float randomTime;

    public void OnEnter(Enemy enemy)
    {
        time = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;
        if (enemy.Taget != null)
        {
            enemy.ChangeDirection(enemy.Taget.transform.position.x > enemy.transform.position.x);
            if (enemy.IsTagetInRange())
            {
                enemy.ChangStage(new AttackStage());
            }
            else
            {
                enemy.Moving();
            }
        }
        else
        {
            if (time < randomTime)
                enemy.Moving();
            else
                enemy.ChangStage(new IdleStage());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }
}
