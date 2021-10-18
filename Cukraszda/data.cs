using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukraszda
{
  class data
  {
    private string snev;

    public string Snev
    {
      get { return snev; }
      set { snev = value; }
    }
    private string stipus;

    public string Stipus
    {
      get { return stipus; }
      set { stipus = value; }
    }
    private bool dijase;

    public bool Dijase
    {
      get { return dijase; }
      set { dijase = value; }
    }
    private int ar;

    public int Ar
    {
      get { return ar; }
      set { ar = value; }
    }
    private string egysegnev;

    public string Egysegnev
    {
      get { return egysegnev; }
      set { egysegnev = value; }
    }

    public data(string snev, string stipus, bool dijase, int ar, string egysegnev)
    {
      this.snev = snev;
      this.stipus = stipus;
      this.dijase = dijase;
      this.ar = ar;
      this.egysegnev = egysegnev;
    }
    public data(string adatok)
    {
      string[] a = adatok.Split(';');
      Snev = a[0];
      Stipus = a[1];
      dijase = Convert.ToBoolean(a[2]);
      ar = Convert.ToInt32(a[3]);
      egysegnev = a[4];
    }
    public override string ToString()
    {
      return $"{Snev};{ar};{egysegnev}";
    }
  }
}
