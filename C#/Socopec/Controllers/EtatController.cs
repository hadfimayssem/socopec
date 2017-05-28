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
    public class EtatController : ApiController
    {
        // GET: api/Etat
        public ArrayList Get()
        {
            EtatPersistance ep = new EtatPersistance();
            return ep.getEtats();
        }

        // GET: api/Etat/Vendu
        public Etat Get(string statut)
        {
            EtatPersistance ep = new EtatPersistance();
            Etat e = ep.getEtat(statut);
            return e;
        }

        // POST: api/Etat
        public HttpResponseMessage Post([FromBody]Etat value)
        {
            EtatPersistance ep = new EtatPersistance();
            long id;
            id = ep.saveEtat(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Etat/{0}", id));
            return response;
        }

        // PUT: api/Etat/Vendu
        public HttpResponseMessage Put(string statut, [FromBody]Etat value)
        {
            EtatPersistance ep = new EtatPersistance();
            bool recordExist = false;
            recordExist = ep.updateEtat(statut, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Etat/Vendu
        public HttpResponseMessage Delete(string statut)
        {
            EtatPersistance ep = new EtatPersistance();
            bool recordExist = false;
            recordExist = ep.deleteEtat(statut);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class EtatPersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public EtatPersistance()
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

            public ArrayList getEtats()
            {
                ArrayList EtatArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Etat";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Etat e = new Etat();
                    e.statut = mySQLReader.GetString(0);
                    e.archive = mySQLReader.GetString(1);
                    EtatArray.Add(e);
                }
                return EtatArray;
            }

            public Etat getEtat(string statut)
            {
                Etat e = new Etat();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Etat WHERE Statut = " + statut;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    e.statut = mySQLReader.GetString(0);
                    e.archive = mySQLReader.GetString(1);
                    return e;
                }
                else
                    return null;
            }

            public long saveEtat(Etat etatToSave)
            {
                String sqlString = "INSERT INTO Etat (Statut, EtatArchive) VALUES ('" + etatToSave.statut + "','" + etatToSave.archive + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deleteEtat(string statut)
            {
                Etat e = new Etat();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Etat WHERE Statut = " + statut;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Etat WHERE Statut = " + statut;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updateEtat(string statut, Etat e)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Etat WHERE Statut = " + statut;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Etat SET Statut ='" + e.statut + "', EtatArchive ='" + e.archive;
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
