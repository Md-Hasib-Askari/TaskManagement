using System.Text.RegularExpressions;

public class EmailAddress
{
    public string Value { get; private set; }

    public EmailAddress(string value)
    {
        // Simple validation for example purposes
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException("Invalid email address.");
        }
        Value = value;
    }

    public override string ToString() => Value;
}