using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Registro_Basico___C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Leave += Validar_Nombres;
            textBox2.Leave += Validar_Nombres;
            textBox3.Leave += Validar_Edad;
            textBox4.Leave += Validar_Estatura;
            textBox5.Leave += Validar_Telefono;
        }

        private bool Valid_Int(string str)
        {
            int result;
            return int.TryParse(str, out result);
        }
        private bool Valid_Float(string str)
        {
            decimal result;
            return decimal.TryParse(str, out result);
        }
        private bool Valid_Text(string str)
        {
            return str.All(char.IsLetter);
        }
        private bool Valid_Digit(string str)
        {
            return str.Length == 10 && str.All(char.IsDigit);
        }

        private void Validar_Edad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!Valid_Int(textBox.Text))
                {
                    MessageBox.Show("Por favor, ingresa una Edad valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }

        private void Validar_Estatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!Valid_Float(textBox.Text))
                {
                    MessageBox.Show("Por favor, ingresa un numero decimal valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }

        private void Validar_Nombres(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!Valid_Text(textBox.Text))
                {
                    MessageBox.Show("Por favor, ingresa un texto valido para el Nombre y Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }

        private void Validar_Telefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!Valid_Digit(textBox.Text))
                {
                    MessageBox.Show("Por favor, ingresa un numero valido de 10 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombres, apellidos;
            int edad;
            decimal estatura;
            long telefono;
            nombres = textBox1.Text;
            apellidos = textBox2.Text;
            edad = int.Parse(textBox3.Text);
            estatura = decimal.Parse(textBox4.Text);
            telefono = long.Parse(textBox5.Text);

            string genero = "";
            if (radioButton1.Checked)
            {
                genero = "Hombre";
            }
            else if (radioButton2.Checked)
            {
                genero = "Mujer";
            }
            string datos = $"Nombres: {nombres}\r\nApellidos: {apellidos}\r\nTelefono: {telefono}\r\nEstatura: {estatura}\r\nEdad: {edad}años\r\nGenero: {genero}";

            string rutaArchivos = "C:\\Users\\Emma\\Documents\\Programación Avanzada\\Registro Basico - C#\\Datos_C#.txt";
            bool archivoExiste = File.Exists(rutaArchivos);

            using (StreamWriter writer = new StreamWriter(rutaArchivos, true))
            {
                writer.WriteLine(datos);
            }
            MessageBox.Show("Datos guardados: \n\n" + datos, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
