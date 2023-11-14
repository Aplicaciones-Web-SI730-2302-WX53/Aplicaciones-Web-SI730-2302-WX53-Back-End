using Data;

namespace Domain;

public class TutorialDomain : ITutorialDomain
{
    public ITutorialData _tutorialData;

    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }

    public bool create(Tutorial tutorial)
    {
        /// Reglas de negocio
        ///
        ///if (tutorial.Title ==  "") return false; Validacionde formato
        var result = _tutorialData.GetByTitle(tutorial.Title);

        if (!result)
        {
            return _tutorialData.create(tutorial);
        }
        else
        {
            return false;
        }
    }

    public bool update(Tutorial tutorial,int id)
    {
        /// Reglas de negocio
        var result = _tutorialData.GetByTitle(tutorial.Title);

        if (!result)
        {
            return _tutorialData.Update(tutorial,id);
        }
        else
        {
            return false;
        }
    }

    public bool update(int id, string name)
    {
        throw new NotImplementedException();
    }

    public bool delete(int id)
    {
        // Validar negocio
        return _tutorialData.Delete(id);
    }
}