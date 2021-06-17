using FancyCashRegister.Domain.Models;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCashRegister.Services.Data
{
    /// <summary>
    /// Deze repository gaat uit van onderstaande tabel definitie:
    /// 
    ///		drop table if exists orders;
    ///		create table orders(
    ///			order_id int primary key auto_increment,
    ///		    datum_aanmaak datetime not null
    ///		);
    ///		
    ///		drop table if exists order_product;
    ///		create table order_product(
    ///			order_id int not null,
    ///		    product_id int not null,
    ///		    aantal int,
    ///		    verkoopprijs decimal(14,2)
    ///		);
    ///		
    ///		alter table order_product
    ///			add constraint `fk_order` 
    ///				foreign key (order_id) references orders(order_id),
    ///		    add constraint `fk_product`
    ///				foreign key (product_id) references producten(product_id);
    /// </summary>
    public class OrderRepository : BaseDbRepository
    {
        public OrderRepository() : base()
        {
        }

        /**********************************************/
        public IEnumerable<Order> GetOrdersInPeriode(DateTimeOffset van, DateTimeOffset tot)
        {
            return GetOrdersTableInPeriode(van, tot)
                .AsEnumerable()
                .Select(o => new Order
                {
                    OrderId = o.Field<int>("order_id"),
                    DatumAanmaak = new DateTimeOffset(o.Field<DateTime>("datum_aanmaak")),
                    Producten = new BindingList<OrderProduct>(GetProductenInOrder(o.Field<int>("order_id")).ToList()),
                });
        }

        /// <summary>
        /// Deze methode doet hetzelfde als GetOrdersInPeriode hierboven maar maakt
        /// gebruik van loops ipv LINQ
        /// </summary>
        /// <param name="van"></param>
        /// <param name="tot"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrdersInPeriodeUitgeschreven(DateTimeOffset van, DateTimeOffset tot)
        {
            var gevondenOrders = new List<Order>();

            var ordersTable = GetOrdersTableInPeriode(van, tot);
            foreach (DataRow orderRow in ordersTable.Rows)
            {
                var order = new Order();
                order.OrderId = (int)orderRow["order_id"];
                var orderAanmaakDatum = (DateTime)orderRow["datum_aanmaak"];
                order.DatumAanmaak = new DateTimeOffset(orderAanmaakDatum);

                var productenInOrder = GetProductenInOrder(order.OrderId);
                order.Producten = new BindingList<OrderProduct>(productenInOrder.ToList());

                gevondenOrders.Add(order);
            }

            return gevondenOrders;
        }

        public IEnumerable<OrderProduct> GetProductenInOrder(int orderId)
        {
            return GetProductenInOrderTable(orderId).AsEnumerable().Select(p => new OrderProduct
            {
                OrderId = p.Field<int>("product_id"),
                Aantal = p.Field<int>("aantal"),
                Stuksprijs = p.Field<decimal>("verkoopprijs"),
            });
        }


        protected DataTable GetProductenInOrderTable(int orderId)
        {
            var paramOrderId = "@order_id";
            var qry = $@"select * from order_product where order_id = {paramOrderId}";

            return GetDataTableForQuery(qry, new MySqlParameter(paramOrderId, orderId));
        }

        protected DataTable GetOrdersTableInPeriode(DateTimeOffset van, DateTimeOffset tot)
        {
            var paramVan = "@van";
            var paramTot = "@tot";

            var qry = $@"select * from orders where datum_aanmaak > {paramVan} and datum_aanmaak < {paramTot}";
            // MySQL datetime gaat iets mis, waarschijnlijk icm de locale setting dus hier even expliciet formaat aangeven -->
            var parameters = new[] {
        new MySqlParameter(paramVan, $"{van:yyyy-MM-dd}"),
        new MySqlParameter(paramTot, $"{tot:yyyy-MM-dd}"),
    };

            return GetDataTableForQuery(qry, parameters);
        }



        /**********************************************/

        public IEnumerable<Order> Orders { get; set; }

        public Order AddOrder(Order order)
        {


            var paramDtAanmaak = "@dt_aanmaak";

            // eerst order aanmaken -->
            var qryInsertOrder = $@"insert into orders
            (datum_aanmaak)
            values({ paramDtAanmaak}); ";


            //var datumAanmaak = new MySqlDateTime(order.DatumAanmaak.DateTime);

            (var orderInsertSuccess, var newOrderId) = InsertQuery(
                qryInsertOrder,
                new MySqlParameter(paramDtAanmaak, order.DatumAanmaak.ToString("yyyy-MM-dd HH:mm:ss")));



            if (orderInsertSuccess)
            {
                // nieuw id toewijzen aan de order -->
                order.OrderId = newOrderId;

                // vervolgens de producten in de order aanmaken in de associative tabel -->
                var paramOrderId = "@order_id";
                var paramProductId = "@product_id";
                var paramAantalItems = "@aantal";
                var paramVerkoopprijs = "@verkoopprijs";
                var qryInsertOrderProducts = $@"insert into order_product
(order_id, product_id, Aantal, Verkoopprijs) 
values({paramOrderId}, {paramProductId}, {paramAantalItems}, {paramVerkoopprijs})";

                foreach (var productOrder in order.Producten)
                {
                    var parameters = new[]
                    {
                    new MySqlParameter(paramOrderId, order.OrderId),
                    new MySqlParameter(paramProductId, productOrder.OrderId),
                    new MySqlParameter(paramAantalItems, productOrder.Aantal),
                    new MySqlParameter(paramVerkoopprijs, productOrder.Stuksprijs),

                };
                    (var productOrderSuccess, _) = InsertQuery(qryInsertOrderProducts, parameters);
                    // TODO: wat te doen als order is aangemaakt maar producten in order geeft fout...
                    // (transactie start / commit / rollback)
                }
            }


            // pass by ref maar toch teruggeven zodat semantisch het plaatje klopt -->
            return order;
        }

        public bool UpdateOrder(Order order)
        {
            var paramOrderId = "@order_id";
            var paramDtAanmaak = "@dt_aanmaak";

            var qry = $@"update order set datum_aanmaak = {paramDtAanmaak} where order_id = {paramOrderId};";
            var parameters = new[] {
                new MySqlParameter(paramOrderId, order.OrderId),
                new MySqlParameter(paramDtAanmaak, order.DatumAanmaak)
            };
            var success = UpdateQuery(qry, parameters);

            return success;
        }

        public bool DeleteOrder(Order order)
        {
            var paramOrderId = "@order_id";
            var qry = $@"delete from orders where order_id = {paramOrderId};";

            var success = DeleteQuery(qry, new MySqlParameter(paramOrderId, order.OrderId));

            return success;
        }
    }
}
