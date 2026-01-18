using System.Text.RegularExpressions;

public static class Validator
{
    public static bool ValidateUsername(string username)
    {
        return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
    }

    public static bool ValidatePassword(string password)
    {
        if (password.Length != 12) return false;
        if (!Regex.IsMatch(password, @"[a-z]")) return false;
        if (!Regex.IsMatch(password, @"[A-Z]")) return false;
        return true;
    }
}
