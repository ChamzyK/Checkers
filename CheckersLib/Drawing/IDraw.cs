using CheckersLib.BoardElements;

namespace CheckersLib.Drawing
{
    /// <summary>
    /// Интерфейс предоставляющий логику отрисовки игры. При использовании библиотеки, рекомендуется реализация этого интерфейса.
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// Игровое поле, которое нужно отрисовать
        /// </summary>
        Board Board { get; set; }

        /// <summary>
        /// Отрисовка всего поля с самого начала.
        /// </summary>
        void DrawAll();

        /// <summary>
        /// Удаление всех отрисованных элементов.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Обновление содержимого клетки на поле.
        /// </summary>
        void RefreshSquareContent(Square square);

        /// <summary>
        /// Вывод имен игроков.
        /// </summary>
        /// <param name="names">Имена игроков.</param>
        void WriteNames((string name1, string name2) names);
    }
}
