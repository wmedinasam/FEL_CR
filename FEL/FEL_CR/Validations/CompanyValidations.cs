namespace FELCR.Views.Pages
{
    public class CompanyValidations : ObservableObject
    {
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                value = value.Replace(" ", ""); // Eliminar espacios en blanco
            }
        }
    }
}
