namespace Model
{
    public interface IPerson
    {
        string strGuid { get; set; }
        string City { get; set; }
        string Name { get; set; }
        int PostalCode { get; set; }
        string Street { get; set; }
    }
}
