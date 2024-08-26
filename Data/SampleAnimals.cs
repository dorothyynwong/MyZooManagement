using ZooManagement.Models.Database;
using ZooManagement.Helpers;

namespace ZooManagement.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 100;

        // private static readonly IList<IList<string>> Data = new List<IList<string>>
        // {
        //     new List<string> { "1","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "2","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "3","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "4","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "5","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "6","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "7","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "8","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "9","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "10","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "11","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "12","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "13","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "14","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "15","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "16","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "17","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "18","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "19","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "20","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "21","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "22","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "23","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "24","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "25","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "26","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "27","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "28","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "29","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "30","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "31","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "32","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "33","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "34","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "35","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "36","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "37","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "38","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "39","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "40","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "41","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "42","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "43","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "44","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "45","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "46","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "47","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "48","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "49","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "50","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "51","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "52","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "53","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "54","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "55","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "56","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "57","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "58","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "59","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "60","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "61","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "62","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "63","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "64","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "65","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "66","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "67","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "68","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "69","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "70","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "71","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "72","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "73","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "74","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "75","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "76","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "77","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "78","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "79","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "80","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "81","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "82","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "83","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "84","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "85","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "86","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "87","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "88","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "89","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "90","Susan", "6", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "91","Kania", "1", "1","29/04/2020","29/04/2020" },
        //     new List<string> { "92","Sonia", "1", "0","29/03/2020","29/04/2020" },
        //     new List<string> { "93","Tina", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "94","Tom", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "95","Jerry", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "96","Peter", "1", "0","15/06/2002","15/06/2002" },
        //     new List<string> { "97","James", "2", "1","05/04/2001","29/04/2020" },
        //     new List<string> { "98","Paul", "4", "0","13/05/2004","13/05/2004" },
        //     new List<string> { "99","Sue", "3", "1","22/05/2003","22/05/2003" },
        //     new List<string> { "100","Susan", "6", "0","15/06/2002","15/06/2002" }

        // };

        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(0, NumberOfAnimals).Select(CreateRandomAnimal);
        }

        private static Animal CreateRandomAnimal(int index)
        {
            return new Animal
            {
                Id = index+1,
                Name = AnimalNameGenerator.GetAnimalName(index),
                SpeciesId = RandomNumberGenerator.GetSpeciesId(),
                Sex = RandomNumberGenerator.GetSex(),
                DateOfBirth = DateGenerator.GetDateOfBirth(),
                DateCameToZoo = DateGenerator.GetDateCameZoo(),
            };
        }
    }
}
