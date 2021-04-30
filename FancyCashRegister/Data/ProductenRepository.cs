using FancyCashRegister.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Date;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FancyCashRegister.Data
{
    public class ProductenRepository : BaseDbRepository
    {
        protected const string VELD_CATEGORIE_CATEGORIE_ID = "categorie_id";
        protected const string VELD_CATEGORIE_NAAM = "naam";
        protected const string VELD_CATEGORIE_BESCHRIJVING = "beschrijving";
        protected const string VELD_CATEGORIE_IS_ACTIEF = "is_actief";
        
        protected const string VELD_PRODUCT_PRODUCT_ID = "product_id";
        protected const string VELD_PRODUCT_CATEGORIE_ID = "categorie_id";
        protected const string VELD_PRODUCT_NAAM = "naam";
        protected const string VELD_PRODUCT_BESCHRIJVING = "beschrijving";
        protected const string VELD_PRODUCT_STUKSPRIJS = "stuksprijs";
        protected const string VELD_PRODUCT_IS_ACTIEF = "is_actief";


        public ProductenRepository() : base()
        {
        }

        ~ProductenRepository()
        {
        }

        protected DataTable CategorieenTable
        {
            get
            {
                var qry = $@"
select 
    {VELD_CATEGORIE_CATEGORIE_ID},
    {VELD_CATEGORIE_NAAM},
    {VELD_CATEGORIE_BESCHRIJVING},
    {VELD_CATEGORIE_IS_ACTIEF}
from product_categorieen
order by {VELD_CATEGORIE_CATEGORIE_ID};";

                return GetDataTableForQuery(qry);
            }
        }

        public IEnumerable<ProductCategorie> Categorieen => CategorieenTable.AsEnumerable()
            .Select(r => new ProductCategorie
            {
                Id = r.Field<int>(VELD_CATEGORIE_CATEGORIE_ID),
                Naam = r.Field<string>(VELD_CATEGORIE_NAAM),
                Beschrijving = r.Field<string>(VELD_CATEGORIE_BESCHRIJVING),
                IsActief = r.Field<bool>(VELD_CATEGORIE_IS_ACTIEF),
            });


        private DataTable ProductenTable
        {
            get
            {
                var qry = $@"
select 
    {VELD_PRODUCT_PRODUCT_ID}, 
    {VELD_PRODUCT_CATEGORIE_ID},
    {VELD_PRODUCT_NAAM}, 
    {VELD_PRODUCT_BESCHRIJVING}, 
    {VELD_PRODUCT_STUKSPRIJS},
    {VELD_PRODUCT_IS_ACTIEF}
from producten
order by {VELD_PRODUCT_PRODUCT_ID};";

                return GetDataTableForQuery(qry);
            }
        }

        public IEnumerable<Product> Producten => ProductenTable.AsEnumerable()
            .Select(p => new Product 
            { 
                Id = p.Field<int>(VELD_PRODUCT_PRODUCT_ID),
                CategorieId = p.Field<int>(VELD_PRODUCT_CATEGORIE_ID),
                Categorie = Categorieen.Where(c => c.Id == p.Field<int>(VELD_PRODUCT_CATEGORIE_ID)).FirstOrDefault(),
                Naam = p.Field<string>(VELD_PRODUCT_NAAM),
                Beschrijving = p.Field<string>(VELD_PRODUCT_BESCHRIJVING),
                Stuksprijs = p.Field<decimal>(VELD_PRODUCT_STUKSPRIJS),
                IsActief = p.Field<bool>(VELD_PRODUCT_IS_ACTIEF)
            });

        public DataTable GetProductenTableByCategory(int categoryId)
        {
            var paramCategorieId = "@categorieId";
            var qry = $@"
select 
    {VELD_PRODUCT_PRODUCT_ID}, 
    {VELD_PRODUCT_CATEGORIE_ID},
    {VELD_PRODUCT_NAAM}, 
    {VELD_PRODUCT_BESCHRIJVING}, 
    {VELD_PRODUCT_STUKSPRIJS},
    {VELD_PRODUCT_IS_ACTIEF}
from producten
where {VELD_PRODUCT_CATEGORIE_ID} = {paramCategorieId} or {paramCategorieId} = 0
order by {VELD_PRODUCT_PRODUCT_ID};";

            return GetDataTableForQuery(qry, new MySqlParameter(paramCategorieId, categoryId));
        }

        public Product ProductToevoegen(Product toeTeVoegenProduct)
        {
            var paramProductId = "@productId";
            var paramCategorieId = "@categorieId";
            var paramNaam = "@naam";
            var paramBeschrijving = "@beschrijving";
            var paramStuksprijs = "@stuksprijs";
            var paramIsActief = "@isActief";

            var qry = $@"
insert into producten(
    {VELD_PRODUCT_CATEGORIE_ID}, 
    {VELD_PRODUCT_NAAM}, 
    {VELD_PRODUCT_BESCHRIJVING}, 
    {VELD_PRODUCT_STUKSPRIJS}, 
    {VELD_PRODUCT_IS_ACTIEF}
)
values(
    {paramCategorieId}, 
    {paramNaam}, 
    {paramBeschrijving}, 
    {paramStuksprijs}, 
    {paramIsActief}
)";
            var parameters = new[] {
                new MySqlParameter(paramCategorieId, toeTeVoegenProduct.Categorie.Id),
                new MySqlParameter(paramNaam, toeTeVoegenProduct.Naam),
                new MySqlParameter(paramBeschrijving, toeTeVoegenProduct.Beschrijving),
                new MySqlParameter(paramStuksprijs, toeTeVoegenProduct.Stuksprijs),
                new MySqlParameter(paramIsActief, toeTeVoegenProduct.IsActief),
            };
            var res = InsertQuery(qry, parameters);
            toeTeVoegenProduct.Id = res.insertedId;

            return toeTeVoegenProduct;
        }

        public Product ProductBewerken(Product teBewerkenProduct)
        {
            var paramProductId = "@productId";
            var paramCategorieId = "@categorieId";
            var paramNaam = "@naam";
            var paramBeschrijving = "@beschrijving";
            var paramStuksprijs = "@stuksprijs";
            var paramIsActief = "@isActief";
            var qry = $@"
update producten
set 
    {VELD_PRODUCT_CATEGORIE_ID} = {paramCategorieId}, 
    {VELD_PRODUCT_NAAM} = {paramNaam}, 
    {VELD_PRODUCT_BESCHRIJVING} = {paramBeschrijving}, 
    {VELD_PRODUCT_STUKSPRIJS} = {paramStuksprijs}, 
    {VELD_PRODUCT_IS_ACTIEF} = {paramIsActief}
where {VELD_PRODUCT_PRODUCT_ID} = {paramProductId}
";
            var parameters = new[] {
                new MySqlParameter(paramCategorieId, teBewerkenProduct.Categorie.Id),
                new MySqlParameter(paramNaam, teBewerkenProduct.Naam),
                new MySqlParameter(paramBeschrijving, teBewerkenProduct.Beschrijving),
                new MySqlParameter(paramStuksprijs, teBewerkenProduct.Stuksprijs),
                new MySqlParameter(paramIsActief, teBewerkenProduct.IsActief),
            };

            var res = UpdateQuery(qry, parameters);

            return teBewerkenProduct;
        }

    }
}
