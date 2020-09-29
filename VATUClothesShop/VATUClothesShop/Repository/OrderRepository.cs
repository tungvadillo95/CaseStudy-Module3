using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUClothesShop.Models;
using VATUClothesShop.ViewModels;

namespace VATUClothesShop.Repository
{
    public class OrderRepository : IOderRepository
    {
        private readonly VATUShopDbContext vATUShopDbContext;

        public OrderRepository(VATUShopDbContext vATUShopDbContext)
        {
            this.vATUShopDbContext = vATUShopDbContext;
        }

        public EditNormalOrderViewModel ConvertEditNormalOrderViewModel(OrderViewModel model)
        {
            var orderEdit = new EditNormalOrderViewModel()
            {
                OrderId = model.OrderId,
                DateCreated = model.DateCreated,
                DateShip = model.DateShip,
                Status = model.Status,
                PaymentRef = model.PaymentRef,
                IsNormalOrder = model.IsNormalOrder,
                IsDelete = model.IsDelete,
                ProductId = model.ProductId,
                NormalOrderCustomerName = model.NormalOrderCustomerName,
                NormalOrderPhone = model.NormalOrderPhone,
                NormalOrderAddress = model.NormalOrderAddress,
                Quantity = model.Quantity
            };
            return orderEdit;
        }

        public bool Delete(int Id)
        {
            var delOrder = vATUShopDbContext.Orders.Find(Id);
            if (delOrder != null)
            {
                delOrder.IsDelete = true;
                var result = vATUShopDbContext.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public int EditNormalOrder(OrderViewModel model)
        {
            var order = vATUShopDbContext.Orders.Find(model.OrderId);
            order.ProductId = model.ProductId;
            order.Quantity = model.Quantity;
            order.NormalOrderCustomerName = model.NormalOrderCustomerName;
            order.NormalOrderPhone = model.NormalOrderPhone;
            order.NormalOrderAddress = model.NormalOrderAddress;
            return vATUShopDbContext.SaveChanges();
        }

        public OrderViewModel GetOrder(int orderId)
        {
            var data = (from o in vATUShopDbContext.Orders
                        where o.OrderId == orderId
                        select new OrderViewModel()
                        {
                            OrderId = o.OrderId,
                            DateCreated = o.DateCreated,
                            AccountCustomerId = o.AccountCustomerId,
                            Status = o.Status,
                            PaymentRef = o.PaymentRef,
                            IsNormalOrder = o.IsNormalOrder,
                            ProductId = o.ProductId,
                            NormalOrderCustomerName = o.NormalOrderCustomerName,
                            NormalOrderPhone = o.NormalOrderPhone,
                            NormalOrderAddress = o.NormalOrderAddress,
                            Quantity = o.Quantity,
                            IsDelete = o.IsDelete
                        }).FirstOrDefault();
            return data;
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            IEnumerable<OrderViewModel> orders = new List<OrderViewModel>();
            orders = (from o in vATUShopDbContext.Orders
                      select (new OrderViewModel()
                      {
                          OrderId = o.OrderId,
                          DateCreated = o.DateCreated,
                          AccountCustomerId = o.AccountCustomerId,
                          Status = o.Status,
                          PaymentRef = o.PaymentRef,
                          IsNormalOrder = o.IsNormalOrder,
                          ProductId = o.ProductId,
                          NormalOrderCustomerName = o.NormalOrderCustomerName,
                          NormalOrderPhone = o.NormalOrderPhone,
                          NormalOrderAddress = o.NormalOrderAddress,
                          Quantity = o.Quantity,
                          IsDelete = o.IsDelete
                      }));
            return orders;
        }
    }
}
