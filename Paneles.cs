namespace Main
{
    // panel del digrafo (dibujo) y panel de analisis
    // los eventos de Crear grafo / Restablecer / Analizar estan en App.cs
    public partial class App : Form
    {
        private LienzoGrafo lienzo;
        private RichTextBox txtAnalisis;

        private void ConfigurarPaneles()
        {
            // lienzo donde se dibuja el grafo
            lienzo = new LienzoGrafo { Dock = DockStyle.Fill };
            Digrafo.Controls.Add(lienzo);

            // cuadro de texto con el resultado del analisis
            txtAnalisis = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(244, 248, 252),
                Font = new Font("Segoe UI", 10F),
                Text = "Presione \"Analizar\" para ver las propiedades del grafo."
            };
            uiTitlePanel4.Controls.Add(txtAnalisis);
        }

        // convierte las aristas al formato que usan el lienzo y el analizador
        private List<(string o, string d, double p)> AristasComoTuplas()
        {
            bool pond = CheckPonderado.Checked;
            return aristas.Select(a => (o: a.Origen, d: a.Destino, p: pond ? a.Peso : 1.0)).ToList();
        }

        // se llama desde RefrescarGrados para que el dibujo siempre este al dia
        private void RefrescarDibujo()
        {
            if (lienzo == null) return;
            lienzo.Actualizar(vertices, AristasComoTuplas(), CheckDirigido.Checked, CheckPonderado.Checked);
        }
    }
}