using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Vehicule_Depot_DAL : Depot_DAL<Vehicule_DAL>
    {
        public override void Delete(Vehicule_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Vehicule]
     WHERE
           (id = @id);
GO

";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }
        public override Vehicule_DAL Update(Vehicule_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Vehicule] set [immatriculation] = @immatriculation
           ,[denomination] = @denomination
           ,[numero] = @numero
           ,[estActive] = @estActive
     WHERE
           (id = @id);
";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.Parameters.Add(new SqlParameter("@immatriculation", p.Immatriculation));
            Commande.Parameters.Add(new SqlParameter("@denomination", p.Denomination));
            Commande.Parameters.Add(new SqlParameter("@numero", p.Numero));
            Commande.Parameters.Add(new SqlParameter("@estActive", p.EstActive));

            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
        public override Vehicule_DAL? GetById(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Vehicule]
                                     WHERE id=@id";


            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            Vehicule_DAL p = null;
            if (reader.Read()) // j'ai trouvé une ligne
            {
                p = new Vehicule_DAL(
                    reader.GetInt32(0), //id
                    reader.GetString(1), //Immatriculation
                    reader.GetString(2), //Denomination
                    reader.GetString(3), //Numero
                    reader.GetBoolean(4)); //EstActive
            }

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
        public override Vehicule_DAL Insert(Vehicule_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO Vehicule (immatriculation, denomination, numero, estActive) " +
                   "VALUES (@immatriculation, @denomination, @numero, @estActive); " +
                   "SELECT SCOPE_IDENTITY()";
            Commande.Parameters.Add(new SqlParameter("@immatriculation", p.Immatriculation));
            Commande.Parameters.Add(new SqlParameter("@denomination", p.Denomination));
            Commande.Parameters.Add(new SqlParameter("@numero", p.Numero));
            Commande.Parameters.Add(new SqlParameter("@estActive", p.EstActive));

            p.Id = Convert.ToInt32((decimal)Commande.ExecuteScalar());
            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
        public override IEnumerable<Vehicule_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"SELECT [id]
                                      ,[immatriculation]
                                      ,[denomination]
                                      ,[numero]
                                      ,[estActive]
                                    FROM [dbo].[Vehicule]";

            var reader = Commande.ExecuteReader();

            var liste = new List<Vehicule_DAL>();

            while (reader.Read())

            {
                liste.Add(new Vehicule_DAL(
                    reader.GetInt32(0), //id
                    reader.GetString(1), //Immatriculation
                    reader.GetString(2), //Denomination
                    reader.GetString(3), //Numero
                    reader.GetBoolean(4))); //EstActive
            }
            FermerEtDisposerLaConnexionEtLaCommande();
            return liste;
        }

        public override IEnumerable<Vehicule_DAL> GetAllById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
