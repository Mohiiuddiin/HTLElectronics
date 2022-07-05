using HTLElectronics.Models;
using HTLElectronics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTLElectronics.Interfaces
{
    public interface IOrderManager
    {
        void CreateOrder(Order order, List<BusketItemView> busketItems);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updatedOrder);

    }
}
