﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_ABM
{
    public partial class FormInicio : Form
    {
        private List<Articulo> listaArticulos;
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvDatos.DataSource = listaArticulos;
            cargarImagen(listaArticulos[0].ImagenUrl);
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo articuloSeleccionado = (Articulo)dgvDatos.CurrentRow.DataBoundItem;
            cargarImagen(articuloSeleccionado.ImagenUrl);
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbImagen.Load(url);

            }
            catch (Exception ex)
            {
                pbImagen.Load("https://www.agora-gallery.com/advice/wp-content/uploads/2015/10/image-placeholder.png");
            }
        }
    }
}
