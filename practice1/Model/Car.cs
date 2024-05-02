namespace practice1.Model
{
    public  class Car:IComparable<Car>
    {

        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Owner { get; set; }=string.Empty;

        public int CompareTo(Car? other)
        {
            return this.Owner.CompareTo(other.Owner);
        }
    }
}
