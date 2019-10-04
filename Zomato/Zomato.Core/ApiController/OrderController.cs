using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public OrderController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("order")]
        public IActionResult AddOrder(OrderedData newOrder)
        {
            DateTime today = DateTime.Today;
            Order order = new Order();
            order.RestauratnId = newOrder.RestaurantId;
            order.UserId = newOrder.UserId;
            order.UserLocation = newOrder.UserLocation;
            order.OrderDate = today.ToString("dd-MM-yyyy");

            order = _unitOfWork.OrderRepository.AddOrder(order);

            for (int i = 0; i < newOrder.ItemDataCollection.Count; i++)
            {
                OrderedItem orderedItem = new OrderedItem();
                orderedItem.ItemId = newOrder.ItemDataCollection[i].ItemId;
                orderedItem.ItemQuantity = newOrder.ItemDataCollection[i].ItemQuantity;
                orderedItem.OrderId = order.OrderId;

                orderedItem = _unitOfWork.OrderedItemRepository.AddOrderedItem(orderedItem);
            }

            return Ok();
        }

        [HttpGet]
        [Route("order/{orderId}")]
        public async Task<OrderDetail> GetOrderDetail(int orderId)
        {
            string itemName = null;
            int itemPrice = 0;
            OrderDetail orderDetail = new OrderDetail();
            Order order = new Order();
            order = _unitOfWork.OrderRepository.GetOrderDataByOrderId(orderId);
            IdentityUser user = await _unitOfWork.UserRepository.GetUserDetail(order.UserId);
            List<OrderedItem> orderedItem = _unitOfWork.OrderedItemRepository.GetOrderedItemByOrderId(order.OrderId);


            for(int i = 0; i < orderedItem.Count; i++)
            {
                itemName = _unitOfWork.MenuRepository.GetMenuNameByItemId(orderedItem[i].ItemId);
                itemPrice = _unitOfWork.MenuRepository.GetItemPriceByItemId(orderedItem[i].ItemId);

                orderDetail.ItemDetail.Add(new ItemDetail(orderedItem[i].OrderId, itemName, orderedItem[i].ItemQuantity, itemPrice));
            }

            orderDetail.OrderId = order.OrderId;
            orderDetail.Date = order.OrderDate;
            orderDetail.RestaurantName = _unitOfWork.RestaurantRepository.GetRestaurantNameById(order.RestauratnId);
            orderDetail.UserName = user.UserName;
            orderDetail.UserNumber = user.PhoneNumber;
            orderDetail.UserEmail = user.Email;
            orderDetail.DeliveryLocation = order.UserLocation;

            return orderDetail;
        }
       
        [HttpGet]
        [Route("restaurant/{restaurantId}/order")]
        public List<Order> GetOrderList(int restaurantId)
        {
            return _unitOfWork.OrderRepository.GetOrderListByRestaurantId(restaurantId);
        }
    }
}
