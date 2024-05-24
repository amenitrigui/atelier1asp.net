namespace atelier1.Models.Repository
{
    public interface Irepository<T>
    {
        List<T> Search(string term);
        double SalaryAverage();
        double MaxSalary();
        int HrEmployeesCount();
        IList<T> GetAll();
        T FindByID(int Id);
        void Add(T entity);
        void Update(int id ,T entity);
        void Delete(int id);
      


    }
}
