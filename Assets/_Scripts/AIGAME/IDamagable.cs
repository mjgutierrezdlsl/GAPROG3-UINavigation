using AIGAME;


public interface IDamagable
{
    Health Health { get; set; }
    void TakeDamage(float amount);
}
