namespace Battleship
{
    // Enumit laivan suunnalle, laivan tilalle sekä laivan tyypille
    public enum LaivanSuunta
    {
        vaaka,
        pysty
    }

    public enum LaivanTila
    {
        pinnalla,
        uponnut
    }

    public enum LaivanTyyppi
    {
        sukellusvene,
        hävittäjä,
        risteilijä,
        taistelulaiva,
        lentotukialus
    }

    // Laiva luokka
    internal class Laiva
    {
        // Luokan ominaisuudet
        public int Pituus { get; private set; }
        public LaivanTila Tila { get; set; }
        public LaivanTyyppi Tyyppi { get; private set; }
        public LaivanSuunta Suunta { get; private set; }

        // Asetetaan ominaisuuksille arvot konstruktorissa
        public Laiva(LaivanTyyppi tyyppi)
        {
            this.Tyyppi = tyyppi;
            this.Pituus = (int)tyyppi + 1;
            this.Tila = (LaivanTila)new Random().Next(0, 2);
            this.Suunta = (LaivanSuunta)new Random().Next(0, 2);
        }
    }


    // Pelaaja luokka
    internal class Pelaaja
    {
        // Luokan ominaisuudet
        public string Nimi { get; set; }
        public List<Laiva> Laivat { get;  private set; }

        // Asetetaan ominaisuuksille arvot konstruktorissa
        public Pelaaja(string nimi)
        {
            this.Nimi = nimi;
            this.Laivat = new List<Laiva>();
            AlustaLaivat();
        }

        // Metodi joka lisää pelaajan laivat listaan
        private void AlustaLaivat()
        {
            var r = new Random();

            for (int i = 0; i < 5; i++)
            {
                Laivat.Add(new Laiva((LaivanTyyppi)i));

                if (i == 2)
                {
                    Laivat.Add(new Laiva((LaivanTyyppi)i));
                }
            }
        }
    }

    // Pelilauta luokka
    internal class Pelilauta
    {
        // Luokan ominaisuudet
        public DateTime Aloitus { get; set; }
        public DateTime Lopetus { get; set; }
        public Pelaaja Pelaaja1 { get; set; }
        public Pelaaja Pelaaja2 { get; set; }

        // Asetetaan ominaisuuksille arvot konstruktorissa
        public Pelilauta(Pelaaja pelaaja1, Pelaaja pelaaja2)
        {
            this.Aloitus = DateTime.Now;
            this.Pelaaja1 = pelaaja1;
            this.Pelaaja2 = pelaaja2;
        }

        // Metodi joka tulostaa konsoliin kummankin pelaajan tiedot ja kutsuu lopuksi Pelaa metodia
        public void AlustaPeli()
        {
            var erotin = $"\n{new String('-', 80)}";

            Console.WriteLine($"Peli aloitettu klo {this.Aloitus.ToString("HH.mm.ss")}");

            Console.WriteLine(erotin);

            Console.WriteLine($"\nPelaaja 1: {this.Pelaaja1.Nimi}");

            Console.WriteLine("\nPelaajan 1 laivat:\n");

            foreach (Laiva laiva in this.Pelaaja1.Laivat)
            {
                Console.WriteLine($"Tyyppi: {laiva.Tyyppi}\tPituus: {laiva.Pituus} ruutua\tSuunta: {laiva.Suunta}\tTila: {laiva.Tila}");
            }

            Console.WriteLine(erotin);

            Thread.Sleep(500);

            Console.WriteLine($"\nPelaaja 2: {this.Pelaaja2.Nimi}");

            Console.WriteLine("\nPelaajan 2 laivat:\n");

            foreach (Laiva laiva in this.Pelaaja2.Laivat)
            {
                Console.WriteLine($"Tyyppi: {laiva.Tyyppi}\tPituus: {laiva.Pituus} ruutua\tSuunta: {laiva.Suunta}\tTila: {laiva.Tila}");
            }

            Console.WriteLine(erotin);

            Thread.Sleep(500);

            Pelaa();
        }

        // Metodi joka laskee montako alusta on kummallakin pelaajalla pinnalla ja määrittelee voittajan sen perusteella
        private void Pelaa()
        {
            string voittaja;
            int laivatP1 = 0;
            int laivatP2 = 0;

            foreach (Laiva laiva in this.Pelaaja1.Laivat)
            {
                if (laiva.Tila == LaivanTila.pinnalla)
                {
                    laivatP1++;
                }
            }

            foreach (Laiva laiva in this.Pelaaja2.Laivat)
            {
                if (laiva.Tila == LaivanTila.pinnalla)
                {
                    laivatP2++;
                }
            }

            // Sijoitetaan voittaja muuttujaan arvo pelaajien laivalaskurimuuttujien arvojen perusteella
            voittaja = laivatP1 == laivatP2 ? "taistelu päättyi tasapeliin" : laivatP1 > laivatP2 ? $"voittaja on {this.Pelaaja1.Nimi}" : $"voittaja on {this.Pelaaja2.Nimi}";

            // Tulostetaan voittaja ja lopetusaika
            Console.WriteLine($"\nTiukan taistelun jälkeen {voittaja}");

            this.Lopetus = DateTime.Now;

            Console.WriteLine($"\nPeli päättyi klo {this.Lopetus.ToString("HH.mm.ss")}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Luodaan luokista ilmentymät ja kutsutaan AlustaPeli metodia, joka käynnistää pelin
            Console.WriteLine("Laivanupotus\n");

            Console.Write("Anna ensimmäisen pelaaja nimi: ");
            var pelaaja1 = new Pelaaja(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Anna toisen pelaajan nimi: ");
            var pelaaja2 = new Pelaaja(Console.ReadLine());

            Console.Clear();

            var pelilauta = new Pelilauta(pelaaja1, pelaaja2);

            pelilauta.AlustaPeli();

            Console.Write("\nPaina enter sulkeaksesi ikkunan");
            Console.ReadLine();
        }
    }
}