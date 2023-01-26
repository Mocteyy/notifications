using Domain.Enums;
using Domain.Exceptions;

namespace Data.Utils 
{
    public class CategoryFunctions 
    {
        public static Categories GetCategoryFromCode(int code)
        {
            switch(code){
                case 0:
                    return Categories.Sports;
                case 1:
                    return Categories.Movies;
                case 2:
                    return Categories.Videogames;
                default:
                    throw new UnsupportedCategoryException();
            }
        }
    }
}