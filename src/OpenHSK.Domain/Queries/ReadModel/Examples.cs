namespace OpenHSK.Domain.Queries.ReadModel
{
    public class Examples
    {
        public Examples(Example[] items)
        {
            Items = items;
        }

        public Example[] Items { get; }
    }
}