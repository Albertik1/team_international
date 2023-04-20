public abstract class Alive {
    public abstract string GetSpeciesName();
}

public abstract class Plant : Alive {}

public abstract class Animal : Alive {
    public abstract string GetIndividualName();
}

public abstract class Herbivore : Animal {
    public abstract void Eat(Plant plant);
}

public abstract class Carnivore : Animal {
    public abstract void Eat(Animal animal);
}

public class Wolf : Carnivore {
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
    
    public override void Eat(Animal animal) {
        // logic for a wolf eating an animal
    }
}

public class Rabbit : Herbivore {
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
    
    public override void Eat(Plant plant) {
        // logic for a rabbit eating a plant
    }
}

public class Bear : Animal {
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
