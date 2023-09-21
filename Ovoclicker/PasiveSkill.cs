using System;
namespace Ovoclicker
{
    public class PassiveSkill
    {
        public PassiveSkill() { }

        public int currentLevel = 0;

        public void UseSkill(Player player)
        {
            player.SetTapPower(currentLevel);
        }
    }
}

