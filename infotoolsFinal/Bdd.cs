using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using infotoolsFinal;
using MySql.Data.MySqlClient;

namespace infotoolsFinal
{
    public class Bdd
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;



        //Initialisation des valeurs
        public static void Initialize()
        {
            //Information de connection pour la BDD
            server = "localhost";      //Adresse du serveur 
            database = "bdd_infotools";    //Nom de la BDD
            uid = "root";              //Identifiant d'un utilisateur
            password = "root";         //Mot de passe du même utilisateur
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Erreur connexion BDD");
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        //Méthode pour insérer un nouvel enregistrement à la table RendezVous
        public static void InsertRendezVous(string nomRendezVous, string prenomRendezVous, string mailRendezVous, string telRendezVous, int numSirenRendezVous, string nomSocieteRendezVous, string villeRendezVous, string cpRendezVous, string adresseRendezVous, string dateRendezVous, string heureDebutRendezVous, string heureFinRendezVous, string butRendezVous, string descriptionRendezVous, int confirmationRendezVous, int numCommerciaux)
        {
            //Requête Insertion RendezVous
            string query = "INSERT INTO rendezvous (nomRendezVous, prenomRendezVous, mailRendezVous, telRendezVous, numSirenRendezVous, nomSocieteRendezVous, villeRendezVous, cpRendezVous, adresseRendezVous, dateRendezVous, heureDebutRendezVous, heureFinRendezVous, butRendezVous, descriptionRendezVous, confirmationRendezVous, numCommerciaux) VALUES('" + nomRendezVous + "','" + prenomRendezVous + "','" + mailRendezVous + "','" + telRendezVous + "','" + numSirenRendezVous + "','" + nomSocieteRendezVous + "','" + villeRendezVous + "','" + cpRendezVous + "','" + adresseRendezVous + "','" + dateRendezVous + "','" + heureDebutRendezVous + "','" + heureFinRendezVous + "','" + butRendezVous + "','" + descriptionRendezVous + "','" + confirmationRendezVous + "','" + numCommerciaux + "')";
            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }


        public static void UpdateRendezVous(int numRendezVous, string nomRendezVous, string prenomRendezVous, string mailRendezVous, string telRendezVous, int numSirenRendezVous, string nomSocieteRendezVous, string villeRendezVous, string cpRendezVous, string adresseRendezVous, string dateRendezVous, string heureDebutRendezVous, string heureFinRendezVous, string butRendezVous, string descriptionRendezVous, int confirmationRendezVous, int NumCommerciaux)
        {
            //Update RendezVous
            string query = "UPDATE rendezvous SET numRendezVous='" + numRendezVous + "', nomRendezVous='" + nomRendezVous + "', prenomRendezVous='" + prenomRendezVous + "', mailRendezVous ='" + mailRendezVous + "', telRendezVous ='" + telRendezVous + "', numSirenRendezVous ='" + numSirenRendezVous + "', nomSocieteRendezVous ='" + nomSocieteRendezVous + "', villeRendezVous ='" + villeRendezVous + "', cpRendezVous = '" + cpRendezVous + "', adresseRendezVous ='" + adresseRendezVous + "', dateRendezVous = '" + dateRendezVous + "', heureDebutRendezVous ='" + heureDebutRendezVous + "', heureFinRendezVous = '" + heureFinRendezVous + "', butRendezVous ='" + butRendezVous + "', descriptionRendezVous ='" + descriptionRendezVous + "', confirmationRendezVous='" + confirmationRendezVous + "', numCommerciaux='" + NumCommerciaux + "' WHERE numRendezVous=" + numRendezVous;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }


        //Méthode pour supprimer un élément au numéro donnée de la table RendezVous
        public static void DeleteRendezVous(int numRendezVous)
        {
            //Delete Contrat
            string query = "DELETE FROM RendezVous WHERE numRendezVous=" + numRendezVous;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }


        //Méthode pour afficher tous les enregistrements de la table RendezVous
        public static List<RendezVous> SelectRendezVous()
        {
            //Select statement
            string query = "SELECT * FROM rendezvous INNER JOIN commerciaux ON rendezvous.numCommerciaux = commerciaux.numCommerciaux INNER JOIN identification ON commerciaux.numPassword = identification.numPassword";

            //Create a list to store the result
            List<RendezVous> dbRendezVous = new List<RendezVous>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Identification leIdentification = new Identification(Convert.ToInt32(dataReader["numPassword"]), Convert.ToString(dataReader["Password"]));
                    Commerciaux leCommerciaux = new Commerciaux(Convert.ToInt16(dataReader["numCommerciaux"]), Convert.ToString(dataReader["nomCommerciaux"]), Convert.ToString(dataReader["prenomCommerciaux"]), Convert.ToString(dataReader["adresseCommerciaux"]), Convert.ToString(dataReader["villeCommerciaux"]), Convert.ToString(dataReader["cpCommerciaux"]), Convert.ToString(dataReader["mailCommerciaux"]), Convert.ToString(dataReader["telCommerciaux"]), leIdentification);
                    RendezVous leRendezVous = new RendezVous(Convert.ToInt16(dataReader["numRendezVous"]), Convert.ToString(dataReader["nomRendezVous"]), Convert.ToString(dataReader["prenomRendezVous"]), Convert.ToString(dataReader["mailRendezVous"]), Convert.ToString(dataReader["telRendezVous"]), Convert.ToInt32(dataReader["numSirenRendezVous"]), Convert.ToString(dataReader["nomSocieteRendezVous"]), Convert.ToString(dataReader["villeRendezVous"]), Convert.ToString(dataReader["cpRendezVous"]), Convert.ToString(dataReader["adresseRendezVous"]), Convert.ToString(dataReader["dateRendezVous"]), Convert.ToString(dataReader["heureDebutRendezVous"]), Convert.ToString(dataReader["heureFinRendezVous"]), Convert.ToString(dataReader["butRendezVous"]), Convert.ToString(dataReader["descriptionRendezVous"]), Convert.ToInt32(dataReader["confirmationRendezVous"]), leCommerciaux);
                    dbRendezVous.Add(leRendezVous);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbRendezVous;
            }
            else
            {
                return dbRendezVous;
            }
        }

        //Méthode qui renvoie l'enregistrement concerné par rapport au numéro pour la table RendezVous
        public static RendezVous SearchRendezVous(int numRendezVous)
        {
            //Select statement
            string query = "SELECT * FROM rendezvous INNER JOIN commerciaux ON rendezvous.numCommerciaux = commerciaux.numCommerciaux INNER JOIN identification ON commerciaux.numPassword = identification.numPassword WHERE numRendezVous = " + numRendezVous;

            //Create a list to store the result
            List<RendezVous> dbRendezVous = new List<RendezVous>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmdS = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReaderS = cmdS.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReaderS.Read())
                {
                    Identification leIdentification = new Identification(Convert.ToInt32(dataReaderS["numPassword"]), Convert.ToString(dataReaderS["Password"]));
                    Commerciaux leCommerciaux = new Commerciaux(Convert.ToInt16(dataReaderS["numcommerciaux"]), Convert.ToString(dataReaderS["nomcommerciaux"]), Convert.ToString(dataReaderS["prenomcommerciaux"]), Convert.ToString(dataReaderS["adressecommerciaux"]), Convert.ToString(dataReaderS["villecommerciaux"]), Convert.ToString(dataReaderS["cpcommerciaux"]), Convert.ToString(dataReaderS["mailcommerciaux"]), Convert.ToString(dataReaderS["telcommerciaux"]), leIdentification);
                    RendezVous leRendezVous = new RendezVous(Convert.ToInt32(dataReaderS["numRendezVous"]), Convert.ToString(dataReaderS["nomRendezVous"]), Convert.ToString(dataReaderS["prenomRendezVous"]), Convert.ToString(dataReaderS["mailRendezVous"]), Convert.ToString(dataReaderS["telRendezVous"]), Convert.ToInt32(dataReaderS["numSirenRendezVous"]), Convert.ToString(dataReaderS["nomSocieteRendezVous"]), Convert.ToString(dataReaderS["villeRendezVous"]), Convert.ToString(dataReaderS["cpRendezVous"]), Convert.ToString(dataReaderS["adresseRendezVous"]), Convert.ToString(dataReaderS["dateSirenRendezVous"]), Convert.ToString(dataReaderS["heureDebutRendezVous"]), Convert.ToString(dataReaderS["heureFinRendezVous"]), Convert.ToString(dataReaderS["butRendezVous"]), Convert.ToString(dataReaderS["descriptionRendezVous"]), Convert.ToInt32(dataReaderS["confirmationRendezVous"]), leCommerciaux);
                    dbRendezVous.Add(leRendezVous);
                }

                //fermeture du Data Reader
                dataReaderS.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbRendezVous[0];

            }
            else
            {
                //retour de la collection pour être affichée
                return dbRendezVous[0];
            }

        }







        //Méthode pour afficher tous les enregistrements de la table Commerciaux
        public static List<Commerciaux> SelectCommerciaux()
        {
            //Select statement
            string query = "SELECT * FROM commerciaux INNER JOIN identification ON commerciaux.numPassword = identification.numPassword";

            //Create a list to store the result
            List<Commerciaux> dbCommerciaux = new List<Commerciaux>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Identification leIdentification = new Identification(Convert.ToInt32(dataReader["numpassword"]), Convert.ToString(dataReader["password"]));
                    Commerciaux leCommerciaux = new Commerciaux(Convert.ToInt16(dataReader["numcommerciaux"]), Convert.ToString(dataReader["nomcommerciaux"]), Convert.ToString(dataReader["prenomcommerciaux"]), Convert.ToString(dataReader["adressecommerciaux"]), Convert.ToString(dataReader["villecommerciaux"]), Convert.ToString(dataReader["cpcommerciaux"]), Convert.ToString(dataReader["mailcommerciaux"]), Convert.ToString(dataReader["telcommerciaux"]), leIdentification);
                    dbCommerciaux.Add(leCommerciaux);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbCommerciaux;
            }
            else
            {
                return dbCommerciaux;
            }
        }

        //Méthode qui renvoie l'enregistrement concerné par rapport au numéro pour la table Commerciaux
        public static Commerciaux SearchCommerciaux(int numCommerciaux)
        {
            //Select statement
            string query = "SELECT * FROM commerciaux WHERE INNER JOIN identification ON commerciaux.numPassword = identification.numPassword numCommerciaux = " + numCommerciaux;

            //Create a list to store the result
            List<Commerciaux> dbCommerciaux = new List<Commerciaux>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmdS = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReaderS = cmdS.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReaderS.Read())
                {
                    Identification leIdentification = new Identification(Convert.ToInt32(dataReaderS["numPassword"]), Convert.ToString(dataReaderS["Password"]));
                    Commerciaux leCommerciaux = new Commerciaux(Convert.ToInt16(dataReaderS["numcommerciaux"]), Convert.ToString(dataReaderS["nomcommerciaux"]), Convert.ToString(dataReaderS["prenomcommerciaux"]), Convert.ToString(dataReaderS["adressecommerciaux"]), Convert.ToString(dataReaderS["villecommerciaux"]), Convert.ToString(dataReaderS["cpcommerciaux"]), Convert.ToString(dataReaderS["mailcommerciaux"]), Convert.ToString(dataReaderS["telcommerciaux"]), leIdentification);
                    dbCommerciaux.Add(leCommerciaux);
                }

                //fermeture du Data Reader
                dataReaderS.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbCommerciaux[0];
            }
            else
            {
                //retour de la collection pour être affichée
                return dbCommerciaux[0];
            }

        }
    }
}
