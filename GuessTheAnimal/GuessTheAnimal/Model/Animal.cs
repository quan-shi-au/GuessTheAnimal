using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace GuessTheAnimal.Model
{
    public class Animal
    {
        public string Name { get; set; }
        public string Feature { get; set; }
        public string Sound { get; set; }
        public string Colour { get; set; }

        public string GetName(Animal that)
        {
            if (string.Equals(Feature, that.Feature, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Sound, that.Sound, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Colour, that.Colour, StringComparison.CurrentCultureIgnoreCase)
                )
                return Name;
            else
                return string.Empty;
        }

       
        public IEnumerable<Animal> GetStoredAnimals(string filePath)
        {
            using (var textReader = File.OpenText(filePath))
            {
                var csv = new CsvReader(textReader);
                var records = csv.GetRecords<Animal>().ToList();

                return records;

            }
        }
    }
}
