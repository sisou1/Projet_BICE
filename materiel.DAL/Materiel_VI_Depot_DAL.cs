using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Materiel_VI_Depot_DAL : Depot_DAL<Materiel_VI_DAL>
    {
        public override void Delete(Materiel_VI_DAL p)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Materiel_VI_DAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Materiel_VI_DAL> GetAllById(int id)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"SELECT
                                      [id_materiel]
                                      ,[id_vehicule_intervention]
                                      ,[etat]
                                    FROM [dbo].[materiel_vehiculeIntervention]
                                    WHERE id_vehicule_intervention = @id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            var liste = new List<Materiel_VI_DAL>();

            while (reader.Read())

            {
                liste.Add(new Materiel_VI_DAL(
                    reader.GetInt32(0), //id_materiel
                    reader.GetInt32(1), //id_vehicule_intervention
                    reader.GetString(2))); //etat
            }
            FermerEtDisposerLaConnexionEtLaCommande();
            return liste;
        }

        public override Materiel_VI_DAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override Materiel_VI_DAL Insert(Materiel_VI_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO materiel_vehiculeIntervention (id_materiel, id_vehicule_intervention, etat) " +
                   "VALUES (@id_materiel, @id_vehicule_intervention, @etat);  ";
            Commande.Parameters.Add(new SqlParameter("@id_materiel", p.Id_Materiel));
            Commande.Parameters.Add(new SqlParameter("@id_vehicule_intervention", p.Id_VehiculeIntervention));
            Commande.Parameters.Add(new SqlParameter("@etat", p.Etat));
            Commande.ExecuteNonQuery();
            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }

        public override Materiel_VI_DAL Update(Materiel_VI_DAL p)
        {
            throw new NotImplementedException();
        }
    }
}
