using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Pilota
{
    public string Nev { get; set; }
    public string Nemzetiseg { get; set; }
    public string Csapat { get; set; }
    public int RajtPozicio { get; set; }
    public float VersenyIdo { get; set; }
    public int Pontok { get; set; }

    public Pilota(string sor)
    {
        var adatok = sor.Split(';');
        Nev = adatok[0];
        Nemzetiseg = adatok[1];
        Csapat = adatok[2];
        RajtPozicio = int.Parse(adatok[3]);
        VersenyIdo = float.Parse(adatok[4].Replace('.', ',')); 
        Pontok = int.Parse(adatok[5]);
    }
}

class Program
{
    static void Main()
    {
        string fajlUtvonal = "C:\\Users\\ny20Bhornyáká\\source\\repos\\F1Verseny\\F1Verseny\\MELBOURNE_F1\\melbourne2009.txt";
        List<Pilota> pilotak = new List<Pilota>();

        foreach (var sor in File.ReadAllLines(fajlUtvonal).Skip(1)) 
        {
            pilotak.Add(new Pilota(sor));
        }

        // 1. feladat
        Console.WriteLine("1.feladat:");
        Console.WriteLine($"Ennyi pilóta ért célba: {pilotak.Count}");
        Console.WriteLine();

        // 2. feladat
        Console.WriteLine("2.feladat:");
        int osszesPont = pilotak.Sum(x => x.Pontok);
        Console.WriteLine($"Ennyi világbajnoki pont lett kiosztva: {osszesPont}");
        Console.WriteLine();

        // 3. feladat
        Console.WriteLine("3.feladat:");
        int nemetVersenyzok = pilotak.Count(p => p.Nemzetiseg.Contains("germany"));
        Console.WriteLine($"Német versenyzők száma: {nemetVersenyzok}");
        Console.WriteLine();

        // 4. feladat
        var pontszerzoCsapatok = pilotak.Where(p => p.Pontok > 0).Select(p => p.Csapat).Distinct();
        Console.WriteLine("4.feladat:");
        foreach (var csapat in pontszerzoCsapatok)
        {
            Console.WriteLine($"   - {csapat}");
        }
        Console.WriteLine();

        // 5. feladat
        var gyoztes = pilotak.OrderBy(p => p.VersenyIdo).First();
        Console.WriteLine("5.feladat:");
        Console.WriteLine($"Győztes: {gyoztes.Nev}, ennyivel nyert: {gyoztes.VersenyIdo}");
    }
}
