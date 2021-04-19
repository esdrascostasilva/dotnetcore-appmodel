using DevDe.UI.AppModel.Data;
using DevDe.UI.AppModel.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDe.UI.AppModel.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IOrderRepository _orderRepository;

        //public HomeController(IOrderRepository orderRepository)
        //{
        //    _orderRepository = orderRepository;
        //}

        public OperationService OperationService { get; }
        public OperationService OperationService2 { get; set; }

        public HomeController(OperationService operationService, OperationService operationService2)
        {
            OperationService = operationService;
            OperationService2 = operationService2;
        }

        public string Index()
        {
            //var order = _orderRepository.GetOrder();

            return 
                "First Instance: " + Environment.NewLine +
                OperationService.Transient.OperationId + Environment.NewLine +
                OperationService.Scoped.OperationId + Environment.NewLine +
                OperationService.Singleton.OperationId + Environment.NewLine +
                OperationService.SingletonInstance.OperationId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Second Instance: " + Environment.NewLine +
                OperationService2.Transient.OperationId + Environment.NewLine +
                OperationService2.Scoped.OperationId + Environment.NewLine +
                OperationService2.Singleton.OperationId + Environment.NewLine +
                OperationService2.SingletonInstance.OperationId + Environment.NewLine;

        }
    }
}
