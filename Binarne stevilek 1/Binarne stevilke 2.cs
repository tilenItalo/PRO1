using System;

class Resitev
{
    // Metoda za iskanje minimalne kapacitete, ki omogoča prenos vseh paketov v danem številu dni
    public int MinKapacitetaVDneh(int[] teze, int dnevi)
    {
        int minKapaciteta = 0, maxKapaciteta = 0;

        // Določimo začetne meje: najmanjša kapaciteta je največja posamezna teža, največja pa vsota vseh tež
        for (int i = 0; i < teze.Length; i++)
        {
            minKapaciteta = Math.Max(minKapaciteta, teze[i]);
            maxKapaciteta += teze[i];
        }

        // Binarno iskanje optimalne kapacitete
        while (minKapaciteta < maxKapaciteta)
        {
            int sredina = (minKapaciteta + maxKapaciteta) / 2;
            if (LahkoPrenese(teze, dnevi, sredina)) maxKapaciteta = sredina;
            else minKapaciteta = sredina + 1;
        }
        return minKapaciteta;
    }

    // Preveri, ali je mogoče vse pakete prenesti v danem številu dni z dano kapaciteto
    private bool LahkoPrenese(int[] teze, int dnevi, int kapaciteta)
    {
        int stDni = 1, trenutnaTeza = 0;

        for (int i = 0; i < teze.Length; i++)
        {
            // Če bi dodajanje trenutne teže preseglo kapaciteto, začnemo nov dan
            if (trenutnaTeza + teze[i] > kapaciteta)
            {
                stDni++;
                trenutnaTeza = 0;
            }
            trenutnaTeza += teze[i];
        }
        return stDni <= dnevi;
    }

    static void Main()
    {
        Console.WriteLine("Vnesite število paketov:");
        int n = int.Parse(Console.ReadLine());
        int[] teze = new int[n];

        Console.WriteLine("Vnesite teže paketov (ločene s presledkom):");
        string[] vnosi = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            teze[i] = int.Parse(vnosi[i]);
        }

        Console.WriteLine("Vnesite število dni:");
        int dnevi = int.Parse(Console.ReadLine());

        // Izpis rezultata minimalne kapacitete
        Console.WriteLine("Minimalna kapaciteta: " + new Resitev().MinKapacitetaVDneh(teze, dnevi));
    }
}