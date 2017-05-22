using System;


static class Program
{

    static void Main(string[] args)
    {
        // Créer d'un contact à ajouter
        Vehicule vehicule1 = new Vehicule();
        vehicule.id = 71265;
        vehicule.modele = opel;
        vehicule.dateFabrication = DateTime(01,04,2004);
        vehicule.statut = "Loué";
        vehicule.lieu = "Nancy";
        vehicule.archive = false;



        // Création de l'objet Bdd pour l'intéraction avec la base de donnée MySQL
        Bdd bdd = new Bdd();
        bdd.AddContact(vehicule1);
    }

}
