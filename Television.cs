using System;

namespace lab_work_7
{
    public class Television : ElectronicDevice, IComparable
    {
        public bool IsOn { get; set; }
        public int Brightness { get; set; }

        public Television()
        { }
        public Television(string brand, string model, int screenSize, string resolution, bool isSmartTV, int soundPower)
        {
            Brand = brand;
            Model = model;
            ScreenSize = screenSize;
            Resolution = resolution;
            IsSmartTV = isSmartTV;
            SoundPower = soundPower;
        }
        public int CompareTo(object obj)
        {
            Television television = obj as Television;
            return string.Compare(this.Brand, television.Brand);
        }

        public string Info()
        {
            return Brand + ", " + Model;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Телевізор увімкнено.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Телевізор вимкнено.");
        }

        public void AdjustBrightness(int level)
        {
            if (level < 0 || level > 100)
            {
                Console.WriteLine("Рівень яскравості повинен бути від 0 до 100.");
            }
            else
            {
                Brightness = level;
                Console.WriteLine($"Яскравість встановлена на рівні {Brightness}%.");
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Бренд: {Brand}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Діагональ екрану: {ScreenSize}\"");
            Console.WriteLine($"Роздільна здатність: {Resolution}");
            Console.WriteLine($"Smart TV: {(IsSmartTV ? "Так" : "Ні")}");
            Console.WriteLine($"Потужність звуку: {SoundPower} Вт");
            Console.WriteLine($"Стан: {(IsOn ? "Увімкнено" : "Вимкнено")}");
            Console.WriteLine($"Яскравість: {Brightness}");
        }
    }
}
