using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public class Materiel_Depot_DAL : Depot_DAL<Materiel_DAL>
    {
        public override void Delete(Materiel_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Materiel]
     WHERE
           (id = @id);

";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }
        public override Materiel_DAL Update(Materiel_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"
UPDATE [dbo].[Materiel]([utilisationMax] = @utilisationMax
           ,[dateExpiration] = @dateExpiration
           ,[dateControle] = @dateControle
            ,[estStocke] = @estStocke
            ,[stock] = @stock
            ,[denomination] = @denomination
            ,[estActive ] = @estActive
            ,[utilisation] = @utilisation
            ,[categorie] = @categorie
     WHERE
           (id = @id);
";
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.Parameters.Add(new SqlParameter("@utilisationMax", p.UtilisationMax));
            Commande.Parameters.Add(new SqlParameter("@dateExpiration", p.DateExpiration));
            Commande.Parameters.Add(new SqlParameter("@dateControle", p.DateControle));
            Commande.Parameters.Add(new SqlParameter("@estStocke", p.EstStocke));
            Commande.Parameters.Add(new SqlParameter("@stock", p.Stock));
            Commande.Parameters.Add(new SqlParameter("@denomination", p.Denomination));
            Commande.Parameters.Add(new SqlParameter("@estActive", p.EstActive));
            Commande.Parameters.Add(new SqlParameter("@utilisation", p.Utilisation));
            Commande.Parameters.Add(new SqlParameter("@categorie", p.Categorie));

            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
        public override Materiel_DAL? GetById(int id)
        {
            InitialiserLaConnexionEtLaCommande();


            Commande.CommandText = @"SELECT [id]
                                      ,[utilisationMax]
                                      ,[dateExpiration]
                                      ,[dateControle]
                                      ,[estStocke]
                                      ,[stock]
                                      ,[denomination]
                                      ,[estActive]
                                      ,[utilisation]
                                      ,[categorie]
                                    FROM [dbo].[Materiel]
                                     WHERE id=@id";

            Commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = Commande.ExecuteReader();

            Materiel_DAL p = null;
            if (reader.Read()) // j'ai trouvé une ligne
            {
                p = new Materiel_DAL(
                    reader.GetInt32(0), //id
                    reader.GetSqlInt32(1).IsNull ? null : reader.GetInt32(1), //Utilisation
                    reader[2]==DBNull.Value ? null : reader.GetDateTime(2), //DateControle
                    reader[3] == DBNull.Value ? null : reader.GetDateTime(3), //DateControle
                    reader.GetBoolean(4), //EstStocke
                    reader.GetString(5), //Stock
                    reader.GetString(6), //Denomination
                    reader.GetBoolean(7), //EstActive
                    reader.GetInt32(8), //Utilisation
                    reader.GetString(9)); //Categorie
            }

            FermerEtDisposerLaConnexionEtLaCommande();
            return p;
        }
        public override Materiel_DAL Insert(Materiel_DAL p)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[Materiel](id, utilisationMax, dateExpiration, dateControle, estStocke, stock, denomination, estActive, utilisation, categorie) " +
                   "VALUES (@id, @utilisationMax, @dateExpiration, @dateControle, @estStocke, @stock, @denomination, @estActive, @utilisation, @categorie);"; ;
            Commande.Parameters.Add(new SqlParameter("@id", p.Id));
            Commande.Parameters.Add(new SqlParameter("@utilisationMax", p.UtilisationMax??(object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@dateExpiration", p.DateExpiration ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@dateControle", p.DateControle ?? (object)DBNull.Value));
            Commande.Parameters.Add(new SqlParameter("@estStocke", p.EstStocke));
            Commande.Parameters.Add(new SqlParameter("@stock", p.Stock));
            Commande.Parameters.Add(new SqlParameter("@denomination", p.Denomination));
            Commande.Parameters.Add(new SqlParameter("@estActive", p.EstActive));
            Commande.Parameters.Add(new SqlParameter("@utilisation", p.Utilisation));
            Commande.Parameters.Add(new SqlParameter("@categorie", p.Categorie));


            Commande.ExecuteNonQuery();
            FermerEtDisposerLaConnexionEtLaCommande();

            return p;
        }
        public override IEnumerable<Materiel_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"SELECT * FROM [dbo].[Materiel] WHERE id=@id";

            var reader = Commande.ExecuteReader();

            var liste = new List<Materiel_DAL>();

            while (reader.Read())

            {
                liste.Add(new Materiel_DAL(
                    reader.GetInt32(0), //id
                    reader.GetSqlInt32(1).IsNull ? null : reader.GetInt32(1), //Utilisation
                    reader.GetSqlDateTime(3).IsNull ? null : reader.GetDateTime(3), //DateControle
                    reader.GetSqlDateTime(4).IsNull ? null : reader.GetDateTime(3), //DateControle
                    reader.GetBoolean(5), //EstStocke
                    reader.GetString(6), //Stock
                    reader.GetString(7), //Denomination
                    reader.GetBoolean(8), //EstActive
                    reader.GetInt32(9), //Utilisation
                    reader.GetString(10))); //Categorie
            }
            FermerEtDisposerLaConnexionEtLaCommande();
            return liste;
        }
    }
}

