﻿namespace ExpressDelivery.Domain
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActual { get; set; }
        public DateTime Ts { get; set; }
    }
}
