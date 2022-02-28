using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskRunWithWpf
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<Order> _orders = new();

        public MainViewModel()
        {
            LoadOrderDataCommand = new AsyncRelayCommand(LoadOrderDataAsync);
        }

        public ICommand LoadOrderDataCommand { get; set; }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                SetProperty(ref _orders, value);
            }
        }

        private async Task LoadOrderDataAsync()
        {
            Task<List<Order>> currentOrdersTask = Task.Run(GetCurrentOrders);
            Task<List<Order>> archivedOrdersTask = Task.Run(GetArchivedOrders);

            List<Order>[] results = await Task.WhenAll(new Task<List<Order>>[] {
                currentOrdersTask, archivedOrdersTask
            }).ConfigureAwait(false);

            ProcessOrders(results[0], results[1]);
        }

        private List<Order> GetCurrentOrders()
        {
            var orders = new List<Order>();

            Thread.Sleep(4000);

            orders.Add(new Order { OrderId = 55, CustomerName = "Tony", IsArchived = false });
            orders.Add(new Order { OrderId = 56, CustomerName = "Peggy", IsArchived = false });
            orders.Add(new Order { OrderId = 60, CustomerName = "Carol", IsArchived = false });
            orders.Add(new Order { OrderId = 62, CustomerName = "Bruce", IsArchived = false });

            return orders;
        }

        private List<Order> GetArchivedOrders()
        {
            var orders = new List<Order>();

            Thread.Sleep(5000);

            orders.Add(new Order { OrderId = 3, CustomerName = "Howard", IsArchived = true });
            orders.Add(new Order { OrderId = 18, CustomerName = "Steve", IsArchived = true });
            orders.Add(new Order { OrderId = 19, CustomerName = "Peter", IsArchived = true });
            orders.Add(new Order { OrderId = 21, CustomerName = "Mary", IsArchived = true });
            orders.Add(new Order { OrderId = 25, CustomerName = "Gwen", IsArchived = true });
            orders.Add(new Order { OrderId = 34, CustomerName = "Harry", IsArchived = true });
            orders.Add(new Order { OrderId = 36, CustomerName = "Bob", IsArchived = true });
            orders.Add(new Order { OrderId = 49, CustomerName = "Bob", IsArchived = true });

            return orders;
        }

        private void ProcessOrders(List<Order> currentOrders, List<Order> archivedOrders)
        {
            List<Order> allOrders = new(currentOrders);
            allOrders.AddRange(archivedOrders);
            Orders = new ObservableCollection<Order>(allOrders);
        }
    }
}
