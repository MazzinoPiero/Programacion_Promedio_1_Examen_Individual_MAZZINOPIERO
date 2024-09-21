using System;
public interface ICombate
{
    int Health { get; set; }
    void TakeDamage(int damage);
    bool IsAlive();
}