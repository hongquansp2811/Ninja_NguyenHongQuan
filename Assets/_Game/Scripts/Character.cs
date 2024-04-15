using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float hp;
    [SerializeField] private Animator anim;
    [SerializeField] private HeathBar heathBar;
    private string currentAnim;

    public bool IsDeath => hp <= 0;

    // Start is called before the first frame update
    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
        heathBar.OnInit(100);
    }

    public virtual void OnDespawn()
    {

    }

    protected virtual void OnDeath()
    {
        ChangeAnim("die");
        Invoke(nameof(OnDespawn), 2f);
    }

    protected void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

    public void OnHit(float dame)
    {
        if (!IsDeath)
        {
            hp -= dame;
            if (IsDeath)
            {
                OnDeath();
            }
        }
    }
}
