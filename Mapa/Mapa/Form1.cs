using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                this.Size = new Size(450, 500);
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
            cmbTipo.Items.AddRange(new string[] { "Todos", "Oficina", "Laboratorio", "Eventos", "Local C.", "Enfermería" });
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
            }

            private void CargarLugares()
            {
            lugares.Add(new Lugar { Nombre = "Atención al cliente", Tipo = "Oficina", Piso = "Piso 1" });
            lugares.Add(new Lugar { Nombre = "Oficina de empleo", Tipo = "Oficina", Piso = "Piso 1" });
            lugares.Add(new Lugar { Nombre = "Cafetería", Tipo = "Local C.", Piso = "Piso 1" });
            lugares.Add(new Lugar { Nombre = "Salón Magistral 01", Tipo = "Eventos", Piso = "Piso 1" });
            lugares.Add(new Lugar { Nombre = "Enfermería", Tipo = "Enfermería", Piso = "Piso 1" });

            lugares.Add(new Lugar { Nombre = "Sala de profesores", Tipo = "Oficina", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Rectoría", Tipo = "Oficina", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Secretaría", Tipo = "Oficina", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Coordinación", Tipo = "Oficina", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Laboratorio Computación 1001", Tipo = "Laboratorio", Piso = "Piso 2" });
            lugares.Add(new Lugar { Nombre = "Laboratorio Computación 1002", Tipo = "Laboratorio", Piso = "Piso 2" });

            lugares.Add(new Lugar { Nombre = "Laboratorio Multimedia 1023", Tipo = "Laboratorio", Piso = "Piso 3" });
            lugares.Add(new Lugar { Nombre = "Laboratorio Innovación 2102", Tipo = "Laboratorio", Piso = "Piso 3" });
            lugares.Add(new Lugar { Nombre = "Salón Magistral 02", Tipo = "Eventos", Piso = "Piso 3" });
        }

            private void FiltrarLugares()
            {
                string texto = txtBuscar.Text.ToLower();
                string tipo = cmbTipo.SelectedItem.ToString();

                var filtrados = lugares.Where(l =>
                    (tipo == "Todos" || l.Tipo == tipo) &&
                    l.Nombre.ToLower().Contains(texto)).ToList();

                lstResultados.Items.Clear();
                foreach (var lugar in filtrados)
                {
                    lstResultados.Items.Add(lugar);
                }

                lblDetalles.Text = "Selecciona un lugar para ver más información.";
            }

            private void MostrarDetalles()
            {
                if (lstResultados.SelectedItem is Lugar lugarSeleccionado)
                {
                    lblDetalles.Text = $"Nombre: {lugarSeleccionado.Nombre}\n" +
                                       $"Tipo: {lugarSeleccionado.Tipo}\n" +
                                       $"Ubicación: {lugarSeleccionado.Piso}";
                }
                else
                {
                    lblDetalles.Text = "Selecciona un lugar para ver más información.";
                }
            }
        }
    }
