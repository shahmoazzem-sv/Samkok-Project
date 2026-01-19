using UnityEngine;

public interface ICharacter
{

    public void Attack(ICharacter character);
    public void TakeDamage(int amount);
    public void GainEnergy(float amount);
    public void ExecuteUltimate();
}
