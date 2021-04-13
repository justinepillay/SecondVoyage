using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;

namespace SecondVoyage
{


    //Singlton to handle changes and requests from the list of Vrooms
    public sealed class ListHolder
    {

        private static readonly object padlock = new object();
        private static ListHolder instance;
        private List<Vroom> vrooms = new List<Vroom>();

        Logger logger = Logger.getInstance();

        private ListHolder()
        {

        }

        //ensures only one thread of the method that creates the instance to run
        public static ListHolder getInstance()
        {

          
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ListHolder();
                        }
                    }
                }
                return instance;
           
        }



        public void showMessage()
        {
            MessageBoxResult result = MessageBox.Show("Hello MessageBox");
        }


        //method to add a vroom
        public void addVroom(String inMake, String inModel, double inPrice, String inColor,double inSales,  int inQty)
        {

            Vroom newVroom = new Vroom(inMake, inModel, inPrice, inColor, inSales, inQty);
            vrooms.Add(newVroom);

            logger.logAdd(newVroom);

        }

        //decreases the quantity of the vroom by 1 when there is a sale
        public void sellVroom(String inMake, String inModel, String inColor)
        {

            Vroom old = getVroom( inMake,inModel, inColor);

            //updates the qty property of the vroom object to indicate that a vroom has been sold
            int qty = old.qty - 1;


            //takes the price that is  the cost price in the vroom object and then adds a markup to be added to the sales value
            double salesVal = old.sales + (old.price*1.5);

            Vroom newVroom = new Vroom(old.make, old.model, old.price,old.color, salesVal, qty);

            vrooms.Remove(old);
            vrooms.Add(newVroom);

            logger.logSale(newVroom);

        }

        //Gets the report of all the vrooms in the list
        public void getReportAll()
        {
            String report = "";

            report = "REPORT OF ALL VROOMS IN OUR LIST\n" +
                     "====================================\n\n";

            foreach (var vroom in vrooms)
            {
                report += String.Format(("{0,-10}, {1,-10} ({2}) \nTotal sales: R {3, 6}\nQty: {4,5}\n\n") ,vroom.make.ToString(), vroom.model,vroom.color.ToString(), vroom.sales, vroom.qty); 
            }

            report += "\n\n====================================";
            MessageBoxResult result = MessageBox.Show(report);

        }

        //gets the report of a specific vroom
        public String getSingleReport( String make, String model,String color)
        {
            String report = "";
            Vroom vroom = getVroom( make,model,color);
            report = String.Format(("{0,-10}, {1,-10}({2}) \nTotal sales: R {3, 10}\n {4,5}\n\n"), vroom.make.ToString(), vroom.model, vroom.color.ToString(), vroom.sales, vroom.qty);
            return report;

        }


        //gets the specific 'vroom' based on the model, make color
        public Vroom getVroom( String make, String model,String color)
        {
            Vroom old = vrooms.Where(v => v.model.Equals(model) && v.make.Equals(make)&& v.color.Equals(color)).First();
            return old;

        }

        public List<Vroom> getList()
        {
            return vrooms;
        }

        
        //gets the details of the vroom in the list at the specific index provided
        public String getDetails(int index)
        {
            String details = "";

            Vroom vroom = vrooms[index];
            details = "FULL DETAILS:\n"+vroom.make+"\n"+vroom.model+" ("+vroom.color+")\nPrice: R"+vroom.price;


                return details;
        }

        public Vroom getVroomDetails(int index)
        {

            Vroom details = vrooms[index];
           
            return details;
        }



    }



}
