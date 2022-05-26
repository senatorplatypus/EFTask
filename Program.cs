
using EFTask;
using Microsoft.EntityFrameworkCore;

// C - create
// R - read
// U - update
// D - delete

using (ApplicationContext db = new ApplicationContext())
{
    while (true)
    {
        Console.WriteLine("");
        Console.WriteLine("Выберите функцию:");
        Console.WriteLine("1 – Просмотреть список фильмов");
        Console.WriteLine("2 – Добавить фильм в список");
        Console.WriteLine("3 – Изменить информацию о фильме");
        Console.WriteLine("4 - Удалить фильм из списка");
        Console.WriteLine("0 - Выход из программы");
        switch (char.ToLower(Console.ReadKey(true).KeyChar))
        {
            case '1': ViewMovies(); break;
            case '2': AddMovie(); break;
            case '3': UpdateMovie(); break;
            case '4': DeleteMovie(); break;
            case '0': return;
            default: break;
        }
       
    }


   void  ViewMovies(){
        while (true)
            {var Movies = db.Movies.ToList();
            Console.WriteLine("");
            Console.WriteLine("Список фильмов:");
            foreach (Movie m in Movies)
            {
                Console.WriteLine($"{m.Id}.{m.Title} ({m.Director}) {m.Year} год");
            }
            Console.WriteLine("");
            return;
 
        }

    }

    void AddMovie()
    {
            string? title;
            int year;
            string? director;

            Console.WriteLine("");
            Console.WriteLine("Введите название фильма:");
            title = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Введите год выхода фильма:");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Введите фамилию режиссёра:");
            director = Console.ReadLine();

            Movie temp = new Movie { Title = title, Year = year, Director = director };
            db.Movies.Add(temp);
            db.SaveChanges();
            Console.WriteLine("Фильм добавлен");

            Console.WriteLine("");
            return;
    }

    void DeleteMovie()
    {
            Console.WriteLine("");
            Console.WriteLine("Выберите ID фильма, который хотите удалить:");
            int row = Convert.ToInt32(Console.ReadLine());
            Movie? movie = db.Movies.Where(p => p.Id == row).FirstOrDefault();
        if (movie != null)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
            Console.WriteLine("Фильм удалён");
        }
        else
        {
            Console.WriteLine("Такого ID нет в списке");
        }
        Console.WriteLine("");
        return;
    }
    void UpdateMovie()
    {
        Console.WriteLine("");
        Console.WriteLine("Выберите ID фильма, информацию о котором хотите изменить:");
        int row = Convert.ToInt32(Console.ReadLine());
        Movie? movie = db.Movies.Where(p => p.Id == row).FirstOrDefault();
        if (movie == null)
        {
            Console.WriteLine("Такого ID нет в списке");
        }
        else
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("1 – Изменить название фильма");
                Console.WriteLine("2 – Изменить год выхода");
                Console.WriteLine("3 – Изменить режиссёра");
                Console.WriteLine("0 – Выход в главное меню");

                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': Console.WriteLine("Ввод: "); movie.Title = Console.ReadLine(); db.Movies.Update(movie); db.SaveChanges(); break;
                    case '2': Console.WriteLine("Ввод: "); movie.Year = Convert.ToInt32(Console.ReadLine()); db.Movies.Update(movie); db.SaveChanges(); break;
                    case '3': Console.WriteLine("Ввод: "); movie.Director = Console.ReadLine(); db.Movies.Update(movie); db.SaveChanges(); break;
                    case '0': return;
                    default: break;
                }

            }
        }
    }
}