
// OldPhoneTests.cs
using Xunit;

public class OldPhoneTests
{
    [Fact]
    public void SingleKeyPress_ReturnsCorrectLetter()
    {
        Assert.Equal("E", OldPhone.OldPhonePad("33#"));
    }

    [Fact]
    public void Backspace_RemovesPreviousLetter()
    {
        Assert.Equal("B", OldPhone.OldPhonePad("227*#"));
    }

    [Fact]
    public void PauseAllowsSameKeyReentry()
    {
        Assert.Equal("HELLO", OldPhone.OldPhonePad("4433555 555666#"));
    }

    [Fact]
    public void BackspaceMidway_ModifiesMessageCorrectly()
    {
        Assert.Equal("TEST", OldPhone.OldPhonePad("8 88777444666*664#"));
    }

    [Fact]
    public void EmptyInput_ReturnsEmptyString()
    {
        Assert.Equal("", OldPhone.OldPhonePad("#"));
    }

    [Fact]
    public void MultipleBackspaces_ShouldNotThrow()
    {
        Assert.Equal("A", OldPhone.OldPhonePad("2***2#"));
    }
}
