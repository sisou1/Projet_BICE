using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class VIntervention_Depot_DAL : Depot_DAL<VIntervention_DAL>
    {
        public override void Delete(VIntervention_DAL p)
        {
            throw new NotImplementedException();
        }
        public override VIntervention_DAL Update(VIntervention_DAL p)
        {
            throw new NotImplementedException();
        }
        public override VIntervention_DAL GetById(int id)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<VIntervention_DAL> GetAll()
        {
            throw new NotImplementedException();
        }
        public override VIntervention_DAL Insert(VIntervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO vehicule_intervention (id_vehicule, id_intervention) " +
                   "VALUES (@id_vehicule, @id_intervention); " +
                   "SELECT SCOPE_IDENTITY()";
            Commande.Parameters.Add(new SqlParameter("@id_vehicule", p.Id_Vehicule));
            Commande.Parameters.Add(new SqlParameter("@id_intervention", p.Id_Intervention));

            p.Id = Convert.ToInt32((decimal)Commande.ExecuteScalar());
            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
        public override IEnumerable<VIntervention_DAL> GetAllById(int id)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"SELECT [id]
                                      ,[id_vehicule]
                                      ,[id_intervention]
                                    FROM [dbo].[vehicule_intervention]
                                    WHERE id_intervention = id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            var liste = new List<VIntervention_DAL>();

            while (reader.Read())

            {
                liste.Add(new VIntervention_DAL(
                    reader.GetInt32(0), //id
                    reader.GetInt32(1), //id_vehicule
                    reader.GetInt32(2))); //id_intervention
            }
            FermerEtDisposerLaConnexionEtLaCommande();
            return liste;
        }
    }
}
