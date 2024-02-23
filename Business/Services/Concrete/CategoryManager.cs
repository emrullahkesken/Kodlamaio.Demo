using Business.DTOs.Category;
using Business.Services.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(CategoryAddDto category)
        {
            Category newCategory = new Category();
            newCategory.Name = category.Name;

            _categoryDal.Add(newCategory);
        }

        public void Delete(int categoryId)
        {
            var deletedCategory = _categoryDal.Get(c => c.Id.Equals(categoryId));

            _categoryDal.Delete(deletedCategory);
        }

        public CategoryGetDto Get(int categoryId)
        {
            CategoryGetDto category = new CategoryGetDto();

            var hasCategory = _categoryDal.Get(c => c.Id.Equals(categoryId));
            category.Name = hasCategory.Name;

            return category;
        }

        public List<CategoryGetListDto> GetList()
        {
            var hasCategory = _categoryDal.GetList();

            List<CategoryGetListDto> categories = new List<CategoryGetListDto>();

            foreach (var item in hasCategory)
            {
                CategoryGetListDto categoryGetListDto = new CategoryGetListDto();

                categoryGetListDto.Id = item.Id;
                categoryGetListDto.Name = item.Name;

                categories.Add(categoryGetListDto);
            }

            return categories;
        }

        public void Update(CategoryUpdateDto category)
        {
            var hasCategory = _categoryDal.Get(c => c.Id.Equals(category.Id));
            hasCategory.Name = category.Name;

            _categoryDal.Update(hasCategory);
        }
    }
}
