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
            chart1.Titles.Add("Municipios por departamento");
            chart1.Series["s1"].IsValueShownAsLabel = true;
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
            var total = list.getDatos().Count();
            var choco = 0;
            var huila = 0;
            var norteDeSantander = 0;
            var valleDelCauca = 0;
            var cauca = 0;
            var bolivar = 0;
            var tolima = 0;
            var narino = 0;
            var santander = 0;
            var cundinamarca = 0;
            var boyaca = 0;
            var antioquia = 0;
            var otro = 0;
            foreach (var item in list.getDatos())
            {
                if (item.getDepartment() == "Antioquia")
                {
                    antioquia += 1;
                }else if(item.getDepartment() == "Boyacá")
                {
                    boyaca += 1;
                }else if(item.getDepartment() == "Cundinamarca")
                {
                    cundinamarca += 1;
                }else if(item.getDepartment() == "Santander")
                {
                    santander += 1;
                }else if (item.getDepartment() == "Nariño")
                {
                    narino += 1;
                }else if(item.getDepartment() == "Tolima")
                {
                    tolima += 1;
                }else if (item.getDepartment() == "Bolivar")
                {
                    bolivar += 1;
                }else if(item.getDepartment() == "Cauca")
                {
                    cauca += 1; 
                }else if(item.getDepartment() == "Valle del Cauca")
                {
                    valleDelCauca += 1;
                }else if(item.getDepartment() == "Norte de Santander")
                {
                    norteDeSantander += 1;
                }else if (item.getDepartment() == "Huila")
                {
                    huila += 1;
                }else if (item.getDepartment() == "Chocó")
                {
                    choco += 1;
                }
                else
                {
                    otro += 1;
                }
            }

            chart1.Series["s1"].Points.AddXY("Otro",otro);
            chart1.Series["s1"].Points.AddXY("Antioquia", antioquia);
            chart1.Series["s1"].Points.AddXY("Boyacá", boyaca);
            chart1.Series["s1"].Points.AddXY("Cundinamarca", cundinamarca);
            chart1.Series["s1"].Points.AddXY("Santander", santander);
            chart1.Series["s1"].Points.AddXY("Nariño", narino);
            chart1.Series["s1"].Points.AddXY("Tolima", tolima);
            chart1.Series["s1"].Points.AddXY("Bolivar", bolivar);
            chart1.Series["s1"].Points.AddXY("Cauca", cauca);
            chart1.Series["s1"].Points.AddXY("Valle de Cauca", valleDelCauca);
            chart1.Series["s1"].Points.AddXY("Norte de Santander", norteDeSantander);
            chart1.Series["s1"].Points.AddXY("Huila", huila);
            chart1.Series["s1"].Points.AddXY("Chocó", choco);

        }


        private void comboBox_FilterOptions(object sender, EventArgs e)
        {
            tabla.DefaultView.RowFilter = $"DEPARTAMENTO LIKE '{FilterOptions.Text}%'";
        }
    }
}
