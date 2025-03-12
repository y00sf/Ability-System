using UnityEngine;

public class Ability_DoubleJump : Ability
{
    public Ability_DoubleJump(float cooutdown)
    {
        this.cooutdown = cooutdown;
    }

    public override void Base(Player player)
    {
        player.canDoubleJump = true;
    }
}
