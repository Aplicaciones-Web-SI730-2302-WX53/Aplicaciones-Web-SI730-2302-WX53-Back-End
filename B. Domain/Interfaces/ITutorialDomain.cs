using Data;

namespace Domain;

public interface ITutorialDomain
{
    bool create(Tutorial tutorial);
    bool update(Tutorial tutorial, int id);
    bool delete(int id);
}