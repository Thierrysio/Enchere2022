using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enchere2022.Modeles
{
    public class Enchere
    {
        #region Attributs
        public static List<Enchere> CollClasse = new List<Enchere>();
        private int _id;
        private DateTime _datedebut;
        private DateTime _datefin;
        private double _prixReserve;
        private double _prixDepart;
        //private double prix_enchere;
        //private ObservableCollection<Encherir> lesEncherirs;
        private TypeEnchere leTypeEnchere;
        private Produit leProduit;
        private string _tableauFlash;

        #endregion

        #region Constructeurs

        public Enchere(int id, DateTime datedebut, DateTime datefin, double prixReserve, TypeEnchere leTypeEnchere = null, Produit leProduit = null, double prixDepart = 0, string tableauFlash = null)
        {
            Enchere.CollClasse.Add(this);
            this._id = id;
            this._datedebut = datedebut;
            this._datefin = datefin;
            this._prixReserve = prixReserve;
            this.leTypeEnchere = leTypeEnchere;
            this.leProduit = leProduit;
            _prixDepart = prixDepart;
            _tableauFlash = tableauFlash;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; }
        public DateTime Datefin { get => _datefin; set => _datefin = value; }
        public double PrixReserve { get => _prixReserve; set => _prixReserve = value; }
        //public double Prix_enchere { get => prix_enchere; set => prix_enchere = value; }
        public TypeEnchere LeTypeEnchere { get => leTypeEnchere; set => leTypeEnchere = value; }
        public Produit LeProduit { get => leProduit; set => leProduit = value; }
        public double PrixDepart { get => _prixDepart; set => _prixDepart = value; }
        public string TableauFlash { get => _tableauFlash; set => _tableauFlash = value; }
        #endregion

        #region Methodes

        public void GenererTableauFlash()
        {
            
        }

        #endregion
    }
}
