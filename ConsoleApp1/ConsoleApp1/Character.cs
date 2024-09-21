using System;

public abstract class Character : ICombate
{
    public int Health { get; set; }
    public int AttackPower { get; protected set; }

    public Character(int health, int attackPower)
    {
        Health = health;
        AttackPower = attackPower;
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public abstract void Attack(ICombate target);
}