using System;
using System.Text;
using System.Collections.Generic;

public class OldPhone
{
    // Keypad mapping for old phone layout
    private static readonly Dictionary<char, string> keypad = new()
    {
        { '1', "&'(" }, { '2', "ABC" }, { '3', "DEF" },
        { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
        { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" },
        { '0', " " }
    };

    /// <summary>
    /// Converts a sequence of old phone keypad inputs into text.
    /// Handles pauses (' '), backspaces ('*'), and send ('#').
    /// </summary>
    public static string OldPhonePad(string input)
    {
        var output = new StringBuilder();
        var currentSequence = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                if (currentSequence.Length > 0 && currentSequence[0] != c)
                {
                    AppendCharFromSequence(currentSequence, output);
                    currentSequence.Clear();
                }
                currentSequence.Append(c);
            }
            else if (c == ' ')
            {
                AppendCharFromSequence(currentSequence, output);
                currentSequence.Clear();
            }
            else if (c == '*')
            {
                AppendCharFromSequence(currentSequence, output);
                currentSequence.Clear();

                if (output.Length > 0)
                    output.Remove(output.Length - 1, 1);
            }
            else if (c == '#')
            {
                AppendCharFromSequence(currentSequence, output);
                return output.ToString();
            }
        }

        AppendCharFromSequence(currentSequence, output);
        return output.ToString();
    }

    /// <summary>
    /// Appends the correct character based on the key press sequence.
    /// </summary>
    private static void AppendCharFromSequence(StringBuilder seq, StringBuilder output)
    {
        if (seq.Length == 0) return;

        if (keypad.TryGetValue(seq[0], out string letters))
        {
            int index = (seq.Length - 1) % letters.Length;
            output.Append(letters[index]);
        }
    }
}
