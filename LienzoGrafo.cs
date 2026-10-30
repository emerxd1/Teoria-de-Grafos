using System.Drawing.Drawing2D;
using System.Globalization;

namespace Main
{
    /// <summary>
    /// Control que dibuja el grafo (vértices, aristas, flechas y pesos).
    /// Los vértices se pueden arrastrar con el mouse.
    /// Permite resaltar vértices y aristas para animar los recorridos.
    /// </summary>
    public class LienzoGrafo : Panel
    {
        private const float R = 20f;   // radio de cada vértice

        private List<string> vertices = new();
        private List<(string o, string d, double p)> aristas = new();
        private bool dirigido;
        private bool ponderado;

        // posiciones relativas (0..1) para que sigan bien si cambia el tamaño
        private readonly Dictionary<string, PointF> pos = new();
        private bool manual;            // true si el usuario movió algún vértice
        private string arrastrando;

        // ---------- resaltado para la animacion de algoritmos ----------
        private HashSet<string> resVisitados = new();
        private HashSet<(string, string)> resAristas = new();
        private string resActual;

        private static readonly Color ColorVisitado = Color.FromArgb(20, 184, 166);
        private static readonly Color ColorActual = Color.FromArgb(245, 158, 11);

        public LienzoGrafo()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.FromArgb(244, 248, 252);
        }

        // ---------- API pública ----------

        public void Actualizar(List<string> verts,
                               List<(string o, string d, double p)> aris,
                               bool esDirigido, bool esPonderado)
        {
            vertices = new List<string>(verts);
            aristas = new List<(string o, string d, double p)>(aris);
            dirigido = esDirigido;
            ponderado = esPonderado;

            foreach (var k in pos.Keys.Where(k => !vertices.Contains(k)).ToList())
                pos.Remove(k);

            if (!manual)
                Distribuir();
            else
            {
                for (int i = 0; i < vertices.Count; i++)
                    if (!pos.ContainsKey(vertices[i]))
                        pos[vertices[i]] = PosCircular(i, vertices.Count);
                Invalidate();
            }
        }

        /// <summary>Acomoda los vértices en círculo.</summary>
        public void Distribuir()
        {
            manual = false;
            pos.Clear();
            for (int i = 0; i < vertices.Count; i++)
                pos[vertices[i]] = PosCircular(i, vertices.Count);
            Invalidate();
        }

        /// <summary>Marca vértices visitados, el vértice actual y las aristas recorridas.</summary>
        public void Resaltar(IEnumerable<string> visitados, string actual,
                             IEnumerable<(string, string)> aristasRecorridas)
        {
            resVisitados = new HashSet<string>(visitados);
            resAristas = new HashSet<(string, string)>(aristasRecorridas);
            resActual = actual;
            Invalidate();
        }

        /// <summary>Quita todo el resaltado.</summary>
        public void LimpiarResaltado()
        {
            if (resVisitados.Count == 0 && resAristas.Count == 0 && resActual == null) return;
            resVisitados = new HashSet<string>();
            resAristas = new HashSet<(string, string)>();
            resActual = null;
            Invalidate();
        }

        // ---------- dibujo ----------

        private static PointF PosCircular(int i, int n)
        {
            if (n == 1) return new PointF(0.5f, 0.5f);
            double ang = -Math.PI / 2 + 2 * Math.PI * i / n;
            return new PointF(0.5f + 0.38f * (float)Math.Cos(ang),
                              0.5f + 0.36f * (float)Math.Sin(ang));
        }

        private PointF Px(string v) => new PointF(pos[v].X * Width, pos[v].Y * Height);

        private static PointF Mover(PointF desde, PointF hacia, float d)
        {
            float dx = hacia.X - desde.X, dy = hacia.Y - desde.Y;
            float l = MathF.Sqrt(dx * dx + dy * dy);
            if (l < 0.001f) return desde;
            return new PointF(desde.X + dx / l * d, desde.Y + dy / l * d);
        }

        // una arista esta resaltada si fue recorrida (en no dirigido vale cualquier sentido)
        private bool EstaResaltada(string o, string d) =>
            resAristas.Contains((o, d)) || (!dirigido && resAristas.Contains((d, o)));

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var centro = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            if (vertices.Count == 0)
            {
                using var f = new Font("Segoe UI", 11f);
                g.DrawString("Agregue vértices y aristas para ver el grafo aquí",
                             f, Brushes.Gray, ClientRectangle, centro);
                return;
            }

            // aristas
            var existentes = new HashSet<(string, string)>(aristas.Select(a => (a.o, a.d)));
            using var cap = new AdjustableArrowCap(5, 6);
            using var pen = new Pen(Color.FromArgb(120, 130, 160), 2f);
            using var penRes = new Pen(ColorVisitado, 4f);
            if (dirigido)
            {
                pen.CustomEndCap = cap;
                penRes.CustomEndCap = cap;
            }
            using var fPeso = new Font("Segoe UI Semibold", 9.5f);

            foreach (var a in aristas)
            {
                if (!pos.ContainsKey(a.o) || !pos.ContainsKey(a.d)) continue;

                var p1 = Px(a.o);
                var p2 = Px(a.d);
                float dx = p2.X - p1.X, dy = p2.Y - p1.Y;
                float len = MathF.Sqrt(dx * dx + dy * dy);
                if (len < 1f) continue;
                float ux = dx / len, uy = dy / len;

                // si existe la arista contraria (A→B y B→A) se dibujan curvas
                float curv = (dirigido && existentes.Contains((a.d, a.o))) ? 28f : 0f;
                var q = new PointF((p1.X + p2.X) / 2 - uy * curv, (p1.Y + p2.Y) / 2 + ux * curv);

                var s = Mover(p1, q, R);
                var t = Mover(p2, q, R);
                var c1 = new PointF(s.X + 2f / 3f * (q.X - s.X), s.Y + 2f / 3f * (q.Y - s.Y));
                var c2 = new PointF(t.X + 2f / 3f * (q.X - t.X), t.Y + 2f / 3f * (q.Y - t.Y));
                g.DrawBezier(EstaResaltada(a.o, a.d) ? penRes : pen, s, c1, c2, t);

                if (ponderado)
                {
                    var m = new PointF(0.25f * p1.X + 0.5f * q.X + 0.25f * p2.X,
                                       0.25f * p1.Y + 0.5f * q.Y + 0.25f * p2.Y);
                    string txt = a.p.ToString(CultureInfo.InvariantCulture);
                    var tam = g.MeasureString(txt, fPeso);
                    var caja = new RectangleF(m.X - tam.Width / 2, m.Y - tam.Height / 2, tam.Width, tam.Height);
                    g.FillRectangle(Brushes.White, caja);
                    g.DrawString(txt, fPeso, Brushes.DarkSlateGray, caja, centro);
                }
            }

            // vértices
            using var relleno = new SolidBrush(Color.FromArgb(79, 70, 229));
            using var rellenoVis = new SolidBrush(ColorVisitado);
            using var rellenoAct = new SolidBrush(ColorActual);
            using var borde = new Pen(Color.White, 2f);
            using var fNodo = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);

            foreach (var v in vertices)
            {
                if (!pos.ContainsKey(v)) continue;
                var p = Px(v);
                var rect = new RectangleF(p.X - R, p.Y - R, 2 * R, 2 * R);

                Brush b = v == resActual ? rellenoAct
                        : resVisitados.Contains(v) ? rellenoVis
                        : relleno;

                g.FillEllipse(b, rect);
                g.DrawEllipse(borde, rect);
                g.DrawString(v, fNodo, Brushes.White, rect, centro);
            }
        }

        // ---------- arrastrar vértices ----------

        private string NodoEn(Point p)
        {
            for (int i = vertices.Count - 1; i >= 0; i--)
            {
                if (!pos.ContainsKey(vertices[i])) continue;
                var c = Px(vertices[i]);
                float dx = p.X - c.X, dy = p.Y - c.Y;
                if (dx * dx + dy * dy <= R * R) return vertices[i];
            }
            return null;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left) arrastrando = NodoEn(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (arrastrando != null && Width > 0 && Height > 0)
            {
                float mx = R / Width + 0.01f, my = R / Height + 0.01f;
                pos[arrastrando] = new PointF(
                    Math.Clamp(e.X / (float)Width, mx, 1 - mx),
                    Math.Clamp(e.Y / (float)Height, my, 1 - my));
                manual = true;
                Invalidate();
            }
            else
            {
                Cursor = NodoEn(e.Location) != null ? Cursors.Hand : Cursors.Default;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            arrastrando = null;
        }
    }
}