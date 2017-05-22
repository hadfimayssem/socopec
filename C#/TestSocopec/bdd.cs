// Librairie MySQL ajoutée dans les références.

using MySql.Data.MySqlClient;
using System;


namespace TestSocopec
{

    public class Bdd
    {

        private MySqlConnection connection;

        // Constructeur
        public Bdd()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=127.0.0.1; DATABASE=socopec; UID=root; PASSWORD=rootroot";
            this.connection = new MySqlConnection(connectionString);
        }


        /***********************************************************************************************************/
        //Gestion des vehicules

        public void AddVéhicule(Vehicule vehicule)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Vehicule (IdVehicule, Modele_Modele, DateFabrication, Etat_Statut, Agence_Lieu, Archive) VALUES (@id, @modele, @dateFabrication, @statut, @lieu, @archive)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@id", vehicule.id);
                cmd.Parameters.AddWithValue("@modele", vehicule.modele);
                cmd.Parameters.AddWithValue("@dateFabrication", vehicule.dateFabrication);
                cmd.Parameters.AddWithValue("@statut", vehicule.statut);
                cmd.Parameters.AddWithValue("@lieu", vehicule.lieu);
                cmd.Parameters.AddWithValue("@archive", vehicule.archive);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void archiveVehicule(Vehicule v, int i)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "UPDATE Vehicule set Archive ="+ i + "where IdVehicule = " + v.id ;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deleteVehicule(Vehicule v)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Vehicule WHERE IdVehicule = " + v.id;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Vehicule getVehicule(string id)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Vehicule WHERE IdVehicule = " + id;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string modele;
                string dateFabrication;
                string statut;
                string lieu;
                string archive;
                modele = dataReader["Modele_Modele"].ToString();
                dateFabrication = dataReader["DateFabrication"].ToString();
                statut = dataReader["Etat_Statut"].ToString();
                lieu = dataReader["Agence_Lieu"].ToString();
                archive = dataReader["Archive"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Vehicule v = new Vehicule();
                v.id = id;
                v.modele = modele;
                v.dateFabrication = DateTime.Parse(dateFabrication);
                v.statut = statut;
                v.lieu = lieu;
                v.archive = int.Parse(archive);

                return v;
            }
            catch
            {
                return new Vehicule();
            }
        }
        /***********************************************************************************************************/
        //Gestion des modèles
        public void AddModele(Modele modele)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Modele (Modele, Hauteur, Largeur, Poids, Puissance, ModeleArchive) VALUES (@modele, @hauteur, @largeur, @poids, @puissance, @archive)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@modele", modele.nom);
                cmd.Parameters.AddWithValue("@hauteur", modele.hauteur);
                cmd.Parameters.AddWithValue("@largeur", modele.largeur);
                cmd.Parameters.AddWithValue("@poids", modele.poids);
                cmd.Parameters.AddWithValue("@puissance", modele.puissance);
                cmd.Parameters.AddWithValue("@archive", modele.archive);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void archiveModele(Modele m, int i)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "UPDATE Modele set Archive =" + i + "where Modele = " + m.nom;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deleteModele(Modele m)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Modele WHERE nom = " + m.nom;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Modele getModele(string nom)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Modele WHERE modele = " + nom;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string hauteur;
                string largeur;
                string poids;
                string puissance;
                string archive;
                hauteur = dataReader["Hauteur"].ToString();
                largeur = dataReader["Largeur"].ToString();
                poids = dataReader["Poids"].ToString();
                puissance = dataReader["Puissance"].ToString();
                archive = dataReader["Archive"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Modele m = new Modele();
                m.nom = nom;
                m.hauteur = int.Parse(hauteur);
                m.largeur = int.Parse(largeur);
                m.poids = int.Parse(poids);
                m.puissance = int.Parse(puissance);
                m.archive = int.Parse(archive);

                return m;
            }
            catch
            {
                return new Modele();
            }
        }
        /***********************************************************************************************************/
        //Gestion des Historiques
        public void AddHistorique(Historique historique)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Historique (IdVehicule, DateDebut, DateRetour, Agence_Lieu, Etat_Statut, UtilisateurLogin) VALUES (@idVehicule, @dateDebut, @dateRetour, @lieu, @statut, @login)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@idVehicule", historique.idVehicule);
                cmd.Parameters.AddWithValue("@dateDebut", historique.dateDebut);
                cmd.Parameters.AddWithValue("@dateRetour", historique.dateRetour);
                cmd.Parameters.AddWithValue("@lieu", historique.lieu);
                cmd.Parameters.AddWithValue("@statut", historique.statut);
                cmd.Parameters.AddWithValue("@login", historique.login);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deleteHistorique(Historique h)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Historique WHERE idVehicule = " + h.idVehicule + " AND dateDebut = " + h.dateDebut;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Historique getHistorique(string idVehicule, DateTime dateDebut)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Historique WHERE IdVehicule = " + idVehicule + " AND dateDebut = " + dateDebut;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string dateRetour;
                string lieu;
                string statut;
                string login;
                dateRetour = dataReader["DateRetour"].ToString();
                lieu = dataReader["Lieu"].ToString();
                statut = dataReader["Statut"].ToString();
                login = dataReader["Login"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Historique h = new Historique();
                h.idVehicule = idVehicule;
                h.dateDebut = dateDebut;
                h.dateRetour = DateTime.Parse(dateRetour);
                h.lieu = lieu;
                h.statut = statut;
                h.login = login;

                return h;
            }
            catch
            {
                return new Historique();
            }
        }
        /***********************************************************************************************************/
        //Gestion des utilisateurs
        public void AddUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Utilisateur (Login, Password, Role, UtilisateurArchive, Agence_Lieu VALUES (@login, @password, @role, @archive, @lieu)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@login", utilisateur.login);
                cmd.Parameters.AddWithValue("@password", utilisateur.password);
                cmd.Parameters.AddWithValue("@role", utilisateur.role);
                cmd.Parameters.AddWithValue("@archive", utilisateur.archive);
                cmd.Parameters.AddWithValue("@lieu", utilisateur.lieu);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void archiveUtilisateur(Utilisateur u, int i)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "UPDATE Utilisateur set Archive =" + i + "where Login = " + u.login;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deleteUtilisateur(Utilisateur u)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Utilisateur WHERE Login = " + u.login;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Utilisateur getUtilisateur(string login)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Utilisateur WHERE Login = " + login;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string password;
                string role;
                string archive;
                string lieu;
                password = dataReader["Password"].ToString();
                role = dataReader["Role"].ToString();
                archive = dataReader["Archive"].ToString();
                lieu = dataReader["Lieu"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Utilisateur u = new Utilisateur();
                u.login = login;
                u.password = password;
                u.role = role;
                u.archive = int.Parse(archive);
                u.lieu = lieu;

                return u;
            }
            catch
            {
                return new Utilisateur();
            }
        }
        /***********************************************************************************************************/
        //Gestion des agences
        public void AddAgence(Agence agence)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Utilisateur (Lieu, LieuArchive VALUES (@lieu, @archive)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@lieu", agence.lieu);
                cmd.Parameters.AddWithValue("@archive", agence.archive);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void archiveAgence(Agence a, int i)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "UPDATE Agence set Archive =" + i + "where Lieu = " + a.lieu;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deleteAgence(Agence a)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Agence WHERE Lieu = " + a.lieu;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Agence getAgence(string lieu)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Agence WHERE Lieu = " + lieu;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string archive;
                archive = dataReader["Archive"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Agence a = new Agence();
                a.lieu = lieu;
                a.archive = int.Parse(archive);
   
                return a;
            }
            catch
            {
                return new Agence();
            }
        }
        /***********************************************************************************************************/
        //Gestion des états
        public void AddEtat(Etat etat)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Etat (Statut, StatutArchive VALUES (@statut, @archive)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@lieu", etat.statut);
                cmd.Parameters.AddWithValue("@archive", etat.archive);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void archiveEtat(Etat e, int i)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "UPDATE Etat set Archive =" + i + "where Statut = " + e.statut;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deleteStatut(Etat e)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Etat WHERE Statut = " + e.statut;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Etat getEtat(string statut)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Etat WHERE Statut = " + statut;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string archive;
                archive = dataReader["Archive"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Etat e = new Etat();
                e.statut = statut;
                e.archive = int.Parse(archive);

                return e;
            }
            catch
            {
                return new Etat();
            }
        }
        /***********************************************************************************************************/
        //Gestion des photos
        public void AddPhoto(Photo photo)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "INSERT INTO Photo (IdVehicule, Url) VALUES (@idVehicule, @url)";
                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@idVehicule", photo.idVehicule);
                cmd.Parameters.AddWithValue("@url", photo.url);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public void deletePhoto(Photo p)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();
                // Requête SQL
                cmd.CommandText = "DELETE FROM Photo WHERE Url = " + p.url;
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {
            }
        }
        public Photo getPhoto(string url)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();
                // Requête SQL
                string query = "SELECT * FROM Historique WHERE Url = " + url;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Exécution de la commande SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string idVehicule;
                idVehicule = dataReader["IdVehicule"].ToString();
                // Fermeture de la connexion
                this.connection.Close();

                Photo p = new Photo();
                p.idVehicule = idVehicule;
                p.url = url;

                return p;
            }
            catch
            {
                return new Photo();
            }
        }
    }

    public class Photo
    {
        public object idVehicule { get; internal set; }
        public object url { get; internal set; }
    }

    public class Etat
    {
        public object statut { get; internal set; }
        public object archive { get; internal set; }
    }

    public class Agence
    {
        public object lieu { get; internal set; }
        public object archive { get; internal set; }
    }

    public class Utilisateur
    {
        public string login { get; internal set; }
        public string password { get; internal set; }
        public string role { get; internal set; }
        public int archive { get; internal set; }
        public string lieu { get; internal set; }
    }

    public class Historique
    {
        public string idVehicule { get; internal set; }
        public DateTime dateDebut { get; internal set; }
        public DateTime dateRetour { get; internal set; }
        public string lieu { get; internal set; }
        public string statut { get; internal set; }
        public string login { get; internal set; }
    }

    public class Modele
    {
        public string nom { get; internal set; }
        public int hauteur { get; internal set; }
        public int largeur { get; internal set; }
        public int poids { get; internal set; }
        public int puissance { get; internal set; }
        public int archive { get; internal set; }
    }

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