


using Observer;
using Model;
namespace SpaceAnimator
{
    interface IAnimator : IModel, IObserver
    {
        string _strState { get; set; }
        float _speedAnim { get; set; }
    }
}
