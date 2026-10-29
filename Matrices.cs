namespace Main
{
    // las matrices de adyacencia y incidencia
    public partial class App : Form
    {
        private void ConfigurarMatriz(DataGridView dgv)
        {
            dgv.Dock = DockStyle.Fill;   // ocupa toda la pestaña
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //agregar las columnas
        private void AgregarColumna(DataGridView dgv, string nombre, string encabezado, int ancho)
        {
            int idx = dgv.Columns.Add(nombre, encabezado);
            dgv.Columns[idx].Width = ancho;
            dgv.Columns[idx].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private string Num(double n)
        {
            return n.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private void RefrescarMatrices()
        {
            bool dirigido = CheckDirigido.Checked;
            bool ponderado = CheckPonderado.Checked;

            // matriz de adyacencia
            dgvMatrizA.Columns.Clear();
            dgvMatrizA.Rows.Clear();

            AgregarColumna(dgvMatrizA, "vertice", "", 70);
            foreach (var v in vertices)
                AgregarColumna(dgvMatrizA, "col_" + v, v, 55);

            foreach (var f in vertices)
            {
                var celdas = new object[vertices.Count + 1];
                celdas[0] = f;

                for (int j = 0; j < vertices.Count; j++)
                {
                    string c = vertices[j];
                    var a = aristas.FirstOrDefault(x =>
                        (x.Origen == f && x.Destino == c) ||
                        (!dirigido && x.Origen == c && x.Destino == f));

                    celdas[j + 1] = a == null ? "0" : (ponderado ? Num(a.Peso) : "1");
                }

                dgvMatrizA.Rows.Add(celdas);
            }

            //matriz de incidencia
            dgvMatrizI.Columns.Clear();
            dgvMatrizI.Rows.Clear();

            AgregarColumna(dgvMatrizI, "vertice", "", 70);
            for (int k = 0; k < aristas.Count; k++)
            {
                var a = aristas[k];
                string encabezado = a.Origen + (dirigido ? "→" : "-") + a.Destino;
                AgregarColumna(dgvMatrizI, "arista_" + k, encabezado, 70);
            }

            foreach (var v in vertices)
            {
                var celdas = new object[aristas.Count + 1];
                celdas[0] = v;

                for (int k = 0; k < aristas.Count; k++)
                {
                    var a = aristas[k];

                    if (dirigido)
                        celdas[k + 1] = a.Origen == v ? "1" : (a.Destino == v ? "-1" : "0");
                    else
                        celdas[k + 1] = (a.Origen == v || a.Destino == v) ? "1" : "0";
                }

                dgvMatrizI.Rows.Add(celdas);
            }
        }
    }
}
