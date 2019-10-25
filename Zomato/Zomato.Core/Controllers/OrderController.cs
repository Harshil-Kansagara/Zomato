using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> AddOrder(OrderedData newOrder)
        {
            DateTime today = DateTime.Today;
            Order order = new Order();
            order.RestauratnId = newOrder.RestaurantId;
            order.UserId = newOrder.UserId;
            order.UserAddressId = newOrder.UserAddressId;
            order.OrderDate = today.ToString("dd-MM-yyyy");

            order = await _unitOfWork.OrderRepository.AddOrder(order);

            for (int i = 0; i < newOrder.ItemDataCollection.Count; i++)
            {
                OrderedItem orderedItem = new OrderedItem();
                orderedItem.ItemId = newOrder.ItemDataCollection[i].ItemId;
                orderedItem.ItemQuantity = newOrder.ItemDataCollection[i].ItemQuantity;
                orderedItem.OrderId = order.OrderId;

                orderedItem = await _unitOfWork.OrderedItemRepository.AddOrderedItem(orderedItem);
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
            order = await _unitOfWork.OrderRepository.GetOrderDataByOrderId(orderId);
            IdentityUser user = await _unitOfWork.UserRepository.GetUserDetail(order.UserId);
            List<OrderedItem> orderedItem = await _unitOfWork.OrderedItemRepository.GetOrderedItemByOrderId(order.OrderId);


            for(int i = 0; i < orderedItem.Count; i++)
            {
                itemName = await _unitOfWork.MenuRepository.GetMenuNameByItemId(orderedItem[i].ItemId);
                itemPrice = await _unitOfWork.MenuRepository.GetItemPriceByItemId(orderedItem[i].ItemId);

                orderDetail.ItemDetail.Add(new ItemDetail(orderedItem[i].OrderId, itemName, orderedItem[i].ItemQuantity, itemPrice));
            }

            orderDetail.OrderId = order.OrderId;
            orderDetail.Date = order.OrderDate;
            orderDetail.RestaurantName = await _unitOfWork.RestaurantRepository.GetRestaurantNameById(order.RestauratnId);
            orderDetail.UserName = user.UserName;
            orderDetail.UserNumber = user.PhoneNumber;
            orderDetail.UserEmail = user.Email;
            //orderDetail.DeliveryLocation = order.UserAddressId;

            return orderDetail;
        }
       
        [HttpGet]
        [Route("restaurant/{restaurantId}/order")]
        public async Task<List<Order>> GetOrderList(int restaurantId)
        {
            return await _unitOfWork.OrderRepository.GetOrderListByRestaurantId(restaurantId);
        }
    }
}
