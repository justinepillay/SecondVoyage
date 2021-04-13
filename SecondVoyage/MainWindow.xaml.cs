using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecondVoyage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        ListHolder obj = ListHolder.getInstance();
        public MainWindow()
        {
            InitializeComponent();

            //sets the list in the singlton if the list is at 0
            if (obj.getList().Count <= 0)
            {
                obj.addVroom("Fancy Vrooms", "super fancy", 50000, "red", 0, 50);
                obj.addVroom("Fancy Vrooms", "super fancy", 50000, "black", 0, 30);
                obj.addVroom("Fancy Vrooms", "medium fancy", 50000, "blue", 0, 45);

            }
            cmbVrooms.ItemsSource = obj.getList();
            cmbVrooms.SelectedIndex = 0;
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
           
            //calls the method in the singleton to return a list of the Vroom objects which get assigned to the combo box
            cmbVrooms.ItemsSource = obj.getList();
            obj.getReportAll();
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {

                //reads in the information from the text boxes and calls the method in the singleton to add a new vroom object
                String make = txfMake.Text;
                String model = txfModel.Text;
                String color = txfColor.Text;
                double price = Convert.ToDouble(txfPrice.Text);
                int qty = Convert.ToInt32(txfQty.Text);


                obj.addVroom(make, model, price, color, 0, qty);
                MessageBoxResult result = MessageBox.Show("Done");
                cmbVrooms.ItemsSource = obj.getList();
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

         
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {

            //gets the index from the combo box and calls method to substract from the quantity of the chosen object
            int index = cmbVrooms.SelectedIndex;
            Vroom details = obj.getVroomDetails(index);

            obj.sellVroom(details.make, details.model, details.color);

            MessageBoxResult result = MessageBox.Show("Done");
        }


        private void cmbVrooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            //calls method from singleton with the details of the selected car
            int index = cmbVrooms.SelectedIndex;
            String getDetails = obj.getDetails(index);

            txbDetails.Text = getDetails;



        }


    }
}
