namespace Main
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            ConfigurarGrafo();
        }
        List<string> vertices = new List<string>();

        // estructura de una arista y lista de aristas
        private class Arista
        {
            public string Origen;
            public string Destino;
            public double Peso;
        }
        List<Arista> aristas = new List<Arista>();
        bool cambiandoTipo = false;

        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiTitlePanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddVertice_Click(object sender, EventArgs e)
        {

            string vertice = txtVertice.Text.Trim();

            if (string.IsNullOrWhiteSpace(vertice))
            {
                MessageBox.Show("Ingrese un vértice válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!vertice.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("El vértice solo puede contener letras y números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVertice.Clear();
                return;
            }

            if (vertices.Any(v => v.Equals(vertice, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("El vértice ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vertices.Add(vertice);
            dgvVertices.Rows.Add(vertice);
            ActualizarCombos();
            RefrescarGrados();
            txtVertice.Clear();
            txtVertice.Focus();
        }

        private void txtVertice_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter: agrega el vértice como si presionara el botón
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // evita el sonido "ding"
                btnAddVertice.PerformClick();
                return;
            }

            // Teclas de edición permitidas
            bool esEdicion = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                             e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                             e.KeyCode == Keys.Home || e.KeyCode == Keys.End ||
                             e.KeyCode == Keys.Tab;

            // Atajos como Ctrl+C, Ctrl+V, Ctrl+X, Ctrl+A
            bool esAtajo = e.Control;

            bool esLetra = e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z && !e.Control;
            bool esNumero = e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift;
            bool esNumPad = e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9;

            if (!(esEdicion || esAtajo || esLetra || esNumero || esNumPad))
            {
                e.SuppressKeyPress = true;   // bloquea la tecla
            }
        }

        private void btnDeleteVertice_Click(object sender, EventArgs e)
        {
            // verificamos que haya una fila seleccionada
            if (dgvVertices.CurrentRow == null || dgvVertices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un vértice para eliminar.");
                return;
            }

            int indice = dgvVertices.CurrentRow.Index;
            string vertice = dgvVertices.CurrentRow.Cells[0].Value?.ToString();

            // confirmar
            var resultado = MessageBox.Show(
                $"¿Eliminar el vértice \"{vertice}\"?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            // al eliminar un vertice tambien se eliminan las aristas que lo usan
            aristas.RemoveAll(a => a.Origen == vertice || a.Destino == vertice);

            // eliminar en la lista del grid
            vertices.Remove(vertice);
            dgvVertices.Rows.RemoveAt(indice);

            ActualizarCombos();   // actualizar
            RefrescarAristas();   // refrescar las aristas
            RefrescarGrados();    // refrescar los grados
        }

        //configuracion inicial
        private void ConfigurarGrafo()
        {
            foreach (var cb in new[] { cbOrigen, cbDestino, cbOrigenAlg, cbDestinoAlg, cbAlgoritmos })
                cb.ReadOnly = false;

            // Algoritmos disponibles
            cbAlgoritmos.Items.Clear();
            cbAlgoritmos.Items.Add("Amplitud (BFS)");
            cbAlgoritmos.Items.Add("Profundidad (DFS)");
            cbAlgoritmos.Items.Add("Dijkstra");

            // tipo por defecto: no dirigido y sin pesos
            CheckNoDirigido.Checked = true;
            txtPeso.Enabled = false;

            // Eventos
            CheckDirigido.ValueChanged += CheckTipo_ValueChanged;
            CheckNoDirigido.ValueChanged += CheckTipo_ValueChanged;
            CheckPonderado.ValueChanged += CheckTipo_ValueChanged;

            btnAddAristas.Click += btnAddAristas_Click;
            btnDeleteAristas.Click += btnDeleteAristas_Click;
            btnEjecutarAlg.Click += btnEjecutarAlg_Click;
            btnReiniciarAlg.Click += btnReiniciarAlg_Click;

            ConfigurarMatriz(dgvMatrizI);
            ConfigurarMatriz(dgvMatrizA);
            RefrescarMatrices();

            ConfigurarPaneles();   // crea el lienzo y el cuadro de analisis
            RefrescarDibujo();     // dibuja el grafo
        }

        //tipo de grafos
        private void CheckTipo_ValueChanged(object sender, bool value)
        {
            if (cambiandoTipo) return;
            cambiandoTipo = true;

            // Dirigido y No dirigido son excluyentes y siempre debe haber uno marcado
            if (sender == CheckDirigido && value) CheckNoDirigido.Checked = false;
            else if (sender == CheckNoDirigido && value) CheckDirigido.Checked = false;
            else if ((sender == CheckDirigido || sender == CheckNoDirigido) && !value)
                ((Sunny.UI.UICheckBox)sender).Checked = true;

            // aqui el peso solo se escribe si el grafo es ponderado
            txtPeso.Enabled = CheckPonderado.Checked;
            if (!CheckPonderado.Checked) txtPeso.Text = "";

            cambiandoTipo = false;

            RefrescarAristas();
            RefrescarGrados();
        }

        //aristas
        private void btnAddAristas_Click(object sender, EventArgs e)
        {
            string origen = cbOrigen.SelectedItem?.ToString();
            string destino = cbDestino.SelectedItem?.ToString();

            if (origen == null || destino == null)
            {
                MessageBox.Show("Seleccione el origen y el destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (origen == destino)
            {
                MessageBox.Show("El origen y el destino deben ser distintos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double peso = 1;
            if (CheckPonderado.Checked)
            {
                string txt = txtPeso.Text.Trim().Replace(',', '.');
                if (!double.TryParse(txt, System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out peso) || peso <= 0)
                {
                    MessageBox.Show("Ingrese un peso numérico mayor que 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // evitamos las aristas repetidas para no dirigido A-B es lo mismo que B-A
            bool dirigido = CheckDirigido.Checked;
            bool existe = aristas.Any(a =>
                (a.Origen == origen && a.Destino == destino) ||
                (!dirigido && a.Origen == destino && a.Destino == origen));

            if (existe)
            {
                MessageBox.Show("Esa arista ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aristas.Add(new Arista { Origen = origen, Destino = destino, Peso = peso });
            RefrescarAristas();
            RefrescarGrados();
            txtPeso.Clear();
        }

        //btn para eliminar
        private void btnDeleteAristas_Click(object sender, EventArgs e)
        {
            if (dgvAristas.CurrentRow == null || dgvAristas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una arista para eliminar.");
                return;
            }

            int indice = dgvAristas.CurrentRow.Index;
            var a = aristas[indice];

            var resultado = MessageBox.Show(
                $"¿Eliminar la arista {a.Origen} → {a.Destino}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            aristas.RemoveAt(indice);
            RefrescarAristas();
            RefrescarGrados();
        }

        //refrescar

        private void RefrescarAristas()
        {
            dgvAristas.Rows.Clear();
            foreach (var a in aristas)
            {
                string peso = CheckPonderado.Checked
                    ? a.Peso.ToString(System.Globalization.CultureInfo.InvariantCulture)
                    : "-";
                dgvAristas.Rows.Add(a.Origen, a.Destino, peso);
            }
        }

        // aqui actualizamos las columnas de grado y de las conexiones de la tabla de los vertices
        private void RefrescarGrados()
        {
            bool dirigido = CheckDirigido.Checked;

            foreach (DataGridViewRow fila in dgvVertices.Rows)
            {
                string v = fila.Cells[0].Value?.ToString();
                if (v == null) continue;

                var conexiones = new List<string>();

                foreach (var a in aristas)
                {
                    if (a.Origen == v) conexiones.Add(dirigido ? "→" + a.Destino : a.Destino);
                    else if (a.Destino == v) conexiones.Add(dirigido ? "←" + a.Origen : a.Origen);
                }

                fila.Cells[1].Value = conexiones.Count;   // grado en dirigido: entrada + salida
                fila.Cells[2].Value = string.Join(", ", conexiones);
            }

            RefrescarMatrices();
            RefrescarDibujo();   // mantiene el dibujo actualizado
        }

        // llenamos los combos con los vertices actuales y conservamos la seleccion si sigue existiendo
        private void ActualizarCombos()
        {
            foreach (var cb in new[] { cbOrigen, cbDestino, cbOrigenAlg, cbDestinoAlg })
            {
                string previo = cb.SelectedItem?.ToString();

                cb.Items.Clear();
                foreach (var v in vertices) cb.Items.Add(v);

                if (previo != null && vertices.Contains(previo)) cb.SelectedItem = previo;
                else cb.SelectedIndex = -1;
            }
        }


        //algoritmos
        private void btnEjecutarAlg_Click(object sender, EventArgs e)
        {
            string algoritmo = cbAlgoritmos.SelectedItem?.ToString();
            string origen = cbOrigenAlg.SelectedItem?.ToString();
            string destino = cbDestinoAlg.SelectedItem?.ToString();

            if (algoritmo == null)
            {
                MessageBox.Show("Seleccione un algoritmo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (origen == null)
            {
                MessageBox.Show("Seleccione el vértice de origen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resultado;

            if (algoritmo.StartsWith("Amplitud"))
            {
                resultado = Amplitud(origen, destino);
            }
            else if (algoritmo.StartsWith("Profundidad"))
            {
                resultado = Profundidad(origen, destino);
            }
            else
            {
                if (destino == null)
                {
                    MessageBox.Show("Dijkstra necesita un vértice de destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!CheckPonderado.Checked)
                    resultado = "(Grafo no ponderado: todas las aristas valen 1)\n\n" + Dijkstra(origen, destino);
                else
                    resultado = Dijkstra(origen, destino);
            }

            MessageBox.Show(resultado, algoritmo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReiniciarAlg_Click(object sender, EventArgs e)
        {
            cbAlgoritmos.SelectedIndex = -1;
            cbOrigenAlg.SelectedIndex = -1;
            cbDestinoAlg.SelectedIndex = -1;
        }

        // los vecinos de un vertice y respeta si el grafo es dirigido o no  y si es ponderado
        private List<(string nodo, double peso)> Vecinos(string v)
        {
            var res = new List<(string nodo, double peso)>();

            foreach (var a in aristas)
            {
                double peso = CheckPonderado.Checked ? a.Peso : 1;

                if (a.Origen == v) res.Add((a.Destino, peso));
                else if (!CheckDirigido.Checked && a.Destino == v) res.Add((a.Origen, peso));
            }

            // para orden estable entonces es el orden en que se agregaron los vertices
            return res.OrderBy(x => vertices.IndexOf(x.nodo)).ToList();
        }

        private string Amplitud(string origen, string destino)
        {
            var visitados = new HashSet<string> { origen };
            var cola = new Queue<string>();
            var orden = new List<string>();
            bool encontrado = false;

            cola.Enqueue(origen);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                orden.Add(actual);

                if (destino != null && actual == destino) { encontrado = true; break; }

                foreach (var (v, _) in Vecinos(actual))
                    if (visitados.Add(v)) cola.Enqueue(v);
            }

            string texto = "Orden de visita: " + string.Join(" → ", orden);
            if (destino != null)
                texto += encontrado ? $"\n\nSe llegó a {destino}." : $"\n\nNo se puede llegar a {destino} desde {origen}.";
            return texto;
        }

        private string Profundidad(string origen, string destino)
        {
            var visitados = new HashSet<string>();
            var pila = new Stack<string>();
            var orden = new List<string>();
            bool encontrado = false;

            pila.Push(origen);

            while (pila.Count > 0)
            {
                string actual = pila.Pop();
                if (!visitados.Add(actual)) continue;

                orden.Add(actual);

                if (destino != null && actual == destino) { encontrado = true; break; }

                // se apilan al alreves para visitar primero al primer vecino
                foreach (var (v, _) in Vecinos(actual).AsEnumerable().Reverse())
                    if (!visitados.Contains(v)) pila.Push(v);
            }

            string texto = "Orden de visita: " + string.Join(" → ", orden);
            if (destino != null)
                texto += encontrado ? $"\n\nSe llegó a {destino}." : $"\n\nNo se puede llegar a {destino} desde {origen}.";
            return texto;
        }

        // Dijkstra

        private string Dijkstra(string origen, string destino)
        {
            var dist = vertices.ToDictionary(v => v, v => double.PositiveInfinity);
            var previo = new Dictionary<string, string>();
            var pendientes = new List<string>(vertices);

            dist[origen] = 0;

            while (pendientes.Count > 0)
            {
                string u = pendientes.OrderBy(v => dist[v]).First();
                if (double.IsPositiveInfinity(dist[u])) break;

                pendientes.Remove(u);
                if (u == destino) break;

                foreach (var (v, peso) in Vecinos(u))
                {
                    if (!pendientes.Contains(v)) continue;

                    double alt = dist[u] + peso;
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        previo[v] = u;
                    }
                }
            }

            if (double.IsPositiveInfinity(dist[destino]))
                return $"No existe un camino de {origen} a {destino}.";

            var camino = new List<string>();
            for (string x = destino; x != null; x = previo.ContainsKey(x) ? previo[x] : null)
                camino.Insert(0, x);

            return "Camino más corto: " + string.Join(" → ", camino) +
                   "\nCosto total: " + dist[destino].ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        // ============ botones de la parte superior ============

        // se deja vacio porque el diseñador lo tenia enlazado (el boton Agregar de aristas
        // funciona con btnAddAristas_Click, enlazado en ConfigurarGrafo)
        private void btnAddAristas_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCrearGrafo_Click(object sender, EventArgs e)
        {
            if (vertices.Count == 0)
            {
                MessageBox.Show("Agregue al menos un vértice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lienzo.Distribuir();   // vuelve a acomodar los vertices en circulo
            RefrescarDibujo();
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (vertices.Count == 0)
            {
                MessageBox.Show("Agregue al menos un vértice para analizar.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var analizador = new AnalizadorGrafo(vertices, AristasComoTuplas(),
                                                 CheckDirigido.Checked, CheckPonderado.Checked);

            txtAnalisis.Clear();
            foreach (var linea in analizador.Reporte().TrimEnd('\n').Split('\n'))
            {
                bool titulo = linea.StartsWith("# ");

                txtAnalisis.SelectionStart = txtAnalisis.TextLength;
                txtAnalisis.SelectionLength = 0;
                txtAnalisis.SelectionFont = new Font("Segoe UI", 10F, titulo ? FontStyle.Bold : FontStyle.Regular);
                txtAnalisis.SelectionColor = titulo ? Color.FromArgb(79, 70, 229) : Color.FromArgb(48, 48, 48);
                txtAnalisis.SelectedText = (titulo ? linea.Substring(2) : linea) + "\n";
            }

            txtAnalisis.SelectionStart = 0;
            txtAnalisis.ScrollToCaret();
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Borrar todo el grafo?", "Confirmar",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            vertices.Clear();
            aristas.Clear();
            dgvVertices.Rows.Clear();
            dgvAristas.Rows.Clear();
            txtVertice.Clear();
            txtPeso.Clear();

            CheckNoDirigido.Checked = true;
            CheckDirigido.Checked = false;
            CheckPonderado.Checked = false;

            ActualizarCombos();
            btnReiniciarAlg_Click(null, EventArgs.Empty);
            RefrescarAristas();
            RefrescarGrados();      // refresca matrices y dibujo
            lienzo.Distribuir();

            txtAnalisis.Text = "Presione \"Analizar\" para ver las propiedades del grafo.";
        }
    }

}