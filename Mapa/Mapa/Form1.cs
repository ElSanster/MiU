using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapa
{

    public partial class Form1 : Form
    {
        class Lugar
        {
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Piso { get; set; }

            public override string ToString()
            {
                return $"{Nombre} - {Tipo}";
            }
        }

        private List<Lugar> lugares = new List<Lugar>();
        private TextBox txtBuscar;
        private ComboBox cmbTipo;
        private ListBox lstResultados;
        private Label lblDetalles;
        private PictureBox picSelected;

        public Form1()
        {
            InitializeComponent();
            InicializarControles();
            CargarLugares();
            FiltrarLugares();
        }

        private void InicializarControles()
        {

            this.Text = "Mapa Inteligente Universitario";
            this.Size = new Size(700, 380);
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10);


            GroupBox groupBusqueda = new GroupBox()
            {
                Text = "Buscar y Filtrar",
                Left = 10,
                Top = 10,
                Width = 410,
                Height = 90
            };
            this.Controls.Add(groupBusqueda);

            txtBuscar = new TextBox()
            {
                Left = 10,
                Top = 30,
                Width = 200,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.WhiteSmoke
            };
            txtBuscar.TextChanged += (s, e) => FiltrarLugares();
            groupBusqueda.Controls.Add(txtBuscar);

            cmbTipo = new ComboBox()
            {
                Left = 220,
                Top = 30,
                Width = 170,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White
            };
            cmbTipo.Items.AddRange(new string[] { "Todos", "Oficina", "Laboratorio", "Eventos", "Zona libre", "Aulas", "Sótano 1", "Piso 2", "Piso 6", "Piso 10", "Piso 12", "Piso 14" });
            cmbTipo.SelectedIndex = 0;
            cmbTipo.SelectedIndexChanged += (s, e) => FiltrarLugares();
            groupBusqueda.Controls.Add(cmbTipo);

            lstResultados = new ListBox()
            {
                Left = 10,
                Top = 110,
                Width = 410,
                Height = 250,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.Honeydew
            };
            lstResultados.SelectedIndexChanged += (s, e) => MostrarDetalles();
            this.Controls.Add(lstResultados);


            lblDetalles = new Label()
            {
                Left = 10,
                Top = 370,
                Width = 410,
                Height = 70,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.DarkSlateGray
            };
            lblDetalles.Text = "Selecciona un lugar para ver más información.";
            this.Controls.Add(lblDetalles);

            picSelected = new PictureBox()
            {
                Left = 450,
                Top = 10,
                Width = 340,
                Height = 340,
                Image = Properties.Resources.VistaGeneral_PlaceHolder,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Gray,
            };
            this.Controls.Add(picSelected);
            picSelected.DoubleClick += (s, e) => ZoomPicSelected();

        }

        private void ZoomPicSelected()
        {
            if (picSelected.Height == 340 && picSelected.Width == 340)
            {
                picSelected.Height = 650;
                picSelected.Width = 650;
                this.Size = new Size(picSelected.Width + 474, picSelected.Height + 60);
            }
            else
            {
                picSelected.Height = 340;
                picSelected.Width = 340;
                this.Size = new Size(814, 485);
            }

        }

        private void CargarLugares()
        {
            //Zonas del sótano 1
            lugares.Add(new Lugar { Nombre = "Laboratorio de suelos -101", Tipo = "Laboratorio", Piso = "Sótano 1" });

            lugares.Add(new Lugar { Nombre = "Laboratorio de aguas -101", Tipo = "Laboratorio", Piso = "Sótano 1" });
            //Existen laboratorios de suelo y agua?!??!!
            lugares.Add(new Lugar { Nombre = "Plazoleta de comidas", Tipo = "Zona libre", Piso = "Sótano 1" });
            lugares.Add(new Lugar { Nombre = "Cafetería Sótano", Tipo = "Zona libre", Piso = "Sótano 1" });
            lugares.Add(new Lugar { Nombre = "Bienestar CDP", Tipo = "Oficina", Piso = "Sótano 1" });
            lugares.Add(new Lugar { Nombre = "Centro de Ciclistas", Tipo = "Parqueadero", Piso = "Sótano 1" });

            //Zonas del piso 2
            lugares.Add(new Lugar { Nombre = "Zona Administrativa", Tipo = "Oficina", Piso = "Piso 2" });

            lugares.Add(new Lugar { Nombre = "Atención al cliente", Tipo = "Oficina", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Agencia de empleo", Tipo = "Oficina", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Cafetería", Tipo = "Local", Piso = "Piso 2" });

            //Zonas del piso 6
            lugares.Add(new Lugar { Nombre = "Auditoría", Tipo = "Eventos", Piso = "Piso 6" });

            lugares.Add(new Lugar { Nombre = "Aula de Prácticas médicas 601", Tipo = "Laboratorio", Piso = "Piso 6" });
            lugares.Add(new Lugar { Nombre = "Aula de Prácticas médicas 602", Tipo = "Laboratorio", Piso = "Piso 6" });
            lugares.Add(new Lugar { Nombre = "Aula de Prácticas médicas 603", Tipo = "Laboratorio", Piso = "Piso 6" });
            lugares.Add(new Lugar { Nombre = "Aula de Prácticas médicas 604", Tipo = "Laboratorio", Piso = "Piso 6" });
            lugares.Add(new Lugar { Nombre = "Lobby de eventos", Tipo = "Zona libre", Piso = "Piso 6" });
            lugares.Add(new Lugar { Nombre = "Aula de Aprendizaje ABP 605", Tipo = "Aulas", Piso = "Piso 6" });

            //Zonas del piso 10
            lugares.Add(new Lugar { Nombre = "Maloka", Tipo = "Zona libre", Piso = "Piso 10" });

            lugares.Add(new Lugar { Nombre = "Terraza", Tipo = "Zona libre", Piso = "Piso 10" });
            lugares.Add(new Lugar { Nombre = "Aula de aprendizaje ABP 1001", Tipo = "Aulas", Piso = "Piso 10" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de producción sonora 1002", Tipo = "Laboratorio", Piso = "Piso 10" });
            lugares.Add(new Lugar { Nombre = "Laboratorio Datacenter 1003", Tipo = "Laboratorio", Piso = "Piso 10" });
            lugares.Add(new Lugar { Nombre = "Laboratorio Datacenter 1004", Tipo = "Laboratorio", Piso = "Piso 10" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Física 1005", Tipo = "Laboratorio", Piso = "Piso 10" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Física 1006", Tipo = "Laboratorio", Piso = "Piso 10" });

            //Zonas del piso 12
            lugares.Add(new Lugar { Nombre = "Aula Magistral 901", Tipo = "Aulas", Piso = "Piso 12" });

            lugares.Add(new Lugar { Nombre = "Laboratorio de Redes 902", Tipo = "Laboratorio", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Redes 903", Tipo = "Laboratorio", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Redes 904", Tipo = "Laboratorio", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 905", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 906", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 907", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 908", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 909", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 910", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Sala de proyecto 911", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Aula de aprendizaje ABP agrupable 912", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Aula Magistral 913", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Aula de aprendizae ABP 914", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Aula de aprendizae ABP 915", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Aula de aprendizae ABP 916", Tipo = "Aulas", Piso = "Piso 12" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Eléctronica 917", Tipo = "Laboratorio", Piso = "Piso 12" });

            //Zonas del piso 14 (Se me están cansando las manos)
            lugares.Add(new Lugar { Nombre = "Laboratorio DevOps 1401", Tipo = "Laboratorio", Piso = "Piso 14" });

            lugares.Add(new Lugar { Nombre = "Laboratorio DevOps 1402", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Laboratorio DevOps 1403", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Datos 1404", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Datos 1405", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Datos 1406", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Laboratorio de Producción sonora 1407", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Laboratorio IoT 1408", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Labotatorio de Cómputo 1409", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Labotatorio de Cómputo 1410", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Labotatorio de Cómputo 1411", Tipo = "Laboratorio", Piso = "Piso 14" });
            lugares.Add(new Lugar { Nombre = "Labotatorio de Cómputo 1412", Tipo = "Laboratorio", Piso = "Piso 14" });


        }

        private void FiltrarLugares()
        {
            string texto = txtBuscar.Text.ToLower();
            string tipo = cmbTipo.SelectedItem.ToString();

            var filtrados = lugares.Where(l =>
                (tipo == "Todos" || l.Tipo == tipo || l.Piso == tipo) &&
                l.Nombre.ToLower().Contains(texto)).ToList();

            lstResultados.Items.Clear();
            foreach (var lugar in filtrados)
            {
                lstResultados.Items.Add(lugar);
            }

            lblDetalles.Text = "Selecciona un lugar para ver más información.";
            picSelected.Image = Properties.Resources.Home_PlaceHolder;
        }

        private void MostrarDetalles()
        {
            if (lstResultados.SelectedItem is Lugar lugarSeleccionado)
            {
                lblDetalles.Text = $"Nombre: {lugarSeleccionado.Nombre}\n" +
                                   $"Tipo: {lugarSeleccionado.Tipo}\n" +
                                   $"Ubicación: {lugarSeleccionado.Piso}";
                switch (lugarSeleccionado.Piso)
                {
                    case "Sótano 1":
                        picSelected.Image = Properties.Resources.Sotano1;
                        break;
                    case "Piso 2":
                        picSelected.Image = Properties.Resources.Piso2;
                        break;
                    case "Piso 6":
                        picSelected.Image = Properties.Resources.Piso2;
                        break;
                    case "Piso 10":
                        picSelected.Image = Properties.Resources.Piso10;
                        break;
                    case "Piso 12":
                        picSelected.Image = Properties.Resources.Piso12;
                        break;
                    case "Piso 14":
                        picSelected.Image = Properties.Resources.Piso14;
                        break;
                    default:
                        picSelected.Image = Properties.Resources.Home_PlaceHolder;
                        break;
                }
            }
            else
            {
                lblDetalles.Text = "Selecciona un lugar para ver más información.";
                picSelected.Image = Properties.Resources.Home_PlaceHolder;
            }
        }
    }
}
