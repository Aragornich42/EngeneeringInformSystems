namespace IoC
{
    /// <summary>
    /// Тривиальный интерфейс. Как твоя жизнь. :(
    /// </summary>
    public interface ITrivialIntf
    {
        /// <summary>
        /// Тривиальный десериализатор. Работает с тривиальными классами, у которых все свойства с простыми типами
        /// </summary>
        string TrivialSerializer(object trivialObject);
    }
}
