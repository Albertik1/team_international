using System;

public abstract class Lightstring
{
    protected Bulb[] bulbs;

    public Lightstring(int numBulbs)
    {
        bulbs = new Bulb[numBulbs];
        for (int i = 0; i < numBulbs; i++)
        {
            bulbs[i] = CreateBulb(i);
        }
    }

    public abstract string GetLightState(int minute);

    protected abstract Bulb CreateBulb(int serialNumber);

    public class Bulb
    {
        protected int serialNumber;
        protected bool isOn;

        public Bulb(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public bool IsOn(int minute)
        {
            if ((minute % 2 == 0 && serialNumber % 2 == 0) || (minute % 2 == 1 && serialNumber % 2 == 1))
            {
                isOn = true;
            }
            else
            {
                isOn = false;
            }
            return isOn;
        }
    }

    public class ColoredBulb : Bulb
    {
        protected string color;

        public ColoredBulb(int serialNumber) : base(serialNumber)
        {
            switch (serialNumber % 4)
            {
                case 1:
                    color = "red";
                    break;
                case 2:
                    color = "yellow";
                    break;
                case 3:
                    color = "green";
                    break;
                case 0:
                    color = "blue";
                    break;
            }
        }

        public string GetColor()
        {
            return color;
        }
    }
}

public class SimpleLightString : Lightstring
{
    public SimpleLightString(int numBulbs) : base(numBulbs) { }

    protected override Bulb CreateBulb(int serialNumber)
    {
        return new Bulb(serialNumber);
    }

    public override string GetLightState(int minute)
    {
        string state = "";
        for (int i = 0; i < bulbs.Length; i++)
        {
            if (bulbs[i].IsOn(minute))
            {
                state += "1";
            }
            else
            {
                state += "0";
            }
        }
        return state;
    }
}

public class ColoredLightString : Lightstring
{
    public ColoredLightString(int numBulbs) : base(numBulbs) { }

    protected override Bulb CreateBulb(int serialNumber)
    {
        return new ColoredBulb(serialNumber);
    }

    public override string GetLightState(int minute)
    {
        string state = "";
        for (int i = 0; i < bulbs.Length; i++)
        {
            if (bulbs[i].IsOn(minute))
            {
                state += bulbs[i] is ColoredBulb coloredBulb ? coloredBulb.GetColor() : "1";
            }
            else
            {
                state += "0";
            }
        }
        return state;
    }
}

// Usage example:
var simpleLightString = new SimpleLightString(10);
Console.WriteLine(simpleLightString.GetLightState(5));

var coloredLightString = new ColoredLightString(8);
Console.WriteLine(coloredLightString.GetLightState(3));
