using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Service
{
    interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        private IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService members
        public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))

            {
                return categoryRepository.GetAll();
            }
            else
            {
                return categoryRepository.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower().Trim()));
            }
        }

        public Category GetCategory(int id)
        {
            return categoryRepository.GetById(id);
        }

        public Category GetCategory(string name)
        {
            return categoryRepository.GetCategoryByName(name);
        } 

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}