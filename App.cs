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

        // ====== tabla paso a paso + animacion de algoritmos ======
        Sunny.UI.UISymbolButton btnPasoAlg;
        Label lblResultadoAlg;
        System.Windows.Forms.Timer timerAlg;

        string[] pasosColumnas;
        List<string[]> pasosFilas = new List<string[]>();
        List<string> pasosNodo = new List<string>();     // vertice visitado en cada fila
        List<string> pasosPadre = new List<string>();    // de donde se llego (null si es el origen)
        List<string> pasosCamino = new List<string>();   // camino final (solo Dijkstra)
        string pasosResultado = "";
        int pasosMostrados = 0;
        bool pasosListos = false;
        string pasosClave = "";   // algoritmo|origen|destino con el que se calcularon

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

            ConfigurarPaneles();           // crea el lienzo y el cuadro de analisis
            ConfigurarPanelAlgoritmos();   // panel de algoritmos con tabla paso a paso
            RefrescarDibujo();             // dibuja el grafo
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
            LimpiarTablaAlg();   // si cambia el grafo, la tabla y la animacion ya no son validas

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

        // ================= panel de algoritmos =================
        private void ConfigurarPanelAlgoritmos()
        {
            uiTitlePanel5.Text = "Algoritmos de la guía";

            // etiquetas y combos a todo el ancho
            label7.Location = new Point(10, 48);
            label8.Location = new Point(10, 88);
            label9.Location = new Point(10, 128);
            cbAlgoritmos.SetBounds(96, 43, 215, 29);
            cbOrigenAlg.SetBounds(96, 83, 215, 29);
            cbDestinoAlg.SetBounds(96, 123, 215, 29);

            // boton Paso (se crea por codigo)
            btnPasoAlg = new Sunny.UI.UISymbolButton
            {
                FillColor = Color.FromArgb(221, 224, 238),
                FillHoverColor = Color.FromArgb(91, 105, 145),
                FillPressColor = Color.Gray,
                FillSelectedColor = Color.FromArgb(91, 105, 145),
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(26, 45, 98),
                SymbolColor = Color.FromArgb(26, 45, 98),
                Symbol = 61521,
                SymbolSize = 22,
                Radius = 10,
                RectColor = Color.White,
                RectHoverColor = Color.White,
                RectPressColor = Color.White,
                RectSelectedColor = Color.White,
                MinimumSize = new Size(1, 1),
                Name = "btnPasoAlg",
                Text = "Paso"
            };
            btnPasoAlg.Click += btnPasoAlg_Click;
            uiTitlePanel5.Controls.Add(btnPasoAlg);

            btnEjecutarAlg.SetBounds(10, 168, 100, 35);
            btnPasoAlg.SetBounds(116, 168, 90, 35);
            btnReiniciarAlg.SetBounds(212, 168, 100, 35);

            // tabla de visitas
            dgvVisitas.SetBounds(10, 212, 301, 125);
            dgvVisitas.ScrollBars = ScrollBars.Both;

            // resultado
            lblResultadoAlg = new Label
            {
                Location = new Point(10, 344),
                Size = new Size(301, 50),
                BackColor = Color.FromArgb(236, 249, 245),
                ForeColor = Color.FromArgb(26, 45, 98),
                Font = new Font("Segoe UI", 10.5F),
                Padding = new Padding(8, 4, 4, 4),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "",
                Visible = false
            };
            uiTitlePanel5.Controls.Add(lblResultadoAlg);

            // temporizador de la animacion (Ejecutar avanza un paso por tick)
            timerAlg = new System.Windows.Forms.Timer { Interval = 700 };
            timerAlg.Tick += timerAlg_Tick;
        }

        // ---------- formato ----------
        private string FormatoDist(double d) =>
            double.IsPositiveInfinity(d) ? "∞" : d.ToString(System.Globalization.CultureInfo.InvariantCulture);

        // ---------- limpiar ----------
        private void LimpiarTablaAlg()
        {
            timerAlg?.Stop();

            pasosListos = false;
            pasosMostrados = 0;
            pasosFilas.Clear();
            pasosNodo.Clear();
            pasosPadre.Clear();
            pasosCamino.Clear();
            pasosResultado = "";
            pasosClave = "";

            if (dgvVisitas != null)
            {
                dgvVisitas.Rows.Clear();
                dgvVisitas.Columns.Clear();
            }
            if (lblResultadoAlg != null)
            {
                lblResultadoAlg.Text = "";
                lblResultadoAlg.Visible = false;
            }
            lienzo?.LimpiarResaltado();
        }

        // ---------- columnas dinamicas ----------
        private void ConstruirColumnasAlg()
        {
            dgvVisitas.Rows.Clear();
            dgvVisitas.Columns.Clear();

            for (int i = 0; i < pasosColumnas.Length; i++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = pasosColumnas[i],
                    Name = "colAlg" + i,
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    MinimumWidth = 40,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVisitas.Columns.Add(col);
            }
        }

        // ---------- validar y calcular todos los pasos ----------
        private bool PrepararAlgoritmo()
        {
            string algoritmo = cbAlgoritmos.SelectedItem?.ToString();
            string origen = cbOrigenAlg.SelectedItem?.ToString();
            string destino = cbDestinoAlg.SelectedItem?.ToString();

            if (algoritmo == null)
            {
                MessageBox.Show("Seleccione un algoritmo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (origen == null)
            {
                MessageBox.Show("Seleccione el vértice de origen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (algoritmo == "Dijkstra" && destino == null)
            {
                MessageBox.Show("Dijkstra necesita un vértice de destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LimpiarTablaAlg();

            if (algoritmo.StartsWith("Amplitud")) PasosAmplitud(origen, destino);
            else if (algoritmo.StartsWith("Profundidad")) PasosProfundidad(origen, destino);
            else PasosDijkstra(origen, destino);

            ConstruirColumnasAlg();
            pasosClave = algoritmo + "|" + origen + "|" + destino;
            pasosListos = true;
            return true;
        }

        // agrega una fila a la tabla y guarda el vertice y su padre para la animacion
        private void AgregarPaso(string[] fila, string nodo, string padre)
        {
            pasosFilas.Add(fila);
            pasosNodo.Add(nodo);
            pasosPadre.Add(padre);
        }

        private void PasosDijkstra(string origen, string destino)
        {
            pasosColumnas = new[] { "Visita" }.Concat(vertices).ToArray();

            var dist = vertices.ToDictionary(v => v, v => double.PositiveInfinity);
            var previo = new Dictionary<string, string>();
            var pendientes = new List<string>(vertices);
            dist[origen] = 0;

            while (pendientes.Count > 0)
            {
                string u = pendientes.OrderBy(v => dist[v]).First();
                if (double.IsPositiveInfinity(dist[u])) break;

                pendientes.Remove(u);
                if (u == destino) break;   // el destino ya es definitivo, no hace falta otra fila

                foreach (var (v, peso) in Vecinos(u))
                {
                    if (!pendientes.Contains(v)) continue;
                    double alt = dist[u] + peso;
                    if (alt < dist[v]) { dist[v] = alt; previo[v] = u; }
                }

                AgregarPaso(new[] { u }.Concat(vertices.Select(v => FormatoDist(dist[v]))).ToArray(),
                            u, previo.ContainsKey(u) ? previo[u] : null);
            }

            if (double.IsPositiveInfinity(dist[destino]))
            {
                pasosResultado = $"No existe un camino de {origen} a {destino}.";
                return;
            }

            var camino = new List<string>();
            for (string x = destino; x != null; x = previo.ContainsKey(x) ? previo[x] : null)
                camino.Insert(0, x);

            pasosCamino = camino;
            pasosResultado = string.Join(" → ", camino) + "     d = " + FormatoDist(dist[destino]);
        }

        private void PasosAmplitud(string origen, string destino)
        {
            pasosColumnas = new[] { "Visita", "Cola" };

            var visitados = new HashSet<string> { origen };
            var padre = new Dictionary<string, string>();
            var cola = new Queue<string>();
            var orden = new List<string>();
            bool encontrado = false;
            cola.Enqueue(origen);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                orden.Add(actual);
                string p = padre.ContainsKey(actual) ? padre[actual] : null;

                if (destino != null && actual == destino)
                {
                    encontrado = true;
                    AgregarPaso(new[] { actual, string.Join(", ", cola) }, actual, p);
                    break;
                }

                foreach (var (v, _) in Vecinos(actual))
                    if (visitados.Add(v)) { cola.Enqueue(v); padre[v] = actual; }

                AgregarPaso(new[] { actual, string.Join(", ", cola) }, actual, p);
            }

            pasosResultado = string.Join(" → ", orden);
            if (destino != null)
                pasosResultado += encontrado ? $"\nSe llegó a {destino}." : $"\nNo se puede llegar a {destino}.";
        }

        private void PasosProfundidad(string origen, string destino)
        {
            pasosColumnas = new[] { "Visita", "Pila" };

            var visitados = new HashSet<string>();
            var pila = new Stack<(string nodo, string padre)>();
            var orden = new List<string>();
            bool encontrado = false;
            pila.Push((origen, null));

            while (pila.Count > 0)
            {
                var (actual, padre) = pila.Pop();
                if (!visitados.Add(actual)) continue;
                orden.Add(actual);

                if (destino != null && actual == destino)
                {
                    encontrado = true;
                    AgregarPaso(new[] { actual, string.Join(", ", pila.Select(x => x.nodo)) }, actual, padre);
                    break;
                }

                // se apilan al reves para visitar primero al primer vecino
                foreach (var (v, _) in Vecinos(actual).AsEnumerable().Reverse())
                    if (!visitados.Contains(v)) pila.Push((v, actual));

                AgregarPaso(new[] { actual, string.Join(", ", pila.Select(x => x.nodo)) }, actual, padre);
            }

            pasosResultado = string.Join(" → ", orden);
            if (destino != null)
                pasosResultado += encontrado ? $"\nSe llegó a {destino}." : $"\nNo se puede llegar a {destino}.";
        }

        // ---------- mostrar una fila / el resultado ----------
        private void MostrarSiguienteFila()
        {
            if (pasosMostrados >= pasosFilas.Count) return;

            int idx = dgvVisitas.Rows.Add(pasosFilas[pasosMostrados]);
            pasosMostrados++;

            // resalta la celda del vertice recien visitado (solo en Dijkstra)
            if (pasosColumnas.Length == vertices.Count + 1)
            {
                int col = vertices.IndexOf(pasosFilas[pasosMostrados - 1][0]) + 1;
                if (col > 0)
                {
                    dgvVisitas.Rows[idx].Cells[col].Style.BackColor = Color.FromArgb(215, 213, 249);
                    dgvVisitas.Rows[idx].Cells[col].Style.Font =
                        new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
                }
            }

            dgvVisitas.FirstDisplayedScrollingRowIndex = idx;
            dgvVisitas.ClearSelection();

            ResaltarPaso(pasosMostrados - 1);
        }

        // pinta en el digrafo todo lo recorrido hasta la fila k
        private void ResaltarPaso(int k)
        {
            if (lienzo == null || k < 0 || k >= pasosNodo.Count) return;

            var visitados = pasosNodo.Take(k + 1).ToList();
            var recorridas = new List<(string, string)>();
            for (int i = 0; i <= k; i++)
                if (pasosPadre[i] != null) recorridas.Add((pasosPadre[i], pasosNodo[i]));

            lienzo.Resaltar(visitados, pasosNodo[k], recorridas);
        }

        // al terminar: Dijkstra deja solo el camino mas corto, BFS/DFS dejan el arbol del recorrido
        private void ResaltarFinal()
        {
            if (lienzo == null) return;

            if (pasosCamino.Count > 0)
            {
                var recorridas = new List<(string, string)>();
                for (int i = 0; i < pasosCamino.Count - 1; i++)
                    recorridas.Add((pasosCamino[i], pasosCamino[i + 1]));

                lienzo.Resaltar(pasosCamino, pasosCamino[pasosCamino.Count - 1], recorridas);
            }
            else if (pasosNodo.Count > 0)
            {
                ResaltarPaso(pasosNodo.Count - 1);
            }
        }

        private void MostrarResultadoAlg()
        {
            lblResultadoAlg.Text = pasosResultado;
            lblResultadoAlg.Visible = true;
        }

        private void TerminarAlg()
        {
            timerAlg?.Stop();
            MostrarResultadoAlg();
            ResaltarFinal();
        }

        // ================= botones de algoritmos =================
        private void btnEjecutarAlg_Click(object sender, EventArgs e)
        {
            if (!PrepararAlgoritmo()) return;

            if (pasosFilas.Count == 0) { TerminarAlg(); return; }

            // primer paso de inmediato y el resto animado
            MostrarSiguienteFila();
            if (pasosMostrados >= pasosFilas.Count) TerminarAlg();
            else timerAlg.Start();
        }

        private void timerAlg_Tick(object sender, EventArgs e)
        {
            if (pasosMostrados < pasosFilas.Count)
                MostrarSiguienteFila();

            if (pasosMostrados >= pasosFilas.Count)
                TerminarAlg();
        }

        private void btnPasoAlg_Click(object sender, EventArgs e)
        {
            timerAlg?.Stop();   // si estaba animando, pasa a modo manual

            string claveActual = cbAlgoritmos.SelectedItem + "|" + cbOrigenAlg.SelectedItem + "|" + cbDestinoAlg.SelectedItem;

            // si no hay pasos calculados o cambiaron las opciones, se empieza de nuevo
            if (!pasosListos || claveActual != pasosClave)
            {
                if (!PrepararAlgoritmo()) return;
            }

            if (pasosMostrados >= pasosFilas.Count)
            {
                MessageBox.Show("El algoritmo ya terminó. Presione Reiniciar para volver a empezar.",
                                "Paso a paso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MostrarSiguienteFila();
            if (pasosMostrados >= pasosFilas.Count) TerminarAlg();
        }

        private void btnReiniciarAlg_Click(object sender, EventArgs e)
        {
            cbAlgoritmos.SelectedIndex = -1;
            cbOrigenAlg.SelectedIndex = -1;
            cbDestinoAlg.SelectedIndex = -1;
            LimpiarTablaAlg();   // detiene la animacion y limpia colores
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
            RefrescarGrados();      // refresca matrices, dibujo y limpia la tabla de algoritmos
            lienzo.Distribuir();

            txtAnalisis.Text = "Presione \"Analizar\" para ver las propiedades del grafo.";
        }
    }
}