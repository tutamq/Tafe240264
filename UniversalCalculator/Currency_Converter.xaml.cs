using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class Currency_Converter : Page
	{
		public Currency_Converter()
		{
			this.InitializeComponent();
		}
		private void conversionButton_Click(object sender, RoutedEventArgs e)
		{
			const double USD_GPB = 0.72872436;
			const double USD_EUR = 0.85189982;
			const double USD_INR = 74.257327;
			const double EUR_GPB = 0.8556672;
			const double EUR_USD = 1.1739732;
			const double EUR_INR = 87.00755;
			const double GPB_USD = 1.371907;
			const double GPB_EUR = 1.1686692;
			const double GPB_INR = 101.68635;
			const double INR_GPB = 0.011492628;
			const double INR_EUR = 0.013492774;
			const double INR_USD = 0.0098339397;

			double convertAmount = double.Parse(amountTextBox.Text);
			double convertedAmount;
			string currencyIn = null;
			string currencyOut = null;
			double fromToRate = 0;
			double toFromRate = 0;

			if (fromConverterComboBox.SelectedIndex == 0)
			{
				currencyIn = " USD";
				if (toConverterComboBox.SelectedIndex == 0)
				{
					fromToRate = 1;
					toFromRate = 1;
				}
				if (toConverterComboBox.SelectedIndex == 1)
				{
					fromToRate = USD_GPB;
					toFromRate = GPB_USD;
				}
				if (toConverterComboBox.SelectedIndex == 2)
				{
					fromToRate = USD_EUR;
					toFromRate = EUR_USD;
				}
				if (toConverterComboBox.SelectedIndex == 3)
				{
					fromToRate = USD_INR;
					toFromRate = INR_USD;
				}
			}
			if (fromConverterComboBox.SelectedIndex == 1)
			{
				currencyIn = " GPB";
				if (toConverterComboBox.SelectedIndex == 0)
				{
					fromToRate = GPB_USD;
					toFromRate = USD_GPB;
				}
				if (toConverterComboBox.SelectedIndex == 1)
				{
					fromToRate = 1;
					toFromRate = 1;
				}
				if (toConverterComboBox.SelectedIndex == 2)
				{
					fromToRate = GPB_EUR;
					toFromRate = EUR_GPB;
				}
				if (toConverterComboBox.SelectedIndex == 3)
				{
					fromToRate = GPB_INR;
					toFromRate = INR_GPB;
				}
			}
			if (fromConverterComboBox.SelectedIndex == 2)
			{
				currencyIn = " EUR";
				if (toConverterComboBox.SelectedIndex == 0)
				{
					fromToRate = EUR_USD;
					toFromRate = USD_EUR;
				}
				if (toConverterComboBox.SelectedIndex == 1)
				{
					fromToRate = EUR_GPB;
					toFromRate = GPB_EUR;
				}
				if (toConverterComboBox.SelectedIndex == 2)
				{
					fromToRate = 1;
					toFromRate = 1;
				}
				if (toConverterComboBox.SelectedIndex == 3)
				{
					fromToRate = EUR_INR;
					toFromRate = INR_EUR;
				}
			}
			if (fromConverterComboBox.SelectedIndex == 3)
			{
				currencyIn = " INR";
				if (toConverterComboBox.SelectedIndex == 0)
				{
					fromToRate = INR_USD;
					toFromRate = USD_INR;
				}
				if (toConverterComboBox.SelectedIndex == 1)
				{
					fromToRate = INR_GPB;
					toFromRate = GPB_INR;
				}
				if (toConverterComboBox.SelectedIndex == 2)
				{
					fromToRate = INR_EUR;
					toFromRate = EUR_INR;
				}
				if (toConverterComboBox.SelectedIndex == 3)
				{
					fromToRate = 1;
					toFromRate = 1;
				}
			}
			if (toConverterComboBox.SelectedIndex == 0)
			{
				currencyOut = " USD";
			}
			if (toConverterComboBox.SelectedIndex == 1)
			{
				currencyOut = " GPB";
			}
			if (toConverterComboBox.SelectedIndex == 2)
			{
				currencyOut = " EUR";
			}
			if (toConverterComboBox.SelectedIndex == 3)
			{
				currencyOut = " INR";
			}

			convertedAmount = convertAmount * fromToRate;

			amountFromConverterTextBlock.Text = convertAmount + currencyIn + " =";
			amountToConverterTextBlock.Text = convertedAmount + currencyOut;
			fromCurrencyConverterTextBlock.Text = "1" + currencyIn + " = " + fromToRate + currencyOut;
			toCurrencyConverterTextBlock.Text = "1" + currencyOut + " = " + toFromRate + currencyIn;
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
