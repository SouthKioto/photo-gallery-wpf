using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public class PhotoDataHandlers
    {
        public static List<PhotoData> GetDataFromTextFile(string path)
        {
            var photoList = new List<PhotoData>();

            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var parts = line.Split(';');

                    if (parts.Length >= 4)
                    {
                        try
                        {
                            var photo = new PhotoData
                            {
                                Photo_id = int.Parse(parts[0]),
                                Photo_Title = parts[1],
                                Photo_Description = parts[2],
                                Photo_ReleaseData = parts[3],
                                Photo_Source = $"img/{parts[1]}.jpg",
                            };

                            photoList.Add(photo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd podczas przetwarzania linii: {line}. Szczegóły: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Nieprawidłowa linia: {line}");
                    }
                }

            }

            return photoList;
        }
    }
}
