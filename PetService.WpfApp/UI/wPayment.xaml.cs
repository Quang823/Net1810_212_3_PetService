using PetService.Business;
using PetService.Data.Models;
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
using System.Windows.Shapes;

namespace PetService.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wPet.xaml
    /// </summary>
    public partial class wPayment : Window
    {
        //        public wPet()
        //       {
        //            InitializeComponent();
        //        }

        private readonly PaymentBusiness _business;

        public wPayment()
        {
            InitializeComponent();
            this._business = new PaymentBusiness();
            this.LoadGrdPayment();
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _business.GetById(int.Parse(PaymentId.Text));

                if (item.Data == null)
                {
                    var payment = new Payment()
                    {
                        AppointmentId = int.Parse(AppoinntmentId.Text),
                        PaymentMethod = PaymentMethod.Text,
                        TotalPrice = decimal.Parse(TotalPrice.Text)
                        
                    };

                    var result = await _business.Save(payment);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var payment = item.Data as Payment;
                    payment.AppointmentId = int.Parse(AppoinntmentId.Text);
                    payment.PaymentMethod = PaymentMethod.Text;
                    payment.TotalPrice = decimal.Parse(TotalPrice.Text);
                  

                    var result = await _business.Update(payment);
                    MessageBox.Show(result.Message, "Save");
                }

                PaymentId.Text = string.Empty;
                AppoinntmentId.Text = string.Empty;
                PaymentMethod.Text = string.Empty;
                TotalPrice.Text = string.Empty;
                
                this.LoadGrdPayment();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

        }

        private async void grdPayment_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            string paymentId = btn.CommandParameter.ToString();

            //MessageBox.Show(petId);

            if (!string.IsNullOrEmpty(paymentId))
            {
                if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var result = await _business.DeleteById(int.Parse(paymentId));
                    MessageBox.Show($"{result.Message}", "Delete");
                    this.LoadGrdPayment();
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            PaymentId.Text = string.Empty;
            AppoinntmentId.Text = string.Empty;
            PaymentMethod.Text = string.Empty;
            TotalPrice.Text = string.Empty;

            this.LoadGrdPayment();
        }

        private async void grdPayment_ButtonSelect_Click(object obj, RoutedEventArgs e)
        {
            Button btn = (Button)obj;

            string paymentID = btn.CommandParameter.ToString();

            //MessageBox.Show(PetId);

            if (!string.IsNullOrEmpty(paymentID))
            {
                var PaymentResult = await _business.GetById(int.Parse(paymentID));

                if (PaymentResult.Status > 0 && PaymentResult.Data != null)
                {
                    var item = PaymentResult.Data as Payment;
                    PaymentId.Text = item.PaymentId.ToString();
                    AppoinntmentId.Text = item.AppointmentId.ToString();
                    PaymentMethod.Text = item.PaymentMethod.ToString();
                    TotalPrice.Text = item.TotalPrice.ToString();

                }
            }
        }

        private async void LoadGrdPayment()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdPayment.ItemsSource = result.Data as List<Payment>;
            }
            else
            {
                grdPayment.ItemsSource = new List<Payment>();
            }
        }

        private void PetId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
