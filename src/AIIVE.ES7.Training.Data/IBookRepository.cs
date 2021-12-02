namespace AIIVE.ES7.Training.Data
{
    public interface IBookRepository<T>: IReadRepository<T>, IWriteRepository<T> where T: Book
    {

    }
}
