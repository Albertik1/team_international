using System;

public abstract class Lightstring
{
    protected Bulb[] bulbs;

    public Lightstring(int numBulbs)
    {
        bulbs = new Bulb[numBulbs];
        for (int i = 0; i < numBulbs; i++)
        {
            bulbs[i] = new Bulb(i);
        }
    }

    public abstract string GetLightState(int minute);

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
