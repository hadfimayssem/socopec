using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socopec.Models
{
    public class Utilisateur
    {
        public string login { get; internal set; }
        public string password { get; internal set; }
        public string role { get; internal set; }
        public int archive { get; internal set; }
        public string lieu { get; internal set; }
    }
}