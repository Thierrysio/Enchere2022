using System;
using System.Collections.Generic;
using System.Text;

namespace Enchere2022.Modeles
{
    class Enchere
    {
        #region Attributs

        public static List<Enchere> CollClasse = new List<Enchere>();
        private int _id;
        private DateTime _datedebut;
        private DateTime _datefin;
        private float _prixreserve;
        private TypeEnchere _leTypeEnchere;

        #endregion

        #region Constructeurs

        public Enchere(int id, DateTime datedebut, DateTime datefin, float prixreserve, TypeEnchere letypeenchere)
        {
            _id = id;
            _datedebut = datedebut;
            _datefin = datefin;
            _prixreserve = prixreserve;

            Enchere.CollClasse.Add(this);
            LeTypeEnchere = letypeenchere;
        }



        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; }
        public DateTime Datefin { get => _datefin; set => _datefin = value; }
        public float Prixreserve { get => _prixreserve; set => _prixreserve = value; }
        internal TypeEnchere LeTypeEnchere { get => _leTypeEnchere; set => _leTypeEnchere = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
