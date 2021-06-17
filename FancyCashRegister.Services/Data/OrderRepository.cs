using FancyCashRegister.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCashRegister.Services.Data
{
    public class OrderRepository : BaseDbRepository
    {
        protected const string VELD_ORDERS_ORDER_ID = "order_id";
        protected const string VELD_ORDERS_DATUM_AANMAAK = "datum_aanmaak";

        protected const string VELD_ORDER_PRODUCT_ORDER_ID = "order_id";
        protected const string VELD_ORDER_PRODUCT_PRODUCT_ID = "product_id";
        protected const string VELD_ORDER_PRODUCT_AANTAL = "Aantal";
        protected const string VELD_ORDER_PRODUCT_VERKOOPPRIJS = "Verkoopprijs";


        public OrderRepository() : base()
        {
        }


        public IEnumerable<Order> Orders => (IEnumerable<Order>)OrdersTable.AsEnumerable()
            .Select(r => new Order
            {
                OrderId = r.Field<int>(VELD_ORDERS_ORDER_ID),
                DatumAanmaak = r.Field<string>(VELD_ORDERS_DATUM_AANMAAK),
                
            });




        public IEnumerable<OrderProduct> OrderProducten => OrderProductenTable.AsEnumerable()
            .Select(p => new OrderProduct
            {
                OrderId = p.Field<int>(VELD_ORDER_PRODUCT_ORDER_ID),
                ProductId = p.Field<int>(VELD_ORDER_PRODUCT_PRODUCT_ID),
                Aantal = p.Field<int>(VELD_ORDER_PRODUCT_AANTAL),
                Verkoopprijs = p.Field<string>(VELD_ORDER_PRODUCT_VERKOOPPRIJS)
                
            });


        public Product ProductToevoegen(Product toeTeVoegenProduct)
        {
            //var paramProductId = "@productId";
            var paramOrderId = "@orderId";
            var paramDatumAanmaak = "@datumAanmaak";

            var qry = $@"
insert into orders(
    {VELD_ORDERS_ORDER_ID}, 
    {VELD_ORDERS_DATUM_AANMAAK}
)
values(
    {paramOrderId}, 
    {paramDatumAanmaak}
)";
            var parameters = new[] {
                new MySqlParameter(paramOrderId, toeTeVoegenProduct.Order.Id),
                new MySqlParameter(paramDatumAanmaak, toeTeVoegenProduct.Verkoopprijs),
            };
            var (success, insertedId) = InsertQuery(qry, parameters);
            if (success)
            {
                toeTeVoegenProduct.OrderId = insertedId;
                return toeTeVoegenProduct;
            }
            else
            {
                // TODO: null of simpelweg Id leeg laten? -->
                return null;
            }



        }

        public Product ProductBewerken(Product teBewerkenProduct)
        {
            var paramOrderId = "@orderId";
            var paramDatumAanmaak = "@datumAanmaak";

            var qry = $@"
update orders
set 
    {VELD_ORDERS_ORDER_ID} = {paramOrderId}, 
    {VELD_ORDERS_DATUM_AANMAAK} = {paramDatumAanmaak}
where {VELD_ORDERS_ORDER_ID} = {paramOrderId}
";
            var parameters = new[] {
                new MySqlParameter(paramOrderId, teBewerkenProduct.Order.Id),
                new MySqlParameter(paramDatumAanmaak, teBewerkenProduct.Verkoopprijs),
            };
            _ = UpdateQuery(qry, parameters);


            return teBewerkenProduct;
        }

        public Product ProductVerwijderen(Product teVerwijderenProduct)
        {
            var paramOrderId = "@orderId";
            var qry = $@"delete from orders
where {VELD_ORDERS_ORDER_ID} = {paramOrderId}
";

            var productIdParameter = new MySqlParameter(paramOrderId, teVerwijderenProduct.OrderId);

            DeleteQuery(qry, productIdParameter);

            return teVerwijderenProduct;
        }

        protected DataTable OrderProductenTable
        {
            get
            {
                var qry = $@"
select 
    {VELD_ORDER_PRODUCT_ORDER_ID},
    {VELD_ORDER_PRODUCT_PRODUCT_ID},
    {VELD_ORDER_PRODUCT_AANTAL},
    {VELD_ORDER_PRODUCT_VERKOOPPRIJS}
from order_product
order by {VELD_ORDER_PRODUCT_ORDER_ID};";

                return GetDataTableForQuery(qry);
            }
        }

        protected DataTable OrdersTable
        {
            get
            {
                var qry = $@"
select 
    {VELD_ORDERS_ORDER_ID}, 
    {VELD_ORDERS_DATUM_AANMAAK},
from orders
order by {VELD_ORDERS_ORDER_ID};";

                return GetDataTableForQuery(qry);
            }
        }

        protected DataTable GetProductenTableByProduct(int productId)
        {
            var paramProductId = "@productId";
            var qry = $@"
select 
    {VELD_ORDER_PRODUCT_ORDER_ID}, 
    {VELD_ORDER_PRODUCT_PRODUCT_ID},
    {VELD_ORDER_PRODUCT_AANTAL}, 
    {VELD_ORDER_PRODUCT_VERKOOPPRIJS}
from order_producten
where {VELD_ORDER_PRODUCT_PRODUCT_ID} = {paramProductId} or {paramProductId} = 0
order by {VELD_ORDER_PRODUCT_PRODUCT_ID};";

            return GetDataTableForQuery(qry, new MySqlParameter(paramProductId, productId));
        }



    }
}

