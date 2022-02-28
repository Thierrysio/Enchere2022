using System;
using System.Collections.Generic;
using System.Text;

namespace Enchere2022.Modeles
{
    class Produit
    {
        #region Attributs

        public static List<Produit> CollClasse = new List<Produit>();

        private int _id;
        private string _nom;

        #endregion

        #region Constructeurs



        public Produit(int id, string nom)
        {

            Id = id;
            Nom = nom;
            Produit.CollClasse.Add(this);

        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
