using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class TutorialMySQLData : ITutorialData
{
    private LearningCenterBDCOntext _learningCenter;

    public TutorialMySQLData(LearningCenterBDCOntext learningCenter)
    {
        _learningCenter = learningCenter;
    }
    
    public Tutorial GetById(int id)
    {
        //var sql = "Select * from tutorial where id =" + id;
        return _learningCenter.Tutorials.Where(t => t.Id == id && t.IsActive ).FirstOrDefault();
        //velocidad en bigdata
        //_learningCenter.FromExpression("Select * from tutorial where id =" + id);
        // porcedimientos almecedaos - parametrizados
    }

    public List<Tutorial> GetFilteredData(Tutorial tutorial)
    {
        //wherename '%nombre%'
        return _learningCenter.Tutorials.Where(t => t.Title.Contains(tutorial.Title)
                                                    && t.Author.Contains(tutorial.Author)
                                                    && t.Year >= tutorial.Year
                                                    && t.IsActive).ToList();
    }

    public async Task<List<Tutorial>> GetALL()
    {
        return await _learningCenter.Tutorials.Where(t=> t.IsActive).ToListAsync(); // linq
    }

    public bool GetByTitle(string title)
    {
        var count = _learningCenter.Tutorials.Where(t => t.Title == title && t.IsActive).ToList().Count();

        return count > 0;

    }

    public bool create(Tutorial tutorial)
    {
        try
        {
            _learningCenter.Tutorials.Add(tutorial);
            _learningCenter.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            //Loggear error
            return false;
        }
    }
    
    public bool Update(Tutorial tutorial,int id)
    {
        try
        {
            var tutorialUpdated = _learningCenter.Tutorials.Where(t => t.Id == id).FirstOrDefault();

            tutorialUpdated.Title = tutorial.Title;
            tutorialUpdated.Author = tutorial.Author;
            tutorialUpdated.Year = tutorial.Year;
            tutorialUpdated.DateUdpate = DateTime.Now;

            _learningCenter.Tutorials.Update(tutorialUpdated);
            
            _learningCenter.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            //Loggear error
            return false;
        }
    }

    public bool Delete(int id)
    {  try
        {
            var tutorialUpdated = _learningCenter.Tutorials.Where(t => t.Id == id).FirstOrDefault();
            tutorialUpdated.IsActive = false;
            tutorialUpdated.DateUdpate = DateTime.Now;

            _learningCenter.Tutorials.Update(tutorialUpdated);
            
            _learningCenter.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            //Loggear error
            return false;
        }
    }
}