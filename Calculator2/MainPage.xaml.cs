using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;

        private void BtnCommon_clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (Lbl.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                Lbl.Text = button.Text;
            }
            else
            {
                Lbl.Text += button.Text;
            }
        }



         private void clr_btn_Clicked(System.Object sender, System.EventArgs e)
        {
            Lbl.Text = "0";
            isOperatorClicked = false;
            firstNumber = 0;
        }
        // method below assigns all buttons at once to be displayed in the frame
        // we change the click event to BtnCommon_clicked for the buttons we wish to apply this too in xaml
        
        // this is a backspace button
        private void BtnX_Clicked(object sender, EventArgs e)
        {
            string number = Lbl.Text;
            if(number!= "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    Lbl.Text = "0";
                }
                else
                {
                    Lbl.Text = number;
                }
            }
        }

        private void BtnCommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(Lbl.Text);
        }

        private async void BtnPercentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = Lbl.Text;
                if(number!= "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    Lbl.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message,"OK");
            }
        }

        private void BtnEqual_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(Lbl.Text);
                string finalResult = Calculate(firstNumber,secondNumber).ToString("0.##");
                Lbl.Text = finalResult;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public decimal Calculate(decimal firstNumber,decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName== "+")
            {
                result= firstNumber + secondNumber;
            }
            else if (operatorName == "-")
            {
                result= firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result= firstNumber * secondNumber;
            }
            else if (operatorName == "/")
            {
                result= firstNumber / secondNumber;
            }
            return result;
        }

         
    }
}

