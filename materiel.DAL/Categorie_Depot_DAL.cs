using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Categorie_Depot_DAL : Depot_DAL<Categorie_DAL>
    {
        public override void Delete(Categorie_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[categorie]
                                        WHERE (id = @id);
                                            ";

            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override IEnumerable<Categorie_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"SELECT [id]
                                      ,[nom]
                                    FROM [dbo].[categorie]";

            var reader = Commande.ExecuteReader();

            var liste = new List<Categorie_DAL>();

            while (reader.Read())

            {
                liste.Add(new Categorie_DAL(
                    reader.GetInt32(0), //id
                    reader.GetString(1))); //Nom

            }
            FermerEtDisposerLaConnexionEtLaCommande();
            return liste;
        }

        public override Categorie_DAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override Categorie_DAL Insert(Categorie_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO categorie (Nom) " +
                   "VALUES (@nom); " +
                   "SELECT SCOPE_IDENTITY()";
            Commande.Parameters.Add(new SqlParameter("@nom", p.Nom));

            p.Id = Convert.ToInt32((decimal)Commande.ExecuteScalar());
            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }

        public override Categorie_DAL Update(Categorie_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[categorie] set [nom] = @nom
                                                                    WHERE (id = @id);
                                                    ";

            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.Parameters.Add(new SqlParameter("@nom", p.Nom));

            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
    }
}
