namespace Data;

public class TutorialSQLData :ITutorialData
{

    public string GetById(int id)
    {
        //gestion Con SQL
        return "return " + id.ToString() + " SQL";
    }

    public string[] GetALL()
    {
        throw new NotImplementedException();
    }
}