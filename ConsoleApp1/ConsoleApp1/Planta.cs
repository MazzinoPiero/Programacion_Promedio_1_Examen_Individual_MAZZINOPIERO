using System;

public class Planta : Character
{
    public Planta(int health, int attackPower) : base(health, attackPower) { }

    public override void Attack(ICombate target)
    {
        target.TakeDamage(AttackPower);
    }
}