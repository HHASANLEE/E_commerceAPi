﻿namespace E_commerceAPi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public List<Product_Report> Product_Reports { get; set; }

    }
}