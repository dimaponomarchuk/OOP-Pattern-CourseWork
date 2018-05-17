﻿using System; using OOP_Course_Work.OrderType; using OOP_Course_Work.DeliveryType;  namespace OOP_Course_Work.PaymentCheker {     class SenderCheck : AbsSender     {         Sender sender = new Sender();         OrderSelector orderSelector = new OrderSelector();         IOrderType orderType;         DeliveryContext deliveryContext = new DeliveryContext();         public override void SendOrder(Client client, float weight, int amount, IDeliveryType delivery)         {             deliveryContext._weight = weight;             deliveryContext._amount = amount;             deliveryContext.SetDeliveryType(delivery);             orderType = orderSelector.Select(weight);             if (client.Pay(orderType.GetOrderSum(weight, deliveryContext.DelivetyCost)))             {                 sender.SendOrder(client, weight, amount, delivery);                 client.GetOrder();             }             else             {                 Console.WriteLine("Client is not payed for order");             }         }     } } 