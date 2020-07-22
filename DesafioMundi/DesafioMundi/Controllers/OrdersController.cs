﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMundi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MundiAPI.PCL;
using MundiAPI.PCL.Models;

namespace DesafioMundi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "esta funcionando";
        }

        [HttpPost("{customerId}/{cardId}")]
        public ActionResult<GetChargeResponse> CreateOrder(string customerId, string cardId, [FromBody] Item item)
        {
            string _basicAuthUserName = "sk_test_alLk7EFV2iJ0dm9w";
            string _basicAuthPassword = "";
            var client = new MundiAPIClient(_basicAuthUserName, _basicAuthPassword);

            var items = new List<CreateOrderItemRequest>();
           
                items.Add(new CreateOrderItemRequest
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    Quantity = item.Quantity
                });

            var payment = new CreatePaymentRequest
            {
                PaymentMethod = "credit_card",
                CreditCard = new CreateCreditCardPaymentRequest
                {
                    CardId = cardId,
                    Card = new CreateCardRequest
                    {
                        Cvv = "323"
                    }
                }
            };

         
            var request = new CreateChargeRequest()
            {
                Amount = item.Amount,
                Payment = payment,
                CustomerId = customerId

            };

            var response = client.Charges.CreateCharge(request);
            return response;
        }
       
    }
}