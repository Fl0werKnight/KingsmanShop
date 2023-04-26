namespace KingsmanShop.ClassHelper
{
    internal class EF
    {
        public static Databases.Entities Context { get; } = new Databases.Entities();
    }
}
