namespace OrdersApiApp.Model.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Order> Orders{ get; set; }

        public Client() {
            FirstName = "";
            LastName = "";
        }
        public Client(int id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }

        public override string ToString()
        {
            return $"{Id}-{FirstName}-{LastName}";
        }
    }
}

    
