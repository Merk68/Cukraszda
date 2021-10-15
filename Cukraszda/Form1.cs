using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cukraszda
{
  public partial class Form1 : Form
  {
    List<data> lista = new List<data>();
    public Form1()
    {
      InitializeComponent();
      beolvasas();
      randomsuti();
      negyesdarabdijazott();
      Legdaragabbsuti();
      Legolcsobbsuti();
      beiras();
      beirascsv();
    }

    private void beirascsv()
    {
      StreamWriter kicsv = new StreamWriter("stat.csv");
      foreach (var l in lista)
      {
        kicsv.WriteLine(l.Stipus + " " + l.Stipus);
      }
      kicsv.Close();
    }

    private void beiras()
    {
      StreamWriter ki = new StreamWriter("lista.txt");
      foreach (var l in lista)
      {
         ki.WriteLine(l.Snev + " " + l.Stipus);
      }
      ki.Close();
    }

    private void Legolcsobbsuti()
    {
      int haha = 0;
      int min = 0;
      for (int i = 1; i < lista.Count; i++)
      {
        if (lista[i].Ar < min)
        {
          haha = i;
          min = lista[i].Ar;
        }
      }
      tbLegolcsobb.Text = $"{lista[haha].Snev}";
      tbLegolcsobbar.Text = $"{lista[haha].Ar} Ft/24 szeletes";
    }

    private void Legdaragabbsuti()
    {
      int hehe = 0;
      int max = 0;
      for (int i = 0; i < lista.Count; i++)
      {
        if (lista[i].Ar > max)
        {
          hehe = i;
          max = lista[i].Ar;
        }
      }
      tbLegdragabb.Text = $"{lista[hehe].Snev}";
      tbLegdragabbar.Text = $"{lista[hehe].Ar} Ft/24 szeletes";
    }

    private void negyesdarabdijazott()
    {
      int darab = 0;
      foreach (var l in lista)
      {
        if (l.Dijase)
        {
          darab++;
        }
      }
      tbHanyfele.Text = $"{darab} féle díjmentes édességből választhat.";
    }

    private void randomsuti()
    {
      Random r = new Random();
      int genRand = r.Next(lista.Count);
      Console.WriteLine($"Egy süti: {genRand}");
      tbMaiajanlat.Text = $"Mai ajánlatunk: {lista[genRand].Snev}";
    }

    private void beolvasas()
    {
      StreamReader olv = new StreamReader("cuki.txt");
      while (!olv.EndOfStream)
      {
        string[] a = olv.ReadLine().Split(';');
        lista.Add(new data(a[0], a[1], Convert.ToBoolean(a[2]), int.Parse(a[3]), (a[4])));
      }
      olv.Close();
    }

    private void Form1_Shown(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }
  }
}
