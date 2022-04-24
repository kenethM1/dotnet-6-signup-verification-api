public interface ICategoriesService
{
    List<CategoriesDTO> GetAll();
    CategoriesDTO GetById(int id);
    CategoriesDTO Create(CategoryRequest model);
    CategoriesDTO Update(int id, CategoryRequest model);
    CategoriesDTO Delete(int id);
}