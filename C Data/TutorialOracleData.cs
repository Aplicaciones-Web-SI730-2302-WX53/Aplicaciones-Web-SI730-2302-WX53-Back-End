namespace Data;

public class TutorialOracleData : ITutorialData
{
    public string GetById(int id)
    {    //gestion Con ORacle
        return "return " + id.ToString() + " Oracle";
    }

    public string[] GetALL()
    {
        throw new NotImplementedException();
    }
}