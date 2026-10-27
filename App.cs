namespace Main
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }
        List<string> vertices = new List<string>();

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
            // 1. Verificar que haya una fila seleccionada
            if (dgvVertices.CurrentRow == null || dgvVertices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un vértice para eliminar.");
                return;
            }

            int indice = dgvVertices.CurrentRow.Index;
            string vertice = dgvVertices.CurrentRow.Cells[0].Value?.ToString();

            // 2. Confirmar
            var resultado = MessageBox.Show(
                $"¿Eliminar el vértice \"{vertice}\"?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            // 3. Eliminar de la lista y del grid
            vertices.Remove(vertice);
            dgvVertices.Rows.RemoveAt(indice);
        }
    }

}
