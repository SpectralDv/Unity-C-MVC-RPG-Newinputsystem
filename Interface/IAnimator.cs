


using Observer;
using Model;
namespace uAnimator
{
    interface IAnimator : IModel, IObserver
    {
        string _strState { get; set; }
        float _speedAnim { get; set; }
    }
}
