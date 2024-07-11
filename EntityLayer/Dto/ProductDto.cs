using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Entities;

namespace EntityLayer.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Brand { get; set; }   

        public string Model { get; set; }   

        public int Price { get; set; }  

        public string  CategoryName { get; set; }
    }
}