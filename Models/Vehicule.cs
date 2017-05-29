using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socopec.Models
{
    public class Vehicule
    {
        public string id { get; internal set; }
        public string modele { get; internal set; }
        public DateTime dateFabrication { get; internal set; }
        public string statut { get; internal set; }
        public string lieu { get; internal set; }
        public int archive { get; internal set; }
    }
}