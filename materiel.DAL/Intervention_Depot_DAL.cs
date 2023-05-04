using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    internal class Intervention_Depot_DAL : Depot_DAL<Intervention_DAL>
    {
        public override void Delete(Intervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"USE [Projet_BICE]
GO

DELETE FROM [dbo].[Intervention]
     WHERE
           (id = @id);
GO

";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }
        public override Intervention_DAL Update(Intervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"USE [Projet_BICE]
GO

UPDATE [dbo].[Intervention]([denomination] = @denomination
           ,[date] = @date
           ,[description] = @description
     WHERE
           (id = @id);
GO

";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.Parameters.Add(new SqlParameter("@description", p.Denomination));
            Commande.Parameters.Add(new SqlParameter("@date", p.Date));
            Commande.Parameters.Add(new SqlParameter("@id_forme", p.Description));

            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
        public override Intervention_DAL GetById(int id)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT *
                                    FROM [dbo].[Intervention]
                                     WHERE id=@id";


            var reader = Commande.ExecuteReader();

            Intervention_DAL p = null;
            if (reader.Read()) // j'ai trouvé une ligne
            {
                p = new Intervention_DAL(
                    reader.GetInt32(0), //id
                    reader.GetDateTime(1), //Date
                    reader.GetString(2), //Denomination
                    reader.GetSqlString(3).IsNull ? null : reader.GetString(3)); //Description
            }

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
        public override Intervention_DAL Insert(Intervention_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"USE [Intervention]
GO

INSERT INTO [dbo].[Intervention]
           ([id]
           ,[date]
           ,[denomination]
           ,[description])
     VALUES
           (@id
            ,@date
            ,@denomination
            ,@description
            ,null); select scope_identity();
GO

";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.Parameters.Add(new SqlParameter("@date", p.Date));
            Commande.Parameters.Add(new SqlParameter("@denomination", p.Denomination));
            Commande.Parameters.Add(new SqlParameter("@description", p.Description));

            p.Id = Convert.ToInt32((decimal)Commande.ExecuteScalar());
            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
        public override IEnumerable<Intervention_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"SELECT id,date,denomination,description FROM [dbo].[Intervention] WHERE id=@id";

            var reader = Commande.ExecuteReader();

            var liste = new List<Intervention_DAL>();

            while (reader.Read())

            {
                liste.Add(new Intervention_DAL(
                    reader.GetInt32(0), //id
                    reader.GetDateTime(1), //Date
                    reader.GetString(2), //Denomination
                    reader.GetSqlString(3).IsNull ? null : reader.GetString(3))); //Description
            }
            FermerEtDisposerLaConnexionEtLaCommande();
            return liste;
        }
    }
}
