namespace EFCore.CodeFirst.Data
{
    public interface IDbInitializer
    {
        public void Initialize();
        public void SeedData();
    }
}
