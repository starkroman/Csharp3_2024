using System;

public class Dice
{
    public int[] RollResults { get; private set; }
    private Random random;

    /// <summary>
    /// Počet použitých kostek mi definuje velikost pole, kam uložím jednotlivé hody
    /// </summary>
    /// <param name="numberOfDice"></param>
    public Dice(int numberOfDice)
    {
        RollResults = new int[numberOfDice];
        random = new Random();
    }

    /// <summary>
    /// Metoda pro vygenerování náhodného hodu všemi kostkami
    /// </summary>
    public void RollAll()
    {
        for (int i = 0; i < RollResults.Length; i++)
        {
            RollResults[i] = random.Next(1, 7); // Vygeneruje náhodné číslo od 1 do 6 a uloží na pozici v poli
        }
    }
}

