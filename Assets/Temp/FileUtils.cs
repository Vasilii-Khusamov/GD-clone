using System.IO;

public static class FileUtils
{
    /// <summary>
    /// Функция для создания или перезаписи файла с указанным содержимым.
    /// </summary>
    /// <param name="folderPath">Путь к папке.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="content">Содержимое файла.</param>
    public static void CreateOrOverwriteFile(string folderPath, string fileName, string content)
    {
        // Формируем полный путь к файлу
        string fullPath = Path.Combine(folderPath, fileName);

        // Проверка существования папки и её создание, если она отсутствует
        Directory.CreateDirectory(folderPath);

        // Перезапись или создание файла с новым содержимым
        File.WriteAllText(fullPath, content);
    }
}
