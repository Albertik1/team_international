public abstract class Alive {
    public abstract string GetSpeciesName();
}

public abstract class Plant : Alive {}

public interface IHerbivore {
    void Eat(Plant plant);
}

public interface ICarnivore {
    void Eat(Animal animal);
}

public abstract class Animal : Alive {
    public abstract string GetIndividualName();
}

public class Wolf : Animal, ICarnivore {
    private string individualName;

    public Wolf(string individualName) {
        this.individualName = individualName;
    }

    public override string GetIndividualName() {
        return individualName;
    }

    public override string GetSpeciesName() {
        return "wolf";
    }

    public void Eat(Animal animal) {
        // logic for a wolf eating an animal
    }
}

public class Rabbit : Animal, IHerbivore {
    private string individualName;

    public Rabbit(string individualName) {
        this.individualName = individualName;
    }

    public override string GetIndividualName() {
        return individualName;
    }

    public override string GetSpeciesName() {
        return "rabbit";
    }

    public void Eat(Plant plant) {
        // logic for a rabbit eating a plant
    }
}

public class Bear : Animal, ICarnivore, IHerbivore {
    private string individualName;

    public Bear(string individualName) {
        this.individualName = individualName;
    }

    public override string GetIndividualName() {
        return individualName;
    }

    public override string GetSpeciesName() {
        return "bear";
    }

    public void Eat(Plant plant) {
        // logic for a bear eating a plant
    }

    public void Eat(Animal animal) {
        // logic for a bear eating an animal
    }
}
