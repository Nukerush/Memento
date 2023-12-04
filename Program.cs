using System;
using System.Collections.Generic;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Silo silo = new Silo();
            silo.Shoot(); 
            GameHistory game = new GameHistory();

            game.History.Push(silo.SaveState()); // сохраняем 

            silo.Shoot(); 

            silo.RestoreState(game.History.Pop());//загружаем

            silo.Shoot();

            Console.Read();
        }

    }
    class Silo //originator
    {
        private int rockets = 10; 
        private int lives = 5; 

        public void Shoot()
        {
            if (rockets > 0)
            {
                rockets--;
                Console.WriteLine("Производим выстрел. Осталось {0} ракет", rockets);
            }
            else
                Console.WriteLine("Ракет больше нет");
        }
        
        public HeroMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} ракет, {1} жизней", rockets, lives);
            return new HeroMemento(rockets, lives);
        }

       
        public void RestoreState(HeroMemento memento)
        {
            this.rockets = memento.Rockets;
            this.lives = memento.Lives;
            Console.WriteLine("Восстановление игры. Параметры: {0} ракет, {1} жизней", rockets, lives);
        }
    }
    // Memento
    class HeroMemento
    {
        public int Rockets { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int rockets, int lives)
        {
            this.Rockets = rockets;
            this.Lives = lives;
        }
    }

    // caretaker
    class GameHistory
    {
        public Stack <HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
