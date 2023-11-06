using lab5;

class Statistic: ILab8DictionaryPart
{
    public Dictionary<string, TeamResult> stats = new Dictionary<string, TeamResult>();
    public Dictionary<string, TeamResult> Stats => stats;

    

    public void AddGame(string firstName, int firstScore, string secondName, int secondScore)
    {
        if (!stats.ContainsKey(firstName))
        {
            stats[firstName] = new TeamResult();
        }

        if (!stats.ContainsKey(secondName))
        {
            stats[secondName] = new TeamResult();
        }

        stats[firstName].NumberOfGames++;
        stats[secondName].NumberOfGames++;

        if (firstScore > secondScore)
        {
            stats[firstName].Wins++;
            stats[firstName].SumOfPoints += 3;
            stats[secondName].Loses++;
        }
        else if (firstScore < secondScore)
        {
            stats[secondName].Wins++;
            stats[secondName].SumOfPoints += 3;
            stats[firstName].Loses++;
        }
        else
        {
            stats[firstName].Draws++;
            stats[secondName].Draws++;
            stats[firstName].SumOfPoints++;
            stats[secondName].SumOfPoints++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ILab8DictionaryPart statistics = new Statistic();
        
        statistics.AddGame("TeamA", 2, "TeamB", 1);
        statistics.AddGame("TeamB", 0, "TeamC", 2);
        statistics.AddGame("TeamA", 1, "TeamC", 1);

        foreach (var kvp in statistics.Stats)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.NumberOfGames} games, {kvp.Value.Wins} wins, {kvp.Value.Draws} draws, {kvp.Value.Loses} loses, {kvp.Value.SumOfPoints} points");
        }

        string filePath = "football_stats.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var kvp in statistics.Stats)
            {
                writer.WriteLine($"{kvp.Key}:{kvp.Value.NumberOfGames}:{kvp.Value.Wins}:{kvp.Value.Draws}:{kvp.Value.Loses}:{kvp.Value.SumOfPoints}");
            }
        }

        Console.WriteLine("Statistics saved to file.");
    }
}





