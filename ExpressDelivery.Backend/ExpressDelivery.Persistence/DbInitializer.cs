namespace ExpressDelivery.Persistence
{
    public static class DbInitializer
    {
        /// <summary>
        /// Используется при старте приложения и проверяет создана ли база данных, если нет, то создает на основе контекста.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ExpressDeliveryDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
