# OldPhonePad - C# Coding Challenge

## Overview
This is a C# implementation of a coding challenge based on simulating input from an old mobile phone keypad. The goal is to convert a sequence of button presses into readable text, replicating how users used to type messages before smartphones.

For example:
```csharp
OldPhonePad("4433555 555666#") => "HELLO"
```

## How It Works
- Each numeric key maps to a set of letters, similar to traditional mobile keypads.
- Pressing a number multiple times cycles through its associated characters.
- A space indicates a pause, which is required to type two characters from the same key.
- The asterisk `*` represents a backspace.
- The pound sign `#` marks the end of input.

### Keypad Mappings
```
2: ABC   3: DEF   4: GHI   5: JKL   6: MNO
7: PQRS  8: TUV   9: WXYZ  0: (space)
```

## Design Approach
The program iterates through the input string character by character. It groups digits into sequences to determine the intended letter. When a different digit or special character is encountered, the group is processed, and the corresponding character is appended to the output. Backspaces remove the last character in the output, and the sequence ends when `#` is detected.

## Example Inputs
```csharp
OldPhonePad("33#") => "E"
OldPhonePad("227*#") => "B"
OldPhonePad("8 88777444666*664#") => "TURING"
```

## File Structure
- `OldPhone.cs`: Main logic
- `Program.cs`: Console runner
- `OldPhoneTests.cs`: Unit tests using xUnit
- `README.md`: Project overview and usage guide

## How to Run the Project
1. Clone the repository or copy the files into a new .NET project.
2. Use the .NET CLI to build and run:

```bash
dotnet build
dotnet run
```

To run tests:
```bash
dotnet test
```

## Notes
The solution was written with readability and clarity in mind. It includes inline documentation and unit tests to ensure correctness for various edge cases.

If you're reviewing this for a technical role, feel free to reach out for further discussion about the approach and design decisions.
