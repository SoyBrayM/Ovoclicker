using System;
namespace Ovoclicker
{
    public class Shop
    {


        public string name = "Tienda";
        public int purchases = 0;

        
        public void OpenShop(Player currentPlayer, ActiveSkill activeSkill, PassiveSkill passiveSkill)
        {


            Console.WriteLine("""
            *** *** *** *** *** *** *** *** *** *** *** *** 

             Bienvenido a la tienda. ¿Qué quieres hacer?
                1. Subir de nivel una habilidad
                2. Restablecer las habilidades
                3. Salir de la tienda

            *** *** *** *** *** *** *** *** *** *** *** *** 
            """);

            switch (Console.ReadKey(true).Key.ToString())
            {
                case "1":
                case "D1":
                    // 
                    if (currentPlayer.GetOvopoints() <= 0) {
                        Console.WriteLine("""
                            Lo siento, no tienes OVOPOINTS disponibles,
                            continua jugando para obtenerlos.
                            """);
                        Console.ReadKey();
                    } else
                    {
                        Console.WriteLine("""
                        Que habilidad deseas mejorar?
                            1: Habilidad Pasiva
                            2: Habilidad Activa
                        """);

                        switch (Console.ReadKey().Key.ToString())
                        {
                            case"1":
                            case"D1":
                                LevelUpSkill(passiveSkill, currentPlayer);
                                break;
                            case "2":
                            case"D2":
                                LevelUpSkill(activeSkill, currentPlayer);
                                break;
                            default:
                                Console.WriteLine("Error:\nElige una opcion valida.");
                                break;
                        }
                    }
                    break;

                case "2":
                case "D2":
                    if (purchases <= 0)
                    {
                        Console.WriteLine("""
                            Aún no has obtenido ninguna habilidad, sigue jugando para obtener una.
                            """);
                    } else
                    {
                        ResetSkills(passiveSkill, activeSkill, currentPlayer );
                    }
                    break;

                case "3":
                case "D3":
                    return;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        public void LevelUpSkill(dynamic skill, Player currentPlayer)
        {

            skill.currentLevel += 1;
            skill.UseSkill(currentPlayer);
            currentPlayer.SetOvopoints(currentPlayer.GetOvopoints() - 1);
            purchases++;
        }

        public void ResetSkills(PassiveSkill passiveSkill, ActiveSkill activeSkill, Player currentPlayer)
        {
            passiveSkill.currentLevel = 0;
            activeSkill.currentLevel = 0;
            currentPlayer.SetOvopoints(purchases - 1);
            purchases = 0;
            // Código para restablecer las habilidades de un jugador
        }
    }
}

