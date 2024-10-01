using System;
public class Game
{
    public Dice Dice { get; set; }
    public int Score { get; private set; }

    public Game()
    {
        System.Console.Write("Zadej počet kostek [1-6], kterými budeš házet: ");
        string pocetText = Console.ReadLine();
        int pocet = 0;
        if(int.TryParse(pocetText, out pocet))
        {
            Dice = new Dice(pocet); // Inicializace počtem kostek
            Score = 0;
        }
        else
        {
            Console.WriteLine("Zadej číslo od 1 - 6!");
        }
    }

    /// <summary>
    /// Spuštění hry
    /// </summary>
    public void Play()
    {
        Dice.RollAll();
        Console.WriteLine("Počítač hodil kostkami a výsledek je:");
        Console.WriteLine(string.Join(", ", Dice.RollResults));

        Score = CalculateScore(Dice.RollResults);
        Console.WriteLine($"Vaše skóre je: {Score} bodů");
    }

    /// <summary>
    /// Metoda pro výpočet skóre na základě pravidel hry Greed
    /// </summary>
    /// <param name="diceResults">Pole obsahující hodnoty hodu pěti kostkami</param>
    /// <returns>Celkové skóre</returns>
    private int CalculateScore(int[] diceResults)
    {
        int score = 0;
        var counts = new Dictionary<int, int>();

        // Spočítání výskytu jednotlivých hodnot kostek
        foreach (var die in diceResults)
        {
            if (counts.ContainsKey(die))
                counts[die]++;
            else
                counts[die] = 1;
        }

        // Vyhodnocení skóre na základě pravidel
        foreach (var entry in counts)
        {
            int value = entry.Key;
            int count = entry.Value;

            // Trojité jedničky
            if (value == 1 && count >= 3)
            {
                score += 1000;
                count -= 3; // Odečíst 3 jedničky, které byly použity pro skóre
            }
            // Trojité ostatní hodnoty (2, 3, 4, 5, 6)
            else if (count >= 3)
            {
                score += value * 100;
                count -= 3; // Odečíst 3 kostky, které byly použity pro skóre
            }

            // Jednotlivé jedničky a pětky
            if (value == 1)
            {
                score += count * 100; // Každá jednotlivá jednička je za 100 bodů
            }
            else if (value == 5)
            {
                score += count * 50; // Každá jednotlivá pětka je za 50 bodů
            }
        }

        return score;
    }
}

