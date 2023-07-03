using EmpleadoCRUD.Entities;
using EmpleadoCRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmpleadoCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Empleado empl = new Empleado();
        EmpleadoServices services = new EmpleadoServices();
        private void Button_Click_Agregar(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txt_Nombre.Text))
            {
                MessageBox.Show("Falta el nombre del empleado");
            }
            else if (String.IsNullOrWhiteSpace(txt_Apellido.Text))
            {
                MessageBox.Show("Falta el apellido del empleado");
            }
            else if (String.IsNullOrWhiteSpace(txt_Correo.Text))
            {
                MessageBox.Show("Falta el correo del empleado");
            }
            else
            {
                empl.Nombre = txt_Nombre.Text;
                empl.Apellido = txt_Apellido.Text;
                empl.Correo = txt_Correo.Text;
                services.Add(empl);

                txt_Nombre.Clear();
                txt_Apellido.Clear();
                txt_Correo.Clear();
                MessageBox.Show("Los datos se guardan correctamente");
            }
        }

        private void Btt_Ver_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse((txt_Id.Text));
            Empleado empleado = services.Read(Id);
            txt_Nombre.Text = empleado.Nombre;
            txt_Correo.Text = empleado.Correo;
            txt_Fecha.Text = empleado.FechaRegistro.ToString();
            txt_Apellido.Text = empleado.Apellido;
        }

        private void Btt_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_Id.Text, out int id))
            {
                Empleado empleadoActualizado = new Empleado()
                {
                    Nombre = txt_Nombre.Text,
                    Apellido = txt_Apellido.Text,
                    Correo = txt_Correo.Text,
                    FechaRegistro = DateTime.Now
                };

                services.Editar(id, empleadoActualizado);

                MessageBox.Show("Empleado actualizado correctamente");

                txt_Id.Clear();
                txt_Nombre.Clear();
                txt_Apellido.Clear();
                txt_Correo.Clear();
            }
            else
            {
                MessageBox.Show("Ocurrior un erro");
            }
        }

        private void Btt_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_Id.Text, out int id))
            {
                services.Eliminar(id);

                MessageBox.Show("Empleado eliminado correctamente");

                txt_Id.Clear();
                txt_Nombre.Clear();
                txt_Apellido.Clear();
                txt_Correo.Clear();
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
            }
        }
    }
}
