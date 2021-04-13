using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecondVoyage
{
    //singleton class to log any changes made to the object list
   public sealed class Logger
    {


        private static readonly object padlock = new object();
        private static Logger instance;


        private Logger()
        {

        }

        public static Logger getInstance()
        {


            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;

        }



        DateTime now = DateTime.Now;

        public void logAdd(Vroom vroom)
        {
            //method to record an addition to the list
            String entry = "";
           
            StreamWriter sw = new StreamWriter("Log_File.txt",true);
            entry ="ADD - "+ now.ToString() + " - Vroom added by (username): " + vroom.model + " - " + vroom.make + " ("+ vroom.color+")";
            sw.WriteLine(entry);
            sw.Close();

        }

        public void logSale(Vroom vroom)
        {

            //method to record the sale of the object
            String entry = "";

            StreamWriter sw = new StreamWriter("Log_File.txt",true);
            entry = "SALE - " + now.ToString() + " - Vroom sold by (username): " + vroom.model + " - " + vroom.make + " (" + vroom.color + ")";
            sw.WriteLine(entry);
            sw.Close();

        }





    }
}
