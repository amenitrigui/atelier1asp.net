using System.Security.Cryptography.X509Certificates;


namespace atelier1.Models.Repository
{
    public class EmployeRepository : Irepository<Employe>
    {
        List<Employe> lemployee;
        

        public EmployeRepository()
        {
            lemployee = new List<Employe>()
{
    new Employe {Id=1,Name="Sofien ben ali", Departement= "comptabilité",Sallery=1000},
    new Employe {Id=2,Name="Mourad triki", Departement= "RH",Sallery=1500},
    new Employe {Id=3,Name="ali ben mohamed", Departement= "informatique",Sallery=1700},
    new Employe {Id=4,Name="tarak aribi", Departement= "informatique",Sallery=1100}
};
        }


        public double SalaryAverage()
        {
            return lemployee.Average(x => x.Sallery);
        }
        public double MaxSalary()
        {
            return lemployee.Max(x => x.Sallery);
        }
        public int HrEmployeesCount()
        {
            return lemployee.Where(x => x.Departement == "HR").Count();
        }


        public void Add(Employe entity)
        {
            lemployee.Add(entity);
        }
       
        public void Delete(int id)
        {

            var emp = FindByID(id);
            lemployee.Remove(emp);
        }

        public Employe FindByID(int Id)
        {
            var emp = lemployee.FirstOrDefault(a => a.Id == Id);
            return emp;

        }

        public IList<Employe> GetAll()
        {
            return lemployee;
        }

        public List<Employe> Search(string term)
        {
            if (!string.IsNullOrEmpty(term))
                return lemployee.Where(a => a.Name.Contains(term)).ToList();
            else
                return lemployee;
        }

        public void Update(int id, Employe entity)
        {
            var emp = FindByID(id);
            emp.Name = entity.Name;
            emp.Departement = entity.Departement;
            emp.Sallery = entity.Sallery;
        }
    }
}
