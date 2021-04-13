using System;
using System.Collections.Generic;
using System.Text;

namespace SecondVoyage
{
    public class Vroom
    {

        //object class of Vrooms


        public String make { get; set; }
        public String model { get; set; }
        public double price { get; set; }
        public String color { get; set; }
        public double sales { get; set; }
        public int qty { get; set; }


        public Vroom(String inMake, String inModel, double inPrice, String inColor, double inSales, int inQty)
        {

            this.make = inMake;
            this.model = inModel;
            this.color = inColor;
            this.price = inPrice;
            this.sales = inSales;
            this.qty = inQty;

        }



    }
}
