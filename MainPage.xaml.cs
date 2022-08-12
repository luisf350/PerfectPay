namespace PerfectPay;

public partial class MainPage : ContentPage
{
    double bill;
    int tip;
    int nroPersons = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    private void txtBill_Completed(object sender, EventArgs e)
    {
        double.TryParse(txtBill.Text, out bill);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        // Total Tip
        var totalTip = (bill * tip) / 100;

        // Tip by person
        var tipByPerson = totalTip / nroPersons;
        lblTipByPerson.Text = $"{tipByPerson:C}";

        // Subtotal
        var subTotal = bill / nroPersons;
        lblSubtotal.Text = $"{subTotal:C}";

        // Total
        var totByPerson = (bill + totalTip) / nroPersons;
        lblTotal.Text = $"{totByPerson:C}";
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Propina: {tip}%";
        CalculateTotal();
    }

    private void btnTip_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentaje = int.Parse(btn.Text.Replace("%", string.Empty));
            sldTip.Value = percentaje;
        }
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (nroPersons > 1)
        {
            nroPersons--;
        }
        lblPersons.Text = nroPersons.ToString();
        CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        nroPersons++;
        lblPersons.Text = nroPersons.ToString();
        CalculateTotal();
    }
}

