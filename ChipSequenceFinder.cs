using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    public static class ChipSequenceFinder
    {
        public static void FindMostChips(List<ColorChip> remainingChips, Color currentColor, List<ColorChip> currentChipsUsed, List<ColorChip> mostChipsUsed, List<List<ColorChip>> validSequences)
        {
            // Check if destination color has been reached
            if (currentColor == Color.Green)
            {
                        //Print all valid sequences found
                        // Console.WriteLine();
                        // Console.WriteLine($"Valid Sequence Found: {currentChipsUsed.Count} chips used.");
                        // Program.PrintSequence(currentChipsUsed);

                //Save the sequence
                validSequences.Add(new List<ColorChip>(currentChipsUsed));

                        //check the length and update var to ensure the sequence with the most chips is stored
                        // if (currentChipsUsed.Count > mostChipsUsed.Count)
                        // {
                        //     mostChipsUsed.Clear();
                        //     mostChipsUsed.AddRange(currentChipsUsed);
                        // }
            }

            //check all remaining chips
            foreach (ColorChip chip in remainingChips)
            {
                if (chip.StartColor == currentColor || chip.EndColor == currentColor)
                {
                    //find the other sides color
                    Color nextColor = chip.StartColor == currentColor 
                        ? chip.EndColor 
                        : chip.StartColor;

                    //create a new list excluding the used chip
                    List<ColorChip> unusedChips = new List<ColorChip>(remainingChips);
                    
                    unusedChips.Remove(chip);

                    //add chip to current sequence
                    currentChipsUsed.Add(chip);

                    //continue searching for valid sequence from next color
                    FindMostChips(unusedChips, nextColor, currentChipsUsed, mostChipsUsed, validSequences);

                    //Remove chip to try another sequence
                    currentChipsUsed.RemoveAt(currentChipsUsed.Count - 1);
                }
            }
        }
    }
}