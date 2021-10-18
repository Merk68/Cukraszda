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
      HatodikFeladat();
      hetedikfeladat();
    }

    private void hetedikfeladat()
    {
      
    }

    private void HatodikFeladat()
    {
      Dictionary<string, int> stat = new Dictionary<string, int>();
      foreach (var l in lista)
      {
        if (stat.ContainsKey(l.Stipus))
        {
          stat[l.Stipus]++;
        }
        else
        {
          stat.Add(l.Stipus, 1);
        }

        StreamWriter ki = new StreamWriter("stat.csv");
        foreach (var d in stat)
        {
          ki.WriteLine($"{d.Key};{d.Value}");
        }
        ki.Close();
      }
    }

    private void beirascsv()
    {
      List<string> kifele = new List<string>();
      foreach (var l in lista)
      {
        if (!kifele.Contains($"{l.Snev} {l.Stipus}".ToUpper()));
        {
          kifele.Add($"{l.Snev} {l.Stipus}".ToUpper());
        }
      }
      kifele.Sort();

      StreamWriter kicsv = new StreamWriter("lista.txt");
      foreach (var l in lista)
      {
        kicsv.WriteLine(l);
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
      string haha = "";
      int min = int.MaxValue;
      for (int i = 0; i < lista.Count; i++)
      {
        if (lista[i].Ar < min)
        {
          haha = lista[i].Snev;
          min = lista[i].Ar;
        }
      }
      tbLegolcsobb.Text = $"{haha}";
      tbLegolcsobbar.Text = $"{min} Ft/24 szeletes";
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
      Random r = new Random(); //Guid.NewGuid().GetHashCode()nagyonrn
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

    private void bAjanlatment_Click(object sender, EventArgs e)
    {
      if (tbSutitipus.Text == "")
      {
        MessageBox.Show("Nem írtál be típust");
      }
      else
      {
        List<data> ajanlat = new List<data>();
        foreach (var l in lista)
        {
          if (l.Stipus == tbSutitipus.Text)
          {
            ajanlat.Add(l);
          }
        }
        if (ajanlat.Count == 0)
        {
          MessageBox.Show("Nincs ilyen süti. Válassz mást!");
        }
        else
        {
          try
          {
            StreamWriter ki = new StreamWriter("ajanlat.txt");
            
            foreach (var a in ajanlat)
            {
              ki.WriteLine(a.ToString());
            }
            int ossz = 0;
            foreach (var a in ajanlat)
            {
              ki.WriteLine(a.ToString());
              ossz += a.Ar;
            }
            ki.Close();
            MessageBox.Show($"{tbSutitipus.Text} tipusu sutemenyek atlagara {(double)ossz / ajanlat.Count:n2}");
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
            
          }
        }
      }
    }

    private void bUjsuti_Click(object sender, EventArgs e)
    {
      if (tbSutineve.Text == "" || tbSutitipusa.Text == "" ||tbEgyseg.Text == "" || tbAr.Text == "")
      {
        MessageBox.Show("nem adtál meg minden adatot!");
      }
      else
      {
        int ar;
        if (int.TryParse(tbAr.Text, out ar))
        {
          data uj = new data(tbSutineve.Text, tbSutitipusa.Text, cbDijazott.Checked, ar, tbEgyseg.Text);
          lista.Add(uj);
          StreamWriter ki = new StreamWriter("cuki.txt", true);
        }
        else
        {
          MessageBox.Show("Az uj sutemeny ara nem jó!");
          tbAr.Focus();
        }
      }
    }
  }
}
