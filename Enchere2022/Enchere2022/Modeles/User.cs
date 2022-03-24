using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enchere2022.Modeles
{
    class User
    {
        #region Attributs

        public static List<User> CollClasse = new List<User>();

        private int _id;
        private string _email;
        private string _password;
        private string _pseudo;
        private string _photo;

        #endregion

        #region Constructeurs

        public User(string email, string password, string pseudo, string photo, int id)
        {
            User.CollClasse.Add(this);
            _email = email;
            _password = password;
            _pseudo = pseudo;
            _photo = photo;
            Id = id;
        }

        #endregion

        #region Getters/Setters
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public int Id { get => _id; set => _id = value; }


        #endregion

        #region Methodes

        #endregion
    }
}
