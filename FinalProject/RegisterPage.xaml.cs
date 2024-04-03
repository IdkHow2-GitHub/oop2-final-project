namespace FinalProject
{
    public partial class RegisterPage
    {
        bool is_valid_user = true;

        public RegisterPage()
        {
            InitializeComponent();
        }
        public void OnRegisterBookButton(object sender, EventArgs e)
        {
            if (is_valid_user == true)
            {
                //obviously this needs to have the appropriate code
                registerPage_registerBookButton.Text = "Successfully Registered!";
            }
            else
            {
                registerPage_registerBookButton.Text = "You must be signed in first!";
            }

        }
        public void OnClearEntriesButton(object sender, EventArgs e)
        {
            if (is_valid_user == true) 
            {
                registerPage_book_idDesc.Text = string.Empty;
                registerPage_book_titleDesc.Text = string.Empty;
                registerPage_book_authorDesc.Text = string.Empty;
                registerPage_book_genreDesc.Text = string.Empty;
                registerPage_book_publishDateDesc.Text = string.Empty;
                registerPage_book_quantityDesc.Text = string.Empty;
            }
            else
            {
                registerPage_clearEntriesButton.Text = "You must be signed in first!";
            }

        }
    }

}
