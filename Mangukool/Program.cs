using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mangukool
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Failide Sisselugemine
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "Mangukooli ylesehituse programm";


            // teen klasside sisse lugemist
            string filename = @"..\..\Klassid.txt";
            string[] loetudread = File.ReadAllLines(filename).Skip(1).ToArray();

            foreach (var rida in loetudread)
            {
                string[] jupid = rida.Split(',');
                string[] oppeained = jupid[2].Trim().Split(' ');

                Klass uus = new Klass(jupid[0].Trim(), jupid[1].Trim(), oppeained) { };
            }

            //foreach (var klass in Klass.Klassid)
            //{
            //    Console.WriteLine($"{klass.Jark}, klassijuhata={klass.KlassijuhatajaIK}");
            //    foreach (var oppeaine in klass.Oppeained)
            //        Console.WriteLine(oppeaine);
            //}

            // teen lapsevanemad inimesteks

            string filename1 = @"..\..\Lapsevanem.txt";
            string[] loetudread1 = File.ReadAllLines(filename1).Skip(1).ToArray();

            foreach (var rida in loetudread1)
            {
                string[] jupid = rida.Split(',');
                string isikukood = jupid[0].Trim();
                string nimi = jupid[1].Trim();
                string lapseIsikukood = jupid[2].Trim();

                Inimene uus = new Inimene(isikukood, nimi, "", "", lapseIsikukood) { };
            }

            // teen opilased inimesteks
            string filename2 = @"..\..\Opilased.txt";
            string[] loetudread2 = File.ReadAllLines(filename2).Skip(1).ToArray();

            foreach (var rida in loetudread2)
            {
                string[] jupid = rida.Split(',');
                string isikukood = jupid[0].Trim();
                string nimi = jupid[1].Trim();
                string klasskusopib = jupid[2].Trim();

                Inimene uus = new Inimene(isikukood, nimi, klasskusopib, "", "") { };
            }

            // teen opetajad inimesteks
            string filename3 = @"..\..\Opetajad.txt";
            string[] loetudread3 = File.ReadAllLines(filename3).Skip(1).ToArray();

            foreach (var rida in loetudread3)
            {
                string[] jupid = rida.Split(',');
                string isikukood = jupid[0].Trim();
                string nimi = jupid[1].Trim();
                string ainemidaopetab = jupid[2].Trim();

                Inimene uus = new Inimene(isikukood, nimi, "", ainemidaopetab, "") { };
            }

            foreach (var inimene in Inimene.Inimesed)
            {
                //Console.WriteLine($"nimi:{inimene.Nimi}, IK; {inimene.Isikukood} Klass: {inimene.Klasskusopib} Aine: {inimene.Ainemidaopetab} LapseIK: {inimene.LapseIK}");
            }

            string filename4 = @"..\..\Hinded.txt";
            string[] loetudread4 = File.ReadAllLines(filename4).Skip(1).ToArray();

            foreach (var rida in loetudread4)
            {
                string[] jupid = rida.Split(',');
                string hindenumber = jupid[0].Trim();
                string hindesaaja = jupid[1].Trim();
                string hindepanija = jupid[2].Trim();
                string misaine = jupid[3].Trim();

                Hinne uus = new Hinne(hindenumber, hindesaaja, hindepanija, misaine) { };
            }

            foreach (var hinne in Hinne.Hinded)
            {
                //Console.WriteLine($"{hinne.Hindesaaja}");
            }
            #endregion

            // siis algab tegelikult kuvatav programm
            Kysinime();
        }


        static void Kysimistatahab(Inimene kasutaja)
        {

          
            #region Opilase vastused
            if (kasutaja.Klasskusopib != "")
            {
                Console.WriteLine("\nMis sa tahad naha:\na) Hindeid b) Oppeaineid c) Klassinimekirja?");
                string vastus = Console.ReadLine().ToLower();

                switch (vastus)
                {
                    case "a":
                        Hinne[] SelleOpilaseHinded = Hinne.Hinded
                            .Where(hinne => hinne.Hindesaaja == kasutaja.Isikukood)
                            .ToArray();

                        foreach (var hinne in SelleOpilaseHinded)
                        {
                            Console.WriteLine($" Aines {hinne.Misaines} on sul hinne {hinne.Hindenumber}");
                        }
                        break;

                    case "b":
                        string[] SelleOpilaseAined = Klass.Klassid
                            .Where(klass => klass.Jark == kasutaja.Klasskusopib)
                            .FirstOrDefault()
                            .Oppeained;

                        foreach (var oppeaine in SelleOpilaseAined)
                        {
                            Console.WriteLine($"Sinu oppeaine on: {oppeaine}");
                        }

                        break;
                    case "c":
                        Inimene[] SelleKlassikaaslased = Inimene.Inimesed
                            .Where(inimene => inimene.Klasskusopib == kasutaja.Klasskusopib)
                            .ToArray();
                        Console.WriteLine("Sinu klassis opivad:");
                        foreach (var inimene in SelleKlassikaaslased)
                        {
                            Console.WriteLine(inimene.Nimi);
                        }
                        break;
                    default:
                        Console.WriteLine("Palun vali yks variantidest!");
                        Console.Beep(200, 900);
                        break;
                }


            }
            #endregion

            #region Lapsevanema vastused
            else if (kasutaja.LapseIK != "")
            {
                Console.WriteLine("\nMis sa tahad naha:\na) Lapse hindeid b) Lapse klassikaaslasi ja nende lapsevanemaid?");
                string vastus = Console.ReadLine().ToLower();

                Inimene kasutajalaps = Inimene.Inimesed
                    .Where(inimene => inimene.Isikukood == kasutaja.LapseIK)
                    .FirstOrDefault();

                switch (vastus)
                {
                    case "a":
                        Hinne[] SelleLapseHinded = Hinne.Hinded
                            .Where(hinne => hinne.Hindesaaja == kasutajalaps.Isikukood)
                            .ToArray();

                        foreach (var hinne in SelleLapseHinded)
                        {
                            Console.WriteLine($" Aines {hinne.Misaines} on sinu lapsel {kasutajalaps.Nimi} hinne {hinne.Hindenumber}");
                        }
                        break;
                    
                    case "b":
                        Inimene[] SelleLapsekaaslased = Inimene.Inimesed
                            .Where(inimene => inimene.Klasskusopib == kasutajalaps.Klasskusopib)
                            .ToArray();

                        Console.WriteLine("Sinu lapse klassis opivad:");

                        foreach (var klassikaaslane in SelleLapsekaaslased)
                        {
                            Inimene KlassikaaslaseLV = Inimene.Inimesed
                                .Where(inimene => klassikaaslane.Isikukood == inimene.LapseIK)
                                .FirstOrDefault();

                            Console.WriteLine($" sinu lapse klassikaaslase {klassikaaslane.Nimi} vanem on {KlassikaaslaseLV.Nimi}");
                        }
                        break;

                    default:
                        Console.WriteLine("Palun vali yks variantidest!");
                        Console.Beep(200, 900);
                        break;
                }


            }
            #endregion

            #region Opetaja vastused
            else if (kasutaja.Ainemidaopetab != "")
            {
                Klass MilleKlassijuhatajaOn = Klass.Klassid
                    .Where(klass => klass.KlassijuhatajaIK == kasutaja.Isikukood)
                    .FirstOrDefault();

                if (MilleKlassijuhatajaOn != null)
                { // klassijuhataja
                    Console.WriteLine("\nMis sa tahad naha:\na) Oma klasside nimekirja b) Oma aine hindeid " +
                        "\nc)Oma klassi opilasi koos hinnete ja vanematega?");
                }
                else
                { // lihtne opetaja
                    Console.WriteLine("\nMis sa tahad naha:\na) Oma klasside opilaste nimekirja b) Oma aine hindeid ?");
                }

                    
                string vastus = Console.ReadLine().ToLower();

                switch (vastus)
                {
                    // otsin ules koik klassid (1a ja 2a), kus ta opetab 
                    //ja siis koik lapsed, kes nendes klassides kaivad
                    case "a":
                        Klass[] KlassidKusOpetab = Klass.Klassid
                             .Where(klass => Array.Exists(klass.Oppeained, oppeaine => oppeaine == kasutaja.Ainemidaopetab))
                             .ToArray();

                        foreach(var klass in KlassidKusOpetab)
                        {
                            Inimene[] LapsedKedaOpetabSellesKlassis = Inimene.Inimesed
                                .Where(inimene => klass.Jark == inimene.Klasskusopib)
                                .ToArray();

                            Console.WriteLine($" Klassis {klass.Jark} opivad:");

                            foreach (var laps in LapsedKedaOpetabSellesKlassis)
                            {
                                Console.WriteLine(laps.Nimi);
                            }
                        }
                        break;

                    case "b":
                        Hinne[] TemaAineHinded = Hinne.Hinded
                            .Where(hinne => kasutaja.Ainemidaopetab == hinne.Misaines && kasutaja.Isikukood == hinne.Hindepanija)
                            .ToArray();
                        foreach (var hinne in TemaAineHinded)
                        {
                            Inimene hindesaaja = Inimene.Inimesed
                                .Where(inimene => hinne.Hindesaaja == inimene.Isikukood)
                                .FirstOrDefault();
                            Console.WriteLine($" Sinu aines {kasutaja.Ainemidaopetab} on opilasel {hindesaaja.Nimi} hinne {hinne.Hindenumber}");
                        }
                        break;

                    case "c":
                        if (MilleKlassijuhatajaOn != null)
                        {
                            Inimene[] SelleKlassiopilased = Inimene.Inimesed
                                        .Where(inimene => inimene.Klasskusopib == MilleKlassijuhatajaOn.Jark)
                                        .ToArray();
                            Console.WriteLine($"Sinu klassis {MilleKlassijuhatajaOn.Jark} on opilased:");

                            foreach (var opilane in SelleKlassiopilased)
                            {
                                Console.WriteLine($"\n{opilane.Nimi}");

                                Hinne[] SelleOpilaseHinded = Hinne.Hinded
                                    .Where(hinne => hinne.Hindesaaja == opilane.Isikukood)
                                    .ToArray();

                                foreach (var x in SelleOpilaseHinded)
                                {
                                    Console.WriteLine($" hinne aines {x.Misaines} on {x.Hindenumber}");
                                }

                                Inimene SelleOpilaseVanem = Inimene.Inimesed
                                    .Where(inimene => opilane.Isikukood == inimene.LapseIK)
                                    .FirstOrDefault();
                                Console.WriteLine($"Tema vanem on:{SelleOpilaseVanem.Nimi}\n");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Te ei ole klassijuhataja, vabandage");
                        }
                            break;

                    default:
                        Console.WriteLine("Palun vali yks variantidest!");
                        Console.Beep(200, 900);
                        break;
                }


            }
            #endregion

           

            //uuesti kysimise loop
            Kysimistatahab(kasutaja);
        }

        

        // Otsima inimesi
        static void Kysinime()
        {
            Console.WriteLine("Sisesta oma IK, palun");
            //Console.Beep(200,500);
            string vastus = Console.ReadLine();

            Inimene kasutaja = Inimene.Inimesed
                .Where(x => x.Isikukood == vastus)
            .FirstOrDefault();

            if (kasutaja != null)
            {
                Console.WriteLine($"Tere {kasutaja.Nimi}");
                Kysimistatahab(kasutaja);
            }
            else
            {
                Console.WriteLine("Teid ei ole systeemis!");
                Console.Beep(200, 900);
                Kysinime();
            }

        }
    }
}
