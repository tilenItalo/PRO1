using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        // Uporabnik vnese številke
        Console.WriteLine("Vnesite seznam števil, ločenih s presledkom:");
        int[] številke = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        // Uporabnik vnese ciljno številko
        Console.Write("Vnesite ciljno številko: ");
        int cilj = int.Parse(Console.ReadLine());

        // Poiščemo prvi in zadnji pojav cilja
        int prviIndeks = PoiščiPrvi(številke, cilj);
        int zadnjiIndeks = PoiščiZadnji(številke, cilj);

        // Izpišemo rezultat
        Console.WriteLine($"Ciljna številka {cilj} se pojavi v razponu: [{prviIndeks}, {zadnjiIndeks}]");
    }

    // Metoda za iskanje prvega pojavljanja cilja v seznamu
    public static int PoiščiPrvi(int[] seznam, int cilj)
    {
        int levi = 0, desni = seznam.Length - 1;
        int najdeniIndeks = -1;

        while (levi <= desni)
        {
            int sredina = (levi + desni) / 2;

            if (seznam[sredina] == cilj)
            {
                najdeniIndeks = sredina;
                desni = sredina - 1;
            }
            else if (seznam[sredina] < cilj)
            {
                levi = sredina + 1;
            }
            else
            {
                desni = sredina - 1;
            }
        }

        return najdeniIndeks;
    }

    // Metoda za iskanje zadnjega pojavljanja cilja v seznamu
    public static int PoiščiZadnji(int[] seznam, int cilj)
    {
        int levi = 0, desni = seznam.Length - 1;
        int najdeniIndeks = -1;

        while (levi <= desni)
        {
            int sredina = (levi + desni) / 2;

            if (seznam[sredina] == cilj)
            {
                najdeniIndeks = sredina;
                levi = sredina + 1;
            }
            else if (seznam[sredina] < cilj)
            {
                levi = sredina + 1;
            }
            else
            {
                desni = sredina - 1;
            }
        }

        return najdeniIndeks;
    }
}