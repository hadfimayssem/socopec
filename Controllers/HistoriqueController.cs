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
    public class HistoriqueController : ApiController
    {
        // GET: api/Historique
        public ArrayList Get()
        {
            HistoriquePersistance hp = new HistoriquePersistance();
            return hp.getHistoriques();
        }

        // GET: api/Historique/5/2012-05-30
        public Historique Get(string id, string date)
        {
            HistoriquePersistance hp = new HistoriquePersistance();
            Historique h = hp.getHistorique(id, date);
            return h;
        }

        // POST: api/Historique
        public HttpResponseMessage Post([FromBody]Historique value)
        {
            HistoriquePersistance hp = new HistoriquePersistance();
            long id;
            id = hp.saveHistorique(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Vehicule/{0}", id));
            return response;
        }

        // PUT: api/Historique/5/2012-05-30
        public HttpResponseMessage Put(string id, string date, [FromBody]Historique value)
        {
            HistoriquePersistance hp = new HistoriquePersistance();
            bool recordExist = false;
            recordExist = hp.updateHistorique(id, date, value);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        // DELETE: api/Historique/5/2012-05-30
        public HttpResponseMessage Delete(string id, string date)
        {
            HistoriquePersistance vp = new HistoriquePersistance();
            bool recordExist = false;
            recordExist = vp.deleteHistorique(id, date);

            HttpResponseMessage response;
            if (recordExist)
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        public class HistoriquePersistance
        {
            private MySql.Data.MySqlClient.MySqlConnection conn;

            public HistoriquePersistance()
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

            public ArrayList getHistoriques()
            {
                ArrayList HistoriqueArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Historique";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Historique h = new Historique();
                    h.idVehicule = mySQLReader.GetString(0);
                    h.dateDebut = mySQLReader.GetDateTime(1);
                    h.dateRetour = mySQLReader.GetDateTime(2);
                    h.lieu = mySQLReader.GetString(3);
                    h.statut = mySQLReader.GetString(4);
                    h.login = mySQLReader.GetString(5);
                    HistoriqueArray.Add(h);
                }
                return HistoriqueArray;
            }

            public Historique getHistorique(string id, string date)
            {
                Historique h = new Historique();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Historique WHERE IdVehicule = " + id + " AND DateDebut = " + date;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    h.idVehicule = mySQLReader.GetString(0);
                    h.dateDebut = mySQLReader.GetDateTime(1);
                    h.dateRetour = mySQLReader.GetDateTime(2);
                    h.lieu = mySQLReader.GetString(3);
                    h.statut = mySQLReader.GetString(4);
                    h.login = mySQLReader.GetString(5);
                    return h;
                }
                else
                    return null;
            }

            public long saveHistorique(Historique historiqueToSave)
            {
                String sqlString = "INSERT INTO Historique (IdVehicule, DateDebut, DateRetour, Agence_Lieu, Etat_Statut, Utilisateur_Login) VALUES ('" + historiqueToSave.idVehicule + "','" + historiqueToSave.dateDebut + "','" + historiqueToSave.dateRetour.ToString("YYYY-MM-dd") + "','" + historiqueToSave.lieu + "','" + historiqueToSave.statut + "','" + historiqueToSave.login + "')'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }

            public bool deleteHistorique(string id, string date)
            {
                Historique h = new Historique();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Historique WHERE IdVehicule = " + id + " AND DateDebut = " + date;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlString = "DELETE FROM Historique WHERE IdVehicule = " + id + " AND DateDebut = " + date;
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }

            public bool updateHistorique(string id, string date, Historique h)
            {
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                string sqlString = "SELECT * FROM Historique WHERE IdVehicule = " + id + " AND DateDebut = " + date;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlString = "UPDATE Historique SET IdVehicule ='" + h.idVehicule + "', DateDebut ='" + h.dateDebut.ToString("YYYY-MM-dd") + "', DateRetour ='" + h.dateRetour.ToString("YYYY-MM-dd") + "', Agence_Lieu = '" + h.lieu + "', Etat_Statut = '" + h.statut + "', Utilisateur_Login ='" + h.login + "' WHERE IdVehicule ='" + id + "' AND DateDebut ='" + date;
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
