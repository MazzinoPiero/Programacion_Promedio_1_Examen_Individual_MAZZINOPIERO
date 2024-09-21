using System;

public abstract class Zombie : Character
{
    protected Zombie(int health, int attackPower) : base(health, attackPower) { }
}

public class NormalZombie : Zombie
{
    public NormalZombie() : base(70, 30) { }

    public override void Attack(ICombate target)
    {
        target.TakeDamage(AttackPower);
    }
}

public class ToughZombie : Zombie
{
    public ToughZombie() : base(150, 40) { }

    public override void Attack(ICombate target)
    {
        target.TakeDamage(AttackPower);
    }
}