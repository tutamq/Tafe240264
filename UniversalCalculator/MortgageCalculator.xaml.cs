using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		// Calculate Botton Click Event
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principleBorrowAmount;
			int years;
			int months;
			int totalMonths;
			double yearlyInterestRate;
			double monthlyInterestRate;
			double monthlyRepaymentAmount;

			// Check valid Principal Borrow Amount
			try
			{
				principleBorrowAmount = double.Parse(pricipalBorrowAmountTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter valid Principal Borrow Amount. " + ex.Message);
				await dialogMessage.ShowAsync();
				pricipalBorrowAmountTextBox.Focus(FocusState.Programmatic);
				return;
			}
			// Check valid Years Text Box
			try
			{
				years = int.Parse(yearsBorrowTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter valid Years. " + ex.Message);
				await dialogMessage.ShowAsync();
				yearsBorrowTextBox.Focus(FocusState.Programmatic);
				return;
			}
			// Check valid Months Text Box
			try
			{
				months = int.Parse(monthsBorrowTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter valid Months. " + ex.Message);
				await dialogMessage.ShowAsync();
				monthsBorrowTextBox.Focus(FocusState.Programmatic);
				return;
			}
			// Check if Yearly Interest Rate Text Box and Monthly Interest Rate Text Box both empty
			if (string.IsNullOrWhiteSpace(yearlyInterestRateTextBox.Text))
			{
				if (string.IsNullOrWhiteSpace(monthlyInterestRateTextBox.Text))
				{
					var dialogMessage = new MessageDialog("Error! Yearly and Monthly interest rate cannot be both blank. Please enter one.");
					await dialogMessage.ShowAsync();
					yearlyInterestRateTextBox.Focus(FocusState.Programmatic);
					return;
				}
				else
				{
					monthlyInterestRate = double.Parse(monthlyInterestRateTextBox.Text) / 100;
					yearlyInterestRate = monthlyInterestRate * 12;
					yearlyInterestRateTextBox.Text = yearlyInterestRate.ToString("P");
				}
			}
			else
			{
				yearlyInterestRate = double.Parse(yearlyInterestRateTextBox.Text) / 100;
				monthlyInterestRate = yearlyInterestRate / 12;
				monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("P");
			}

			// Calculate Monthly Repayment Amount
			totalMonths = years * 12 + months;
			monthlyRepaymentAmount = principleBorrowAmount * ((monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), totalMonths)) / (Math.Pow((1 + monthlyInterestRate), totalMonths) - 1));

			monthlyRepaymentAmountTextBox.Text = monthlyRepaymentAmount.ToString("C");
		}
	}
}
