﻿using Models;
using Data;
using Mappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BookingService : IBookingService
    {
        private IUnitOfWork unitOfWork;
        private IProductInShopService productInShopService;
        private IMapper<Booking, BookingEntity> bookingMapper;
        public BookingService(IProductInShopService productInShopService, IUnitOfWork unitOfWork, IMapper<Booking, BookingEntity> bookingMapper)
        {
            this.productInShopService = productInShopService;
            this.unitOfWork = unitOfWork;
            this.bookingMapper = bookingMapper;
        }

        public void MakeBooking(User user, ProductInShop productInShop, DateTime startDate, DateTime endDate)
        {
            productInShop.Product = null;
            Booking booking = new Booking { UserId = user.Id, ProductInShop = productInShop, StartDate = startDate, EndDate = endDate };
            unitOfWork.BookingRepository.Create(bookingMapper.ToEntity(booking));
            productInShopService.DecreaseQuantity(productInShop);
            unitOfWork.Save();
        }
    }
}
