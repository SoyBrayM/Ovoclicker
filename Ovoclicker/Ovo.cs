namespace Ovoclicker;

public class Ovo
{
    public string name;
    private int ticksToHatch = 1000;
    private int tapsToReward = 10;

    public Ovo(string ovoName)
    {
        name = ovoName;
    }

    public bool Click(Player currentPlayer)
    {
        ticksToHatch -= currentPlayer.GetTapPower();
        tapsToReward--;
        if (tapsToReward <= 0)
        {
            Console.WriteLine($"""
                +---------------------------------------+
                |                                       |
                |      ¡¡ Has ganado un OVOPOINT !!     |
                |      Entra a la tienda para usarlo    |
                |                                       |
                +---------------------------------------+
                """);
            Console.ReadKey();
            tapsToReward = 100;
            currentPlayer.SetOvopoints(currentPlayer.GetOvopoints() + 1);
        }

        if (ticksToHatch <= 0)
        {
            return Hatch();
        }
        return false;
    }

    private bool Hatch()
    {
        Console.WriteLine("\n*******************************\nEl ovo eclosiono!!!\n*******************************\n");
        return true;
    }

    public int GetTicksToHatch()
    {
        return ticksToHatch;
    }

    public int GetTapsToReward()
    {
        return tapsToReward;
    }

}
