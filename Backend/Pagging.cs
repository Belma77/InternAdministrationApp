namespace Backend
{
    public class Paggination
    {
        public static List<T> Pagging<T>(int pageNumber, int pageSize, List<T> list)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
