namespace Data;

public interface ITutorialData
{
    public Tutorial GetById(int id);
    public List<Tutorial>  GetFilteredData(Tutorial tutorial);
    public Task<List<Tutorial>> GetALL();
    public bool GetByTitle(string title);
    
    
    bool create(Tutorial tutorial);
    bool Update(Tutorial tutorial,int id);
    bool Delete(int id);
}