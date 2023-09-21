using Ovoclicker;

class Program
{
    public static void Main(string[] args)
    {
        bool stopPlaying = false;
        ConsoleKeyInfo input;
        Ovo mainOvo = new Ovo("Ovony");
        Player mainPlayer = new Player("Fulano");
        ActiveSkill activeSkill = new ActiveSkill();
        PassiveSkill passiveSkill = new PassiveSkill();
        Shop gameShop = new Shop();

        string activeSkillOutput;

        do
        {
            if (activeSkill.currentLevel == 0) {
                activeSkillOutput = "Puedes comprar una habilidad activa en la tienda a cambio de OVOPOINTS.";
            } else if(activeSkill.GetCooldown() <= 0) {
                activeSkillOutput = "Tu habilidad esta disponible!";
            } else {
                activeSkillOutput = $"podras activar tu habilidad en {activeSkill.GetCooldown()} clicks";
            }
            Console.WriteLine($"""

                ===============================================================

                 ingresa la accion deseada
                     c: Click
                     s: Abrir tienda
                     1: Activar Habilidad
                     n: Cambiar nombre del jugador
                     m: Cambiar nombre del ovo

                 -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -  

                 Ovo: {mainOvo.name}
                 Jugador: {mainPlayer.name}
                  
                 Puntos restantes hasta eclosionar:
                 {mainOvo.GetTicksToHatch()}
                 Restas {mainPlayer.GetTapPower()} puntos por click.
                 { activeSkillOutput }

                 Siguiente ovopoint en {mainOvo.GetTapsToReward()} clicks.

                ===============================================================

                """);

            input = Console.ReadKey(true);

            switch (input.Key.ToString())
            {
                case "C":
                    activeSkill.SetCooldown(activeSkill.GetCooldown() - 1);
                    activeSkill.DeactivateSkill(mainPlayer);
                    stopPlaying = mainOvo.Click(mainPlayer);
                    if (activeSkill.currentlyActive)
                    {
                        activeSkill.SetLifetime(activeSkill.GetLifetime() - 1);
                    }
                    break;
                case "S":
                    gameShop.OpenShop(mainPlayer, activeSkill, passiveSkill);
                    break;
                case "1":
                case "D1":
                    if (activeSkill.GetCooldown() > 0)
                    {
                        Console.WriteLine("No puedes usar tu habilidad, aún esta en enfriamento.");
                    }
                    else
                    {
                        Console.WriteLine("Has activado tu habilidad, ahora tus puntos son multiplicados temporalmente");
                        activeSkill.UseSkill(mainPlayer);
                    }
                    break;
                default:
                    Console.WriteLine("Por favor, ingresa una opcion valida.");
                    break;
            }
        } while (!stopPlaying);
        Console.ReadKey(true);
    }
}