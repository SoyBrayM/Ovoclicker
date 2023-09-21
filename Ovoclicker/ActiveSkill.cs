using System;
namespace Ovoclicker
{
    public class ActiveSkill
    {
        public ActiveSkill() { }

        public int currentLevel = 0;
        public bool currentlyActive = false;
        private int lifetime = 10;
        private int cooldown = 50;

        public void UseSkill(Player currentPlayer)
        {
            currentPlayer.SetTapPower(currentPlayer.GetTapPower() * (currentLevel + 1));
            lifetime = 9 + currentLevel;
            cooldown = 51 - (currentLevel * 2);
            currentlyActive = true;
        }

        public void DeactivateSkill(Player currentPlayer)
        {
            if (lifetime <= 0 && currentLevel != 0 && currentlyActive)
            {
                currentPlayer.SetTapPower(currentPlayer.GetTapPower() / (currentLevel + 1));
                currentlyActive = false;
            }

        }

        public int GetLifetime()
        {
            return lifetime;
        }

        public int GetCooldown()
        {
            return cooldown;
        }

        public void SetCooldown(int newValue)
        {
            cooldown = newValue;
        }

        public void SetLifetime(int newValue)
        {
            lifetime = newValue;
        }
    }
}