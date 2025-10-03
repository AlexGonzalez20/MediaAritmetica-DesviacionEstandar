using System;
using System.Linq;
using System.Windows.Forms;

namespace CalculadoraEstadisticaGUI
{
    public class MainForm : Form
    {
        private TextBox inputBox1;
        private TextBox inputBox2;
        private ComboBox optionBox;
        private Button calcularButton;
        private Label resultLabel;

        public MainForm()
        {
            this.Text = "Calculadora Estadística (Versión con errores)";
            this.Width = 420;
            this.Height = 250;

            // Caja para el primer número
            inputBox1 = new TextBox() { Top = 20, Left = 20, Width = 150, PlaceholderText = "Número 1" };

            // Caja para el segundo número
            inputBox2 = new TextBox() { Top = 20, Left = 200, Width = 150, PlaceholderText = "Número 2" };

            // ComboBox para elegir operación
            optionBox = new ComboBox() { Top = 60, Left = 20, Width = 330 };
            optionBox.Items.Add("Media Aritmética");
            optionBox.Items.Add("Desviación Estándar");
            optionBox.SelectedIndex = 0;

            // Botón calcular
            calcularButton = new Button() { Text = "Calcular", Top = 100, Left = 20, Width = 330 };

            // Label para resultado
            resultLabel = new Label() { Top = 150, Left = 20, Width = 360, Height = 40 };

            // 🚨 Aquí no hay validación: si escribes letras o dejas vacío → excepción
            calcularButton.Click += (s, e) =>
            {
                double num1 = double.Parse(inputBox1.Text);  // si no es número → se rompe
                double num2 = double.Parse(inputBox2.Text);

                double[] numeros = { num1, num2 };

                if (optionBox.SelectedItem.ToString() == "Media Aritmética")
                {
                    resultLabel.Text = $"Media: {numeros.Average():F2}";
                }
                else
                {
                    double media = numeros.Average();
                    double suma = numeros.Sum(x => Math.Pow(x - media, 2));
                    double desviacion = Math.Sqrt(suma / numeros.Length);
                    resultLabel.Text = $"Desviación: {desviacion:F2}";
                }
            };

            this.Controls.Add(inputBox1);
            this.Controls.Add(inputBox2);
            this.Controls.Add(optionBox);
            this.Controls.Add(calcularButton);
            this.Controls.Add(resultLabel);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
