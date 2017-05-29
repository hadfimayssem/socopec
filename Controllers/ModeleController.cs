using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;

using Socopec.Models;
using Socopec;

namespace Socopec.Controllers
{
    public class ModeleController : ApiController
    {
        // GET: api/Modele
        public ArrayList Get()
        {
            ModelePersistance mp = new ModelePersistance();
            return mp.getModeles();
        }

        // GET: api/Modele/c3
        public Modele Get(string nom)
        {
            ModelePersistance mp = new ModelePersistance();
            Modele m = mp.getModele(nom);
            return m;
        }

        // POST: api/Modele
        public HttpResponseMessage Post([FromBody]Modele value)
        {
            ModelePersistance mp = new ModelePersistance();
            long id;
            id = mp.saveModele(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Modele/{0}", id));
            return response;
        }

        // PUT: api/Modele/C3
        public HttpResponseMessage Put(string nom, [FromBody]Modele value)
        {
            ModelePersistance mp = new ModelePersistance();
            bool recordExist = false;
            recordExist = mp.updateModele(nom, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Modele/C3
        public HttpResponseMessage Delete(string nom)
        {
            ModelePersistance mp = new ModelePersistance();
            bool recordExist = false;
            recordExist = mp.deleteModele(nom);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class ModelePersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public ModelePersistance()
            {
                string myConnectionString;
                myConnectionString = "SERVER=127.0.0.1; DATABASE=socopec; UID=root; PASSWORD=rootroot";
                try
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                { }
            }

            public ArrayList getModeles()
            {
                ArrayList modeleArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Modele";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Modele m = new Modele();
                    m.nom = mySQLReader.GetString(0);
                    m.hauteur = mySQLReader.GetInt32(1);
                    m.largeur = mySQLReader.GetInt32(2);
                    m.poids = mySQLReader.GetInt32(3);
                    m.puissance = mySQLReader.GetInt32(4);
                    m.archive = mySQLReader.GetInt32(5);
                    modeleArray.Add(m);
                }
                return modeleArray;
            }

            public Modele getModele(string nom)
            {
                Modele m = new Modele();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Modele WHERE Modele = " + nom;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    m.nom = mySQLReader.GetString(0);
                    m.hauteur = mySQLReader.GetInt32(1);
                    m.largeur = mySQLReader.GetInt32(2);
                    m.poids = mySQLReader.GetInt32(3);
                    m.puissance = mySQLReader.GetInt32(4);
                    m.archive = mySQLReader.GetInt32(5);
                    return m;
                }
                else
                    return null;
            }

            public long saveModele(Modele modeleToSave)
            {
                String sqlString = "INSERT INTO Modele (Modele, Hauteur, Largeur, Poids, Puissance, ModeleArchive) VALUES ('" + modeleToSave.nom + "','" + modeleToSave.hauteur + "','" + modeleToSave.largeur + "','" + modeleToSave.poids + "','" + modeleToSave.puissance + "','" + modeleToSave.archive + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deleteModele(string nom)
            {
                Modele m = new Modele();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Modele WHERE Modele = " + nom;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Modele WHERE WHERE Modele = " + nom;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updateModele(string nom, Modele m)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Vehicule WHERE ID = " + nom;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Modele SET Modele ='" + m.nom + "', Hauteur ='" + m.hauteur + "', Largeur ='" + m.largeur + "', Poids = '" + m.poids + "', Puissance = '" + m.puissance + "', Archive ='" + m.archive + "' WHERE Modele ='" + nom;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }


        }
    }
}
