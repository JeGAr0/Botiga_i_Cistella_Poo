Botiga botigaProva = new Botiga("PROVA", 20);

// Menu principal
do
{
    Console.WriteLine("PROVA");
    Console.WriteLine("1. Venedor");
    Console.WriteLine("2. Comprador");
    Console.WriteLine("3. Sortir");

    Console.Write("Seleciona opcio: ");
    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            GestionarBotiga(botigaProva);
            break;
        case "2":
            Comprar(botigaProva);
            break;
        case "3":
            Console.WriteLine("adeu");
            return;
        default:
            Console.WriteLine("Opcio invalida");
            break;
    }

} while (Console.ReadKey().Key != ConsoleKey.Escape);

static void GestionarBotiga(Botiga botigaProva)
{
    do
    {
        Console.WriteLine("\nBotiga");
        Console.WriteLine("1. Mostrar productes de la botiga");
        Console.WriteLine("2. Afegir producte");
        Console.WriteLine("3. Modificar preu producte");
        Console.WriteLine("4. Ordenar productes per nom");
        Console.WriteLine("5. Ordenar productes per preu");
        Console.WriteLine("6. Tornar");

        Console.Write("Selecina opcio: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.WriteLine("\nProductes de la Botiga:");
                botigaProva.Mostrar();
                break;

            case "2":
                Console.Write("Introdueix el nom del producte: ");
                string nomProducte = Console.ReadLine().ToLower();
                Console.Write("Introdueis el preu del producte: ");
                double preuProducto = Convert.ToDouble(Console.ReadLine());
                while (preuProducto <= 0)
                {
                    Console.WriteLine("El preu no pot ser inferior a 0");
                    Console.Write("Torna a introduir el preu del producte: ");
                }
                Console.Write("Introdueix la quantitat d'existencies del producte: ");
                int quantitatProducte = Convert.ToInt32(Console.ReadLine());
                Producte nuevoProducto = new Producte(nomProducte, preuProducto, quantitatProducte);
                if (botigaProva.AfegirProducte(nuevoProducto))
                {
                    Console.WriteLine("Producte afegit correctament");
                }
                else
                {
                    Console.WriteLine("No s'ha pogut afegir el producte");
                }
                break;

            case "3":
                Console.Write("Introdueix el nom del producte a modificar: ");
                nomProducte = Console.ReadLine().ToLower();

                Producte producte = botigaProva[nomProducte];

                if (producte != null)
                {
                    double nouPreu;
                    Console.Write("Introdueis el nou preu del producte: ");
                    nouPreu = Convert.ToDouble(Console.ReadLine());
                    while (nouPreu <= 0)
                    {
                        Console.WriteLine("El preu no pot ser inferior a 0");
                        Console.Write("Torna a introduir el preu del producte: ");
                    }

                    if (botigaProva.ModificarPreu(nomProducte, nouPreu))
                    {
                        Console.WriteLine("El preu del producte s'ha modificat correctament");
                    }
                    else
                    {
                        Console.WriteLine("No s'ha pogut modificar el preu del producte");
                    }
                }
                else
                {
                    Console.WriteLine("El producte no es troba a la botiga");
                }
                break;

            case "4":
                botigaProva.OrdenarProducte();
                Console.WriteLine("Productes ordenats per nom");
                break;
            case "5":
                botigaProva.OrdenarPreus();
                Console.WriteLine("Productes ordenats per preu");
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Opcio invalida");
                break;
        }

    } while (Console.ReadKey().Key != ConsoleKey.Escape);
}

static void Comprar(Botiga botigaProva)
{
    Cistella cistellaProva = new Cistella();

    while (true)
    {
        Console.WriteLine("\nComprar");
        Console.WriteLine("1. Mostrar productes de la Botiga");
        Console.WriteLine("2. Afegir productes a la cistella");
        Console.WriteLine("3. Mostrar cistella");
        Console.WriteLine("4. Realitzar compra");
        Console.WriteLine("5. Tornar");

        Console.Write("Seleciona opcio: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.WriteLine("\nProductes de la Botiga:");
                botigaProva.Mostrar();
                break;

            case "2":
                Console.WriteLine("PRODUCTES A LA BOTIGA:");
                botigaProva.Mostrar();

                Console.Write("Introdueix el nom del producte: ");
                string nomProducte = Console.ReadLine().ToLower();

                Producte producteSelecionat = botigaProva[nomProducte];
                if (producteSelecionat != null)
                {
                    Console.Write($"Introdueix la quantitat de '{producteSelecionat.Nom}' que vols afegir a la cistella: ");
                    int quantitat = Convert.ToInt32(Console.ReadLine());
                    while (quantitat <= 0)
                    {
                        Console.WriteLine("La quantitat no pot ser inferior a 1");
                        Console.Write("Torna a introduir la quantitat que vols: ");
                    }

                    if (quantitat <= producteSelecionat.Quantitat)
                    {
                        cistellaProva.ComprarProducte(producteSelecionat, quantitat);
                        Console.WriteLine($"'{producteSelecionat.Nom}' S'ha afegit correctament");
                    }
                    else
                    {
                        Console.WriteLine($"Quantitat insuficicent de '{producteSelecionat.Nom}' a la botiga");
                    }
                }
                else
                {
                    Console.WriteLine($"El producte '{nomProducte}' no estacdisponible a la botiga");
                }
                break;

            case "3":
                Console.WriteLine("\nCistella de la compra:");
                cistellaProva.Mostra();
                break;

            case "4":
                Console.WriteLine("CISTELLA:");
                cistellaProva.Mostra();

                Console.WriteLine("\nVols realitzar la compra? (s/n)");
                string confirmacio = Console.ReadLine().ToLower();

                if (confirmacio == "s")
                {
                    Console.WriteLine("Compra realitzada amb exit");
                    Console.WriteLine(cistellaProva);
                }
                else if (confirmacio == "n")
                {
                    Console.WriteLine("Compra cancelada");
                }
                else
                {
                    Console.WriteLine("Opcio invalida");
                }
                break;

            case "5":
                return;
            default:

                Console.WriteLine("Opcio invalida");
                break;
        }
    }
}



public class Producte
{
    // Atributs (Producte)
    private string nom;
    private double preuInicial;
    private int iva;
    private int quantitat;

    // Constructors (Producte)
    public Producte()
    {
        nom = "noName";
        iva = 21;
        quantitat = 0;
    }

    public Producte(string Nom, double PreuInicial)
    {
        nom = Nom;
        preuInicial = PreuInicial;
    }

    public Producte(string Nom, double PreuInicial, int Quantitat)
    {
        nom = Nom;
        preuInicial = PreuInicial;
        quantitat = Quantitat;
    }

    public Producte(string Nom, double PreuInicial, int Iva, int Quantitat)
    {
        nom = Nom;
        preuInicial = PreuInicial;
        iva = Iva;
        quantitat = Quantitat;
    }

    // Propietats (Producte)
    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }
    public double PreuInicial
    {
        get { return preuInicial; }
        set
        {
            if (value > 0)
            {
                preuInicial = value;
            }
        }
    }
    public int Iva
    {
        get { return iva; }
    }
    public int Quantitat
    {
        get { return quantitat; }
        set
        {
            if (value > 0)
            {
                quantitat = value;
            }
        }
    }

    // Metodes Publics (Producte)
    public double PreuFinal()
    {
        return PreuInicial + (PreuInicial * (Iva / 100));
    }

    public override string ToString()
    {
        return $"[NOM: {nom}] - " +
                $"[PREU_SENSE_IVA: {preuInicial}] - " +
                $"[IVA: {iva}] - " +
                $"[QUANTITAT: {quantitat}] - " +
                $"[PREU_AMB_IVA: {PreuFinal()}]";
    }
}


public class Botiga
{
    // Atributs (Botiga)
    private string nomBotiga;
    private Producte[] productes;
    private int nElements;

    // Constructors (Botiga)
    public Botiga()
    {
        productes = new Producte[10];
        nElements = 0;
    }

    public Botiga(string nom, int nombreProductes)
    {
        nomBotiga = nom;
        productes = new Producte[nombreProductes];
        nElements = 0;
    }

    public Botiga(string nom, Producte[] arrayProductes)
    {
        nomBotiga = nom;
        productes = arrayProductes;
        nElements = arrayProductes.Length;
    }

    // Propietats (Botiga)
    public string NomBotiga
    {
        get { return nomBotiga; }
        set { nomBotiga = value; }
    }

    public Producte[] Productes
    {
        get { return productes; }
        set { productes = value; }
    }

    public int NElements
    {
        get { return nElements; }
        set { nElements = value; }
    }

    // Metodes (Botiga)
    public int EsapiLliure()
    {
        for (int i = 0; i < productes.Length; i++)
        {
            if (productes[i] == null)
                return i;
        }
        return -1;
    }

    public Producte this[string nomProducte]
    {
        get
        {
            foreach (Producte producte in productes)
            {
                if (producte != null && producte.Nom == nomProducte)
                {
                    return producte;
                }
            }
            return null;
        }
    }

    public bool AfegirProducte(Producte producte)
    {
        if (EsapiLliure() != -1)
        {
            productes[EsapiLliure()] = producte;
            nElements++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AfegirProducte(Producte[] producte)
    {
        if (nElements + producte.Length <= productes.Length)
        {
            Array.Copy(producte, 0, productes, nElements, producte.Length);
            nElements += producte.Length;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AmpliarBotiga(int num)
    {
        Producte[] nouProductes = new Producte[productes.Length + num];
        Array.Copy(productes, nouProductes, productes.Length);
        productes = nouProductes;
    }

    public bool ModificarPreu(string nomProducte, double preu)
    {
        foreach (Producte producte in productes)
        {
            if (producte != null && producte.Nom == nomProducte)
            {
                producte.PreuInicial = preu;
                return true;
            }
        }
        return false;
    }

    public bool BuscarProducte(Producte producte)
    {
        foreach (Producte p in productes)
        {
            if (p != null && p.Nom == producte.Nom)
            {
                return true;
            }
        }
        return false;
    }

    public bool ModificarProducte(Producte producte, string nouNom, double nouPreu, int novaQuantitat)
    {
        for (int i = 0; i < productes.Length; i++)
        {
            if (productes[i] != null && productes[i].Nom == producte.Nom)
            {
                productes[i].Nom = nouNom;
                productes[i].PreuInicial = nouPreu;
                productes[i].Quantitat = novaQuantitat;
                return true;
            }
        }
        return false;
    }

    public void OrdenarProducte()
    {
        Array.Sort(productes, (x, y) => {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return x.Nom.CompareTo(y.Nom);
        });
    }

    public void OrdenarPreus()
    {
        Array.Sort(productes, (x, y) => {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return x.PreuInicial.CompareTo(y.PreuInicial);
        });
    }

    public void EsborrarProducte(Producte producte)
    {
        for (int i = 0; i < productes.Length; i++)
        {
            if (productes[i] != null && productes[i].Nom == producte.Nom)
            {
                Array.Copy(productes, i + 1, productes, i, productes.Length - i - 1);
                productes[productes.Length - 1] = null;
                nElements--;
            }
        }
    }

    public void Mostrar()
    {
        foreach (Producte producte in productes)
        {
            if (producte != null)
            {
                Console.WriteLine($"Nom: {producte.Nom}, Preu sense IVA: {producte.PreuInicial}, IVA: {producte.Iva}, Preu Final: {producte.PreuFinal()}, Quantitat: {producte.Quantitat}");
            }
        }
    }

    public override string ToString()
    {
        return $"[NOM_BOTIGA: {nomBotiga}] - " +
                $"[PRODUCTES: {productes}] - " +
                $"[NUMERO_ELEMENTS: {nElements}] - ";
    }
}


public class Cistella
{
    // Atributs
    private Botiga botiga;
    private DateTime data;
    private Producte[] productes;
    private int[] quantitat;
    private int nElements;
    private double diners;

    // Propietas
    public Producte[] Productes
    {
        get { return productes; }
        set { productes = value; }
    }

    public int NElements
    {
        get { return nElements; }
    }

    public double Diners
    {
        get { return diners; }
        set { diners = value; }
    }

    public DateTime Data
    {
        get { return data; }
    }

    // Constructor
    public Cistella()
    {
        productes = new Producte[10];
        quantitat = new int[10];
        nElements = 0;
        diners = 0;
        botiga = null;
        data = DateTime.Now;
    }

    public Cistella(Botiga botiga, Producte[] productes, int[] quantitat, double diners)
    {
        this.botiga = botiga;
        this.productes = productes;
        this.quantitat = quantitat;
        nElements = productes.Length;
        this.diners = diners;


        if (!ComprovarDiners())
        {
            Console.WriteLine("No tens suficients calers per realitzar la compra");
            return;
        }

        if (!ComprovarDisponibilitatCistella())
        {
            Console.WriteLine("Espai de la cistella insuficient. Vols ampliar-la?");
            return;
        }

        data = DateTime.Now;
    }

    // Metodes
    public void ComprarProducte(Producte producte, int quantitat)
    {
        if (nElements >= productes.Length)
        {
            Console.WriteLine("Cistella plena. Vols ampliar-la?");
            return;
        }

        if (diners < producte.PreuFinal() * quantitat)
        {
            Console.WriteLine("No tens suficients calers per realitzar la compra");
            return;
        }

        if (botiga == null || !botiga.BuscarProducte(producte))
        {
            Console.WriteLine("El producte no es disponible a la botiga");
            return;
        }

        if (botiga[this.productes[NElements].Nom].Quantitat < quantitat)
        {
            Console.WriteLine("No hi ha suficient quantita del producto a la Botiga");
            return;
        }

        productes[nElements] = producte;
        this.quantitat[nElements] = quantitat;
        nElements++;

        diners -= producte.PreuFinal() * quantitat;
        data = DateTime.Now;
    }

    public void ComprarProducte(Producte[] productes, int[] quantitats)
    {
        for (int i = 0; i < productes.Length; i++)
        {
            ComprarProducte(productes[i], quantitats[i]);
        }
    }

    public void OrdernarCistella()
    {
        for (int i = 0; i < nElements - 1; i++)
        {
            for (int j = 0; j < nElements - i - 1; j++)
            {
                if (productes[j] != null && productes[j + 1] != null &&
                    productes[j].Nom.CompareTo(productes[j + 1].Nom) > 0)
                {
                    Producte tempProducte = productes[j];
                    productes[j] = productes[j + 1];
                    productes[j + 1] = tempProducte;

                    int tempQuantitat = quantitat[j];
                    quantitat[j] = quantitat[j + 1];
                    quantitat[j + 1] = tempQuantitat;
                }
            }
        }
    }

    public void Mostra()
    {
        Console.WriteLine($"Data de la compra: {data}");
        Console.WriteLine($"Botiga: {botiga.NomBotiga}");

        Console.WriteLine("Productes:");
        for (int i = 0; i < nElements; i++)
        {
            Console.WriteLine($"- {productes[i].Nom}, Quantitat: {quantitat[i]}, Preu Unitari: {productes[i].PreuFinal()}, Preu Total: {productes[i].PreuFinal() * quantitat[i]}");
        }

        Console.WriteLine($"Total amb IVA: {CostTotal()}");
    }

    public double CostTotal()
    {
        double total = 0;
        foreach (Producte producte in productes)
        {
            if (producte != null)
            {
                total += producte.PreuFinal();
            }
        }
        return total;
    }

    public override string ToString()
    {
        string ticket = $"DAta de la compra: {data}\nBotiga: {botiga.NomBotiga}\n\nProductes:\n";
        for (int i = 0; i < nElements; i++)
        {
            ticket += $"- {productes[i].Nom}, Quantitat: {quantitat[i]}, Preu Total: {productes[i].PreuFinal() * quantitat[i]}\n";
        }
        ticket += $"\nTotal amb IVA: {CostTotal()}";
        return ticket;
    }

    private bool ComprovarDiners()
    {
        double totalCost = 0;
        foreach (Producte producte in productes)
        {
            if (producte != null)
            {
                totalCost += producte.PreuFinal();
            }
        }
        return diners >= totalCost;
    }

    private bool ComprovarDisponibilitatCistella()
    {
        return nElements + productes.Length <= 10;
    }
}