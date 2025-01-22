namespace Blog.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            if (!IsValid(address))
                throw new ArgumentException("Invalid email address.");

            Address = address;
        }

        private bool IsValid(string address) =>
            !string.IsNullOrWhiteSpace(address) && address.Contains("@");
    }
}