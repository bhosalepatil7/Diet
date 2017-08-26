namespace DietClientUI
{
    using System.Windows.Forms;
    using System.Drawing;

    public class ApplicationLookAndFeel
    {
        static void ApplyTheme(TextBox c)
        {
            c.Font = new Font("Arial", 12.0f); c.BackColor = Color.Blue; c.ForeColor = Color.White;
        }
        static void ApplyTheme(Label c)
        {
            c.Font = new Font("Arial", 12.0f); c.BackColor = Color.Black; c.ForeColor = Color.White;
        }
        static void ApplyTheme(Form c)
        {
            c.Font = new Font("Arial", 12.0f); c.BackColor = Color.Black; c.ForeColor = Color.White;
        }

        public static void UseTheme(Form form)
        {
            ApplyTheme(form);
            foreach (var c in form.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        ApplyTheme((TextBox)c);
                        break;
                    case "System.Windows.Forms.Label":
                        ApplyTheme((Label)c);
                        break;


                }
            }
        }
    }
}
