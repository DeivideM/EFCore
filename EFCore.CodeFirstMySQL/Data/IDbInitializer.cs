namespace EFCore.CodeFirstMySQL.Data
{
    public interface IDbInitializer
    {
        public void Initialize();
        public void SeedData();
    }
}
