public abstract class Animal
{
    public abstract string Species { get; }
}

public interface ICarnivore
{
    void Hunt();
}

public interface IHerbivore
{
    void Graze();
}

public class Wolf : Animal, ICarnivore
{
    public override string Species => "Wolf";

    public void Hunt()
    {
        // Implement hunting behavior
    }
}

public class Rabbit : Animal, IHerbivore
{
    public override string Species => "Rabbit";

    public void Graze()
    {
        // Implement grazing behavior
    }
}

public class Bear : Animal, ICarnivore, IHerbivore
{
    public override string Species => "Bear";

    public void Hunt()
    {
        // Implement hunting behavior
    }

    public void Graze()
    {
        // Implement grazing behavior
    }
}
