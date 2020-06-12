using System.Windows.Forms;

namespace PVA_Snake
{
    //Prompt použitý ze Stack Overflow
    public static class Prompt
    {
        public static string ShowDialog()
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 130,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Your name",
                StartPosition = FormStartPosition.CenterScreen
            };
            TextBox textBox = new TextBox() { Left = 45, Top = 20, Width = 400 };
            Button confirmation = new Button() { Text = "OK", Left = 195, Width = 100, Top = 50, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}