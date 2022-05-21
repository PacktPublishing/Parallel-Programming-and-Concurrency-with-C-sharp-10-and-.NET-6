namespace FdaNdcDrugLookup
{
    public partial class Form1 : Form
    {
        private DrugService _drugService = new();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            var t1 = Task.Run(() => _drugService.LoadData("product.txt"));
            var t2 = Task.Run(() => _drugService.LoadData("product2.txt"));

            await Task.WhenAll(t1, t2);
            btnLookup.Enabled = true;
            btnLoad.Enabled = false;
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNdc.Text))
            {
                var drug = _drugService.GetDrugByNdc(txtNdc.Text);
                txtDrugName.Text = drug.ProprietaryName;
            }
        }
    }
}