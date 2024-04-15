using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStage
{
    void OnEnter(Enemy enemy);
    void OnExit(Enemy enemy);
    void OnExecute(Enemy enemy);
}
