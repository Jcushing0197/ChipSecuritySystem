using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            //create the chip color sides
            List<ColorChip> chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Green),
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Purple),
                new ColorChip(Color.Purple, Color.Orange),
                new ColorChip(Color.Orange, Color.Red)
            };

            List<ColorChip> currentChipsUsed = new List<ColorChip>();
            List<List<ColorChip>> validSequences = new List<List<ColorChip>>();

            Console.WriteLine("Checking for valid sequences...");

            ChipSequenceFinder.FindMostChips(chips, Color.Blue, currentChipsUsed, new List<ColorChip>(), validSequences);

            //Display all of the valid sequences found
            foreach (List<ColorChip> sequence in validSequences)
            {
                Console.WriteLine();
                Console.WriteLine($"Valid Sequence Found: {sequence.Count} chips used.");

                PrintSequence(sequence);
            }

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");

            //Find the sequence with the most chips used
            if (validSequences.Count > 0)
            {
                List<ColorChip> mostChipsUsed = validSequences
                    .OrderByDescending(sequence => sequence.Count)
                    .First();

                Console.WriteLine();
                Console.WriteLine($"Access Granted Using {mostChipsUsed.Count} chips.");
                PrintSequence(mostChipsUsed);
            }
            else 
            {
                Console.WriteLine("No valid sequence found.");
                Console.WriteLine();
                Console.WriteLine("Access Denied.");
            }
        }
        public static void PrintSequence(List<ColorChip> chips)
        {
            Color currentColor = Color.Blue;
            Console.WriteLine(currentColor);

            foreach (ColorChip chip in chips)
            {
                Color nextColor = chip.StartColor == currentColor 
                    ? chip.EndColor 
                    : chip.StartColor;

                Console.WriteLine($"    -> {currentColor}, {nextColor}");

                currentColor = nextColor;
            }

            Console.WriteLine(currentColor);
        }
    }
}
