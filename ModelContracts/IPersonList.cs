namespace Model
{
    public interface IPersonList
    {
        IPerson AddPerson();
        System.Collections.Generic.IList<IPerson> Persons { get; }
    }
}
