namespace mvc_js.Models
{
    public class Customer
    {
        public string Id { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public Customer(string fname, string lname)
        {
            Id = Guid.NewGuid().ToString();
            Fname = fname;
            Lname = lname;
        }
    }
}
