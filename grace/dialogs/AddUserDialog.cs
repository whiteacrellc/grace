namespace grace
{
    public partial class AddUserDialog : Form
    {
        public AddUserDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text.Trim();
            bool resetPassword = forcePasswordUpdateCheckBox.Checked;
            bool isAdmin = adminCheckBox.Checked;
            bool ok = AdminStuff.CreateUser(username, password,
                resetPassword, isAdmin);
            if (ok)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                usernameTextBox.Clear();
            }
        }
    }
}
