using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStage : IStage
{
    private float timer;

    public void OnEnter(Enemy enemy)
    {
        if (enemy.Taget != null)
        {
            enemy.ChangeDirection(enemy.Taget.transform.position.x > enemy.transform.position.x);
            enemy.StopMoving();
            enemy.Attack();
        }
        timer = 0;
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            enemy.ChangStage(new PatrolStage());
        }
    }
    //aaaaaaaaaaaaa
    public void OnExit(Enemy enemy)
    {
    }
}
