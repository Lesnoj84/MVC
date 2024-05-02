using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category); //Update and Save method might have different implemintation for other classe
                                        // so its good to make it in a seperate interface, like ICaterogryRepository.
    }
}
