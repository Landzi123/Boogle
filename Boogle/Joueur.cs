using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Boogle
{
    class Joueur
    {
        /// <summary>
        /// Attributs de la fonction Joueur
        /// </summary>
        private string nom;
        private int score=0; 
        List<string> MotsTrouves;

        ///Constructeur naturel

        public Joueur(string nom, int score, List<string> MotsTrouves)
        {
            while(nom == null)// Existence de nom ?
            {
                Console.WriteLine("Le nom du joueur n'est pas valide");
                this.nom=Console.ReadLine();
            }
            
            this.score = score;
            this.MotsTrouves = new List<string>();// est ce que pour les listes c'est bien cette écriture 
        

    }

        ///Propriétés

        public string GetNom
        {
            get { return this.nom; }
            

        }

        public int GetScore
        {
            get { return this.score; }
            
        }

        public List<string> GetMotsTrouves// question sur get/set
        {
            get { return this.MotsTrouves; }
            set { this.MotsTrouves = value; }
        }
        ///Méthodes
        
        public bool Contain(string mot)///Fonction qui sert à savoir si un mot à déjà été écrit par le joueur
        {
            
            return this.MotsTrouves.Contains(mot); //peut-on utiliser la méthode contains?
        }

        public void Add_Mot(string mot) ///Ajoute les mots trouvés par le joueur dans la liste de mots trouvés
        {
            //List<string> MotsTrouves += mot; ;
            if(!Contain(mot))
            {
                this.MotsTrouves.Add(mot);
            }
        }

        public string toString()//Renvoie le score du joueur 
        {
            return "Le score de " + this.nom + "est de " + this.score + "grâce aux mots trouvés suivant :\n " + AfficheList(this.MotsTrouves);
        }
        public string  AfficheList(List<string> ListeMots)
        {
            string resul = "";
            foreach(string mot in ListeMots)
            {
                resul += mot + " ";
            }
            return resul;
        }
    }
}   
