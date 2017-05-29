using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socopec.Models
{
    public class Modele
    {
        public string nom { get; internal set; }
        public int hauteur { get; internal set; }
        public int largeur { get; internal set; }
        public int poids { get; internal set; }
        public int puissance { get; internal set; }
        public int archive { get; internal set; }
    }
}