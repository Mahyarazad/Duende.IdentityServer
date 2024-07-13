namespace IdentityServer.Entities
{
    public interface IConcurrencyAware
    {
        public string ConcurrencyStamp { get; set; }
    }
}
