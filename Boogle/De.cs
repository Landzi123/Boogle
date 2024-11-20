using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Boogle
{
    class dé
    {
        private char[] lettre; // Attribut du dé qu'on considère un tableau de taille 6
        private static Random random = new Random(); //L'instance de random

        //Constructeur 
        public dé(string Filename)
        {
            this.lettre = ReadFile(Filename); // Initialise le tableau de 6 faces
        }

        //Propriétes
        public char[] GetFaces
        {
            get { return this.lettre; }
        }

        private char[] ReadFile(string Filename)
        {
            char[] faces = new char[6]; //On crée un tableau pour stocker les 6 faces 
            try
            {
                if (File.Exists(Filename))
                {

                    string[] lignes = File.ReadAllLines(Filename);

                    List<(char lettre, int poids, int occurence)> lettresDisponibles = new List<(char, int, int)>();

                    foreach (string ligne in lignes)
                    {
                        string[] elements = ligne.Split(';');
                        if (elements.Length == 3) //Condition qui permet de vérifier que la ligne contient bel et bien 3 éléments
                        {
                            char lettre = Convert.ToChar(elements[0]);
                            int poids = int.Parse(elements[1]);
                            int occurence = int.Parse(elements[2]);

                            if (occurence > 0) // Condition qui va ajouter la lettre seulement si son occurence est supérieur à 0
                            {
                                lettresDisponibles.Add((lettre, poids, occurence));
                            }
                        }
                    }
                    for (int i = 0; i < 6; i++) //Boucle qui va permettre d'affecter un caractère à une face du Dé
                    {
                        int index = random.Next(lettresDisponibles.Count); //génère un nombre entier aléatoire compris entre 0 et 25
                        faces[i] = lettresDisponibles[index].lettre;       //L'indice index permet de sélectionner une lettre aléatoire dans la liste des lettres qui sont disponibles

                        // Réduire l'occurrence de la lettre sélectionnée
                        lettresDisponibles[index] = (lettresDisponibles[index].lettre, lettresDisponibles[index].poids, lettresDisponibles[index].occurence - 1);


                        if (lettresDisponibles[index].occurence == 0)// Supprimer la lettre si son occurrence atteint 0
                        {
                            lettresDisponibles.RemoveAt(index);
                        }
                    }

                    UpdateFile(Filename, lettresDisponibles);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return faces;
        }

        // Méthode pour mettre à jour le fichier après avoir modifiés l'occurrence(inspirés sur learn.microsoft)
        private void UpdateFile(string filename, List<(char lettre, int poids, int occurrences)> lettresDisponibles)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var lettre in lettresDisponibles)
                {
                    writer.WriteLine($"{lettre.lettre};{lettre.poids};{lettre.occurrences}");
                }
            }
        }

        public void Lance(Random r)
        {
            char lettreVisible;
            int index = r.Next(6);

            lettreVisible = this.lettre[index];

        }
        public string toString()
        {
            string Decrit_De = "";
            foreach(char lettre in this.lettre)
            {
                Decrit_De += lettre +" ";
            }
            return Decrit_De;
        }
    }
}
