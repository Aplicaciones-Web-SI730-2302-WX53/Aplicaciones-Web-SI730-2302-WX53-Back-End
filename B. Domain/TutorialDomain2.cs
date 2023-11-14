namespace Domain;

public class TutorialDomain2: ITutorialDomain
{
    public bool create(string name)
    {
        if (name == "bio")
        {
            return true;
        }
        else
        {
            return  false;
        }

        ;
    }

    public bool update(int id, string name)
    {
        throw new NotImplementedException();
    }

    public bool delete(int id)
    {
        throw new NotImplementedException();
    }
}