using Gtk;
using PassGen;
using System;
using System.Text;
using TextCopy;

/// <summary> Contains the "Main" method. </summary>
public class Program
{
    /// <summary> The main window of the application. </summary>
    internal static MainWindow? Window = null;

    /// <summary> Main entry point of program. </summary>
    public static void Main()
    {
        // Initialize the application.
        Application.Init();
        Program.Window = new MainWindow();
        // Run the GTK application.
        Application.Run();
    }

    /// <summary> Generates a new password and copies it to the system clipboard. </summary>
    internal static void GeneratePassword()
    {
        const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        const string UPPSERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC = "1234567890";
        const string SPECIAL = "~!@#$%^&*()-_=+[]{}/|\\;:`'\",.<>?";
        if (Program.Window != null)
        {
            // Create the array of chosen character types.
            StringBuilder chars = new StringBuilder();
            if (Program.Window.EnableLowercase.Active)
                chars.Append(LOWERCASE);
            if (Program.Window.EnableUppercase.Active)
                chars.Append(UPPSERCASE);
            if (Program.Window.EnableNumeric.Active)
                chars.Append(NUMERIC);
            if (Program.Window.EnableSpecial.Active)
                chars.Append(SPECIAL);
            // Make sure at least on character type is chosen.
            if (chars.Length > 0)
            {
                // Generate the password and copy it to the system clipboard.
                int passwordLength = (int)Program.Window.PasswordLength.Value;
                StringBuilder password = new StringBuilder(passwordLength);
                Random rng = new Random();
                for (int i = 0; i < passwordLength; ++i)
                    password.Append(chars[rng.Next(chars.Length)]);
                Program.Window.PasswordLabel.Text = $"Generated password: {password}";
                ClipboardService.SetText(password.ToString());
            }
        }
    }
}
