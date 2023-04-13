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
            throw new NotImplementedException();
        }
        public override Intervention_DAL GetById(int id)
        {
            throw new NotImplementedException();
        }
        public override Intervention_DAL Insert(Intervention_DAL p)
        {
            throw new NotImplementedException();
        }
    }
}
