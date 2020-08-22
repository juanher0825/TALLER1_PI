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
using Taller1.model;

namespace Taller1
{
    public partial class Form1 : Form
    {
        DataTable tabla;
        DatoList list = new DatoList();
        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //
                labelRuta.Text = openFileDialog1.FileName;

                load(openFileDialog1.FileName);
            }
        }

        private void load(String a)
        {
            String[] lineas = File.ReadAllLines(a);

           for(int i = 1; i<lineas.Length; i++)
            {
                String[] valores = lineas[i].Split(',');

                list.addDato(new Dato(valores[0], valores[1], valores[2], valores[3] + valores[4], valores[5]));

                //Console.WriteLine(valores[0] + " " + valores[1] + " " + valores[2] + " " + valores[3] + valores[4]
                    //+ " " + valores[5]);
            }
            fill();
        }

        private void Iniciar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("REGION");
            tabla.Columns.Add("CODE DANE DEL DEPARTAMENTO");
            tabla.Columns.Add("DEPARTAMENTO");
            tabla.Columns.Add("CODE DANE DEL MUNICIPIO");
            tabla.Columns.Add("MUNICIPIO");
            grilla.DataSource = tabla;
        }

        private void fill()
        {
            foreach (var item in list.getDatos())
            {
                DataRow fila = tabla.NewRow();
                fila[0] = item.getRegion();
                fila[1] = item.getCodeD();
                fila[2] = item.getDepartment();
                fila[3] = item.getCodeM();
                fila[4] = item.getMunicipio();

                tabla.Rows.Add(fila);
            }
        }

        
    }
}
