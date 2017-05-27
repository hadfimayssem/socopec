using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socopec.Models
{
    public class Historique
    {
        public string idVehicule { get; internal set; }
        public DateTime dateDebut { get; internal set; }
        public DateTime dateRetour { get; internal set; }
        public string lieu { get; internal set; }
        public string statut { get; internal set; }
        public string login { get; internal set; }
    }
}