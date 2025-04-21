
// OldPhone.cs
using System;
using System.Text;
using System.Collections.Generic;

public class OldPhone
{
    private static readonly Dictionary<char, string> keypad = new()
    {
        { '1', "&'(" }, { '2', "ABC" }, { '3', "DEF" },
        { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
        { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" },
        { '0', " " }
    };

    public static string OldPhonePad(string input)
    {
        StringBuilder output = new();
        StringBuilder currentSequence = new();

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

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
                if (output.Length > 0)
                    output.Remove(output.Length - 1, 1);
                currentSequence.Clear();
            }
            else if (c == '#')
            {
                AppendCharFromSequence(currentSequence, output);
                break;
            }
        }

        return output.ToString();
    }

    private static void AppendCharFromSequence(StringBuilder seq, StringBuilder output)
    {
        if (seq.Length == 0) return;

        char key = seq[0];
        if (!keypad.ContainsKey(key)) return;

        string letters = keypad[key];
        int index = (seq.Length - 1) % letters.Length;

        output.Append(letters[index]);
    }
}

// Sample usage:
class Program
{
    static void Main()
    {
        Console.WriteLine(OldPhone.OldPhonePad("33#"));                // E
        Console.WriteLine(OldPhone.OldPhonePad("227*#"));              // B
        Console.WriteLine(OldPhone.OldPhonePad("4433555 555666#"));    // HELLO
        Console.WriteLine(OldPhone.OldPhonePad("8 88777444666*664#")); // TEST
    }
}
