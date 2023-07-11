using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected int lives;
    protected bool isDie;
    public virtual void GetDamage()
    {
        lives--;
        if (lives < 1)
        {
            isDie = true;
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public virtual bool GetIsDie()
    {
        return isDie;
    }
}
