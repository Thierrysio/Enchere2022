using System;
using System.Collections.Generic;
using System.Text;

namespace Enchere2022.Modeles
{
    class Encherir
    {
        #region Attributs
        private int _id;

        private int _idUser;
        private int _idEnchere;
        private float _prixEnchere;
        private string _pseudo;
        public static List<Encherir> CollClasse = new List<Encherir>();


        #endregion

        #region Constructeurs

        public Encherir(float prixenchere, int idUser, int idEnchere, int id, string pseudo)
        {
            Encherir.CollClasse.Add(this);
            PrixEnchere = prixenchere;
            IdUser = idUser;
            IdEnchere = idEnchere;
            Id = id;
            Pseudo = pseudo;
        }

        #endregion

        #region Getters/Setters
        public float PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public int Id { get => _id; set => _id = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
