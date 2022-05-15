using Gtk;

namespace PassGen
{
    /// <summary> Represents the main window of the application. </summary>
    internal class MainWindow : Window
    {
        /// <summary> The program's "enable lowercase" check button. </summary>
        internal CheckButton EnableLowercase = new CheckButton("Enable lowercase characters");
        /// <summary> The program's "enable uppercase" check button. </summary>
        internal CheckButton EnableUppercase = new CheckButton("Enable uppercase characters");
        /// <summary> The program's "enable numeric" check button. </summary>
        internal CheckButton EnableNumeric = new CheckButton("Enable numeric characters");
        /// <summary> The program's "enable special" check button. </summary>
        internal CheckButton EnableSpecial = new CheckButton("Enable special characters");
        /// <summary> The program's "password length" scale. </summary>
        internal Scale PasswordLength = new Scale(Orientation.Horizontal, 1.0, 100.0, 1.0);
        /// <summary> The program's "generate password" button.
        internal Button GenerateButton = new Button("Generate password");
        /// <summary> Displays the generated password. </summary>
        internal Label PasswordLabel = new Label();

        /// <summary> Constructs the main window. </summary>
        public MainWindow() : base("Password Generator")
        {
            // Setting default values.
            this.EnableLowercase.Active = true;
            this.EnableUppercase.Active = true;
            this.EnableNumeric.Active = true;
            this.EnableSpecial.Active = true;
            this.PasswordLength.Value = 50.0;
            // Setting up events.
            this.DeleteEvent += (s, a) => Application.Quit();
            this.GenerateButton.Clicked += (s, a) => Program.GeneratePassword();
            // Creating UI.
            VBox layout = new VBox();
            layout.Add(this.EnableLowercase);
            layout.Add(this.EnableUppercase);
            layout.Add(this.EnableNumeric);
            layout.Add(this.EnableSpecial);
            layout.Add(this.PasswordLength);
            layout.Add(this.GenerateButton);
            layout.Add(this.PasswordLabel);
            this.Add(layout);
            // Showing the window.
            this.ShowAll();
        }
    }
}
