using CheckersLib.BoardElements;

namespace CheckersLib.Repositories
{
    /// <summary>
    /// Интерфейс для взаимодействия с хранилищем данных.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Метод для сохранении в хранилище результата партии.
        /// </summary>
        /// <param name="endType">Результат игры.</param>
        void SaveEndType(EndType endType);

        /// <summary>
        /// Извлечение имен игроков из хранилища.
        /// </summary>
        /// <returns>Имена игроков в порядке: (белый, черный)</returns>
        (string Name1, string Name2) ReadNames();
    }
}
