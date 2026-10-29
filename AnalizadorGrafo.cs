using System.Globalization;
using System.Text;

namespace Main
{
    /// <summary>
    /// Calcula las propiedades de un grafo: grados, conexidad, Euler, Hamilton,
    /// bipartito, árbol, Kruskal, etc. No depende de ningún control de la interfaz.
    /// </summary>
    public class AnalizadorGrafo
    {
        private readonly List<string> V;
        private readonly List<(string o, string d, double p)> E;
        private readonly bool dirigido;
        private readonly bool ponderado;
        private readonly int n;
        private readonly Dictionary<string, int> idx = new();

        private readonly List<int>[] sal;   // vecinos de salida (en no dirigido: todos los vecinos)
        private readonly List<int>[] dbl;   // vecinos ignorando la dirección
        private readonly int[] gOut;
        private readonly int[] gIn;

        public AnalizadorGrafo(IEnumerable<string> vertices,
                               IEnumerable<(string o, string d, double p)> aristas,
                               bool dirigido, bool ponderado)
        {
            V = vertices.ToList();
            E = aristas.ToList();
            n = V.Count;
            this.dirigido = dirigido;
            this.ponderado = ponderado;

            for (int i = 0; i < n; i++) idx[V[i]] = i;

            sal = new List<int>[n];
            dbl = new List<int>[n];
            gOut = new int[n];
            gIn = new int[n];
            for (int i = 0; i < n; i++) { sal[i] = new List<int>(); dbl[i] = new List<int>(); }

            foreach (var e in E)
            {
                int a = idx[e.o], b = idx[e.d];
                gOut[a]++; gIn[b]++;
                sal[a].Add(b);
                dbl[a].Add(b); dbl[b].Add(a);
                if (!dirigido) sal[b].Add(a);
            }
        }

        private int Grado(int i) => gOut[i] + gIn[i];

        private static string Num(double x) => x.ToString(CultureInfo.InvariantCulture);

        private string Camino(IEnumerable<string> nodos) => string.Join(dirigido ? " → " : " – ", nodos);

        // ======================= REPORTE =======================

        // Las líneas que empiezan con "# " son títulos de sección.
        public string Reporte()
        {
            if (n == 0) return "No hay vértices.";

            var sb = new StringBuilder();
            void L(string s = "") => sb.Append(s).Append('\n');

            L("# Resumen");
            L($"Tipo: {(dirigido ? "dirigido" : "no dirigido")}, {(ponderado ? "ponderado" : "no ponderado")}");
            L($"|V| = {n}    |E| = {E.Count}");
            L();

            // ---- grados ----
            L("# Grados");
            if (dirigido)
            {
                for (int i = 0; i < n; i++)
                    L($"{V[i]}:  entrada = {gIn[i]},  salida = {gOut[i]}");
                L($"Σ entrada = {gIn.Sum()} = Σ salida = {gOut.Sum()} = |E| = {E.Count}");
            }
            else
            {
                for (int i = 0; i < n; i++)
                    L($"deg({V[i]}) = {Grado(i)}");
                L($"Σ deg = {Enumerable.Range(0, n).Sum(Grado)} = 2·|E| = {2 * E.Count}");
            }
            L();

            // ---- conectividad ----
            L("# Conectividad");
            var comp = ComponentesDebiles(out int totalComp);
            if (dirigido)
            {
                bool fuerte = n > 0 && Alcanzables(0, sal) == n && Alcanzables(0, Inversa()) == n;
                L("Fuertemente conexo: " + (fuerte ? "sí" : "no"));
                L("Débilmente conexo: " + (totalComp == 1 ? "sí" : "no"));
            }
            else
            {
                L("Conexo: " + (totalComp == 1 ? "sí" : "no"));
            }
            L("Componentes conexas: " + totalComp);
            L();

            // ---- propiedades ----
            L("# Propiedades");
            long completo = dirigido ? (long)n * (n - 1) : (long)n * (n - 1) / 2;
            L("Completo: " + (E.Count == completo ? "sí" : "no"));

            if (!dirigido)
            {
                bool regular = Enumerable.Range(0, n).All(i => Grado(i) == Grado(0));
                L("Regular: " + (regular ? $"sí (grado {Grado(0)})" : "no"));
                L("Bipartito: " + (EsBipartito() ? "sí" : "no"));
                bool aciclico = E.Count == n - totalComp;
                L("Acíclico (bosque): " + (aciclico ? "sí" : "no"));
                L("Árbol: " + (totalComp == 1 && E.Count == n - 1 ? "sí" : "no"));
            }
            else
            {
                L("Acíclico (DAG): " + (EsDag() ? "sí" : "no"));
            }
            L();

            // ---- Euler ----
            L("# Euler (recorrido de aristas)");
            L(Euler(comp));
            L();

            // ---- Hamilton ----
            L("# Hamilton (recorrido de vértices)");
            L(Hamilton());
            L();

            // ---- Kruskal ----
            L("# Árbol generador mínimo (Kruskal)");
            L(dirigido ? "Solo aplica a grafos no dirigidos." : Kruskal());

            return sb.ToString();
        }

        // ======================= CONEXIDAD =======================

        private List<int>[] Inversa()
        {
            var inv = new List<int>[n];
            for (int i = 0; i < n; i++) inv[i] = new List<int>();
            for (int u = 0; u < n; u++)
                foreach (var v in sal[u]) inv[v].Add(u);
            return inv;
        }

        private int Alcanzables(int inicio, List<int>[] g)
        {
            var vis = new bool[n];
            var pila = new Stack<int>();
            vis[inicio] = true; pila.Push(inicio);
            int cuenta = 1;
            while (pila.Count > 0)
            {
                int u = pila.Pop();
                foreach (var v in g[u])
                    if (!vis[v]) { vis[v] = true; cuenta++; pila.Push(v); }
            }
            return cuenta;
        }

        private int[] ComponentesDebiles(out int total)
        {
            var comp = Enumerable.Repeat(-1, n).ToArray();
            total = 0;
            for (int s = 0; s < n; s++)
            {
                if (comp[s] != -1) continue;
                var pila = new Stack<int>();
                comp[s] = total; pila.Push(s);
                while (pila.Count > 0)
                {
                    int u = pila.Pop();
                    foreach (var v in dbl[u])
                        if (comp[v] == -1) { comp[v] = total; pila.Push(v); }
                }
                total++;
            }
            return comp;
        }

        private bool EsBipartito()
        {
            var color = Enumerable.Repeat(-1, n).ToArray();
            for (int s = 0; s < n; s++)
            {
                if (color[s] != -1) continue;
                color[s] = 0;
                var cola = new Queue<int>();
                cola.Enqueue(s);
                while (cola.Count > 0)
                {
                    int u = cola.Dequeue();
                    foreach (var v in dbl[u])
                    {
                        if (color[v] == -1) { color[v] = 1 - color[u]; cola.Enqueue(v); }
                        else if (color[v] == color[u]) return false;
                    }
                }
            }
            return true;
        }

        private bool EsDag()
        {
            var entrada = (int[])gIn.Clone();
            var cola = new Queue<int>(Enumerable.Range(0, n).Where(i => entrada[i] == 0));
            int vistos = 0;
            while (cola.Count > 0)
            {
                int u = cola.Dequeue();
                vistos++;
                foreach (var v in sal[u])
                    if (--entrada[v] == 0) cola.Enqueue(v);
            }
            return vistos == n;
        }

        // ======================= EULER =======================

        private string Euler(int[] comp)
        {
            if (E.Count == 0) return "El grafo no tiene aristas.";

            var conAristas = Enumerable.Range(0, n).Where(i => Grado(i) > 0).ToList();
            if (!conAristas.All(i => comp[i] == comp[conAristas[0]]))
                return "No tiene circuito ni camino euleriano (las aristas están en componentes distintas).";

            if (!dirigido)
            {
                var impares = conAristas.Where(i => Grado(i) % 2 == 1).ToList();
                if (impares.Count == 0)
                    return "Tiene circuito euleriano:\n" + Camino(Hierholzer(conAristas[0]));
                if (impares.Count == 2)
                    return "No tiene circuito euleriano, pero sí camino euleriano:\n" + Camino(Hierholzer(impares[0]));
                return $"No tiene circuito ni camino euleriano ({impares.Count} vértices de grado impar).";
            }

            int ini = -1, fin = -1;
            bool ok = true;
            foreach (var i in conAristas)
            {
                int dif = gOut[i] - gIn[i];
                if (dif == 0) continue;
                if (dif == 1 && ini == -1) ini = i;
                else if (dif == -1 && fin == -1) fin = i;
                else ok = false;
            }

            if (ok && ini == -1 && fin == -1)
                return "Tiene circuito euleriano:\n" + Camino(Hierholzer(conAristas[0]));
            if (ok && ini != -1 && fin != -1)
                return "No tiene circuito euleriano, pero sí camino euleriano:\n" + Camino(Hierholzer(ini));
            return "No tiene circuito ni camino euleriano (grados de entrada y salida no compatibles).";
        }

        // Algoritmo de Hierholzer
        private List<string> Hierholzer(int inicio)
        {
            var inc = new List<(int arista, int hacia)>[n];
            for (int i = 0; i < n; i++) inc[i] = new List<(int, int)>();
            for (int k = 0; k < E.Count; k++)
            {
                int a = idx[E[k].o], b = idx[E[k].d];
                inc[a].Add((k, b));
                if (!dirigido) inc[b].Add((k, a));
            }

            var usada = new bool[E.Count];
            var ptr = new int[n];
            var pila = new Stack<int>();
            var res = new List<int>();
            pila.Push(inicio);

            while (pila.Count > 0)
            {
                int u = pila.Peek();
                while (ptr[u] < inc[u].Count && usada[inc[u][ptr[u]].arista]) ptr[u]++;

                if (ptr[u] == inc[u].Count)
                {
                    res.Add(u);
                    pila.Pop();
                }
                else
                {
                    var (k, hacia) = inc[u][ptr[u]];
                    usada[k] = true;
                    pila.Push(hacia);
                }
            }

            res.Reverse();
            return res.Select(i => V[i]).ToList();
        }

        // ======================= HAMILTON =======================

        private string Hamilton()
        {
            if (n > 14) return "Grafo demasiado grande para la búsqueda exhaustiva (máximo 14 vértices).";
            if (n == 1) return "Trivial: un solo vértice.";

            List<int> camino = null;
            for (int s = 0; s < n && camino == null; s++)
                camino = BuscarHamilton(s, false);

            List<int> ciclo = null;
            bool cicloPosible = dirigido ? n >= 2 : n >= 3;
            if (cicloPosible) ciclo = BuscarHamilton(0, true);

            string r = camino != null
                ? "Camino hamiltoniano:\n" + Camino(camino.Select(i => V[i]))
                : "No tiene camino hamiltoniano.";

            r += "\n";

            r += ciclo != null
                ? "Ciclo hamiltoniano:\n" + Camino(ciclo.Select(i => V[i]).Append(V[ciclo[0]]))
                : "No tiene ciclo hamiltoniano.";

            return r;
        }

        private List<int> BuscarHamilton(int inicio, bool ciclo)
        {
            var vis = new bool[n];
            var ruta = new List<int> { inicio };
            vis[inicio] = true;
            return Ham(inicio, ruta, vis, ciclo) ? ruta : null;
        }

        private bool Ham(int u, List<int> ruta, bool[] vis, bool ciclo)
        {
            if (ruta.Count == n) return !ciclo || sal[u].Contains(ruta[0]);

            foreach (var v in sal[u])
            {
                if (vis[v]) continue;
                vis[v] = true; ruta.Add(v);
                if (Ham(v, ruta, vis, ciclo)) return true;
                ruta.RemoveAt(ruta.Count - 1); vis[v] = false;
            }
            return false;
        }

        // ======================= KRUSKAL =======================

        private string Kruskal()
        {
            if (E.Count == 0) return "El grafo no tiene aristas.";

            var padre = Enumerable.Range(0, n).ToArray();
            int Buscar(int x)
            {
                while (padre[x] != x) { padre[x] = padre[padre[x]]; x = padre[x]; }
                return x;
            }

            var ordenadas = E.OrderBy(a => ponderado ? a.p : 1).ToList();
            var sb = new StringBuilder();
            double total = 0;
            int elegidas = 0;

            foreach (var a in ordenadas)
            {
                int ra = Buscar(idx[a.o]), rb = Buscar(idx[a.d]);
                if (ra == rb) continue;

                padre[ra] = rb;
                elegidas++;
                double peso = ponderado ? a.p : 1;
                total += peso;
                sb.Append($"{a.o} – {a.d}  ({Num(peso)})\n");
            }

            sb.Append($"Peso total: {Num(total)}");
            if (elegidas < n - 1)
                sb.Append("\n(El grafo no es conexo: se obtiene un bosque generador mínimo.)");
            return sb.ToString();
        }
    }
}