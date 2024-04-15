using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStage : IStage
{
    private float time;
    private float randomTime;
    

    public void OnEnter(Enemy enemy)
    {
        enemy.StopMoving();
        time = 0;
        randomTime = Random.Range(2f, 4f);
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;
        if (time > randomTime)
        {
            enemy.ChangStage(new PatrolStage());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }
}
