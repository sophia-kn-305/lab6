using System.Collections.Generic;
using System.Data.Entity;


namespace Lab06.App_Start
{
    public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {

        protected override void Seed(MyDbContext context)
        {
            context.Stores.Add(new Lab6.Models.Store { name = "Store1" });
            context.Stores.Add(new Lab6.Models.Store { name = "Store2" });
            context.Stores.Add(new Lab6.Models.Store { name = "Store3" });
            context.Stores.Add(new Lab6.Models.Store { name = "Store4" });
            context.Stores.Add(new Lab6.Models.Store { name = "Store5" });

            List<int> l1 = new List<int>();
            l1.Add(1);
            l1.Add(2);
            List<int> l2 = new List<int>();
            l1.Add(2);
            l1.Add(3);
            List<int> l3 = new List<int>();
            l1.Add(3);
            l1.Add(4);
            List<int> l4 = new List<int>();
            l1.Add(4);
            l1.Add(5);
            List<int> l5 = new List<int>();
            l1.Add(5);
            l1.Add(1);
            context.Carriers.Add(new Lab6.Models.Carrier { name = "carrier1", store_ids = new List<int>() });
            context.Carriers.Add(new Lab6.Models.Carrier { name = "carrier2", store_ids = l2 });
            context.Carriers.Add(new Lab6.Models.Carrier { name = "carrier3", store_ids = l3 });
            context.Carriers.Add(new Lab6.Models.Carrier { name = "carrier4", store_ids = l4 });
            context.Carriers.Add(new Lab6.Models.Carrier { name = "carrier5", store_ids = l5 });

            context.Deliveries.Add(new Delivery { id = 1, store_id = 1, carrier_id = 1 });
            context.Deliveries.Add(new Delivery { id = 2, store_id = 2, carrier_id = 2 });
            context.Deliveries.Add(new Delivery { id = 3, store_id = 3, carrier_id = 3 });
            context.Deliveries.Add(new Delivery { id = 4, store_id = 4, carrier_id = 4 });
            context.Deliveries.Add(new Delivery { id = 5, store_id = 5, carrier_id = 5 });

            context.Sellers.Add(new Lab6.Models.Seller { name = "seller1", rate = 1 });
            context.Sellers.Add(new Lab6.Models.Seller { name = "seller2", rate = 2 });
            context.Sellers.Add(new Lab6.Models.Seller { name = "seller3", rate = 3 });
            context.Sellers.Add(new Lab6.Models.Seller { name = "seller4", rate = 4 });
            context.Sellers.Add(new Lab6.Models.Seller { name = "seller5", rate = 5 });

        }

    }
}