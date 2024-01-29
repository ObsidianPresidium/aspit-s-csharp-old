namespace aspit_s_csharp;

public class GameOfLuck
{
    static Random rnd = new Random();
    
    class Player
    {
        private List<int> treasureOnTheLine = new List<int>();
        private int treasureChest = 0;

        private void updateTreasure(int[] acquiredTreasure)
        {
            foreach (int treasure in acquiredTreasure)
            {
                treasureChest += treasure;
            }
        }

        public string playerName = "Spiller";

        public void printTreasure()
        {
            Console.WriteLine($"{this.playerName} har {this.treasureChest} point.");
        }
        
        public void beginTurn(bool showIntroduction = true)
        {
            if (showIntroduction) Console.WriteLine($"Det er {playerName}s tur nu");
            string keyString = "";
            do
            {
                Console.WriteLine("Hvad vil du gøre?");
                Console.WriteLine("  (S)pille");
                Console.WriteLine("  Se (O)versigt");
                Console.Write(": ");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                keyString = cki.Key.ToString().ToLower();
                if (keyString == "s")
                {
                    this.turn();
                }
                else if (keyString == "o")
                {
                    Console.WriteLine("Oversigt over skattekister:");
                    foreach (Player player in players)
                    {
                        player.printTreasure();
                    }
                    this.beginTurn(false);
                }
            } while (keyString != "s" && keyString != "o");
        }

        private void turn()
        {
            int number = rnd.Next(1, 7);
            treasureOnTheLine.Add(number);

            if (number == 1)
            {
                treasureOnTheLine.Clear();
                Console.Write("Du slog en ener");
                if (treasureOnTheLine.Count != 0) Console.Write(" og mister det du har væddet");
                Console.WriteLine("!  Næste spillers tur.");
            }
            else
            {

                int total = 0;
                Console.Write("Du har indtil videre slået: ");
                foreach (int treasure in treasureOnTheLine)
                {
                    Console.Write($"{treasure}, ");
                    total += treasure;
                }

                Console.WriteLine();
                Console.WriteLine($"Du har i denne runde i alt slået for {total} point.");

                if (treasureChest + total >= 100)
                {
                    Console.WriteLine($"{this.playerName} har i alt {treasureChest + total} point, og har derfor vundet spillet!");
                    Environment.Exit(0);
                }

                string keyString;
                do
                {
                    Console.Write("Vil du slå igen? (Y/N): ");
                    ConsoleKeyInfo cki = Console.ReadKey();
                    Console.WriteLine();
                    keyString = cki.Key.ToString().ToLower();
                    if (keyString == "y")
                    {
                        this.turn();
                    } 
                    else if (keyString == "n")
                    {
                        treasureChest += total;
                        treasureOnTheLine.Clear();
                    }
                } while (keyString != "n" && keyString != "y");

            }
        }
    }

    static List<Player> players = new List<Player>();
    public void Main()
    {
        
        uint numPlayers = 0;
        do
        {
            Console.WriteLine("Hvor mange spillere skal spille?");
            string playersString = Console.ReadLine();
            try
            {
                numPlayers = uint.Parse(playersString);
                uint test = numPlayers - 2; // test om antal spillere er 1 eller 0. Hvis det, generér en exception.
            }
            catch
            {
                Console.WriteLine("Ugyldigt antal spillere valgt. Antal spillere skal være over 1");
            }
        } while (numPlayers == 0);

        for (int i = 0; i < numPlayers; i++)
        {
            Console.Write($"Spiller {i + 1} hedder: ");
            string name = Console.ReadLine();
            players.Add(new Player() { playerName = name });
        }

        int round = 1;
        
        while (true)
        {
            Console.WriteLine($"--- Runde {round} ---");
            foreach (Player player in players)
            {
                player.beginTurn();
            }

            round++;
        }
    }
}