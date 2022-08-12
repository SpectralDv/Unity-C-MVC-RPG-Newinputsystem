using System;
using System.Collections;
using System.Collections.Generic;


using Model;
using SpaceAnimator;
using Personage;
using Weapon;
namespace Observer
{
    public interface IObserver
    {

    }

    public interface IObserverWeapon : IObserver
    {
        int AddWeapon(ModelWeapon mw);
    }

    public interface IObserverAnimator : IObserver
    {
        int ChangeAnimState(string nameState,float speedAnim);
    }

    //интерфейс наблюдаемого объекта
    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void notify(KeyValuePair<string, IModel> p);
    }

    //наблюдаемый объект
    public class ExampleObservable : IObservable
    {
        //вектор наблюдателей
        public List<IObserver> observers;
        //listPersonage personage;
        public ExampleObservable()
        {
            observers = new List<IObserver>();
        }
        //void changeHealth(double p) { personage->updateHealth(p); notify(KeyValuePair<string,double>("health",p)); }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            foreach (IObserver ob in observers)
            {
                if (ob == o) { observers.Remove(ob); break; }
            }
        }
        public void notify(KeyValuePair<string, IModel> p)
        {
            if (p.Key == "weapon")
            {
                foreach (IObserverWeapon o in observers) { o.AddWeapon((ModelWeapon)p.Value); }
            }
        }
    }
}