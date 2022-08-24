

using uAnimator;
using Model;
using Observer;
using Slot;
namespace Personage
{

    interface IChangeMaxHealth
    {
        void ChangeMaxHealth(float maxHealth);
    }
    interface IChangeHealth : IChangeMaxHealth
    {
        void ChangeHealth(float health);
    }
    interface IChangePDamage 
    {
        void ChangePDamage(float pDamage);
    }
    interface IChangeMDamage : IChangePDamage
    {
        void ChangeMDamage(float mDamage);
    }
    interface IChangePDefence 
    {
        void ChangePDefence(float pDefence);
    }
    interface IChangeMDefence : IChangePDefence
    {
        void ChangeMDefence(float mDefence);
    }
    interface ITakePDamage
    {
        void TakePDamage(float damage);
    }
    interface ITakeMDamage : ITakePDamage
    {
        void TakeMDamage(float damage);
    }


    interface IRightHand : ISlot
    {

    }
    interface ILeftHand : ISlot
    {

    }

    interface IBody : IRightHand, ILeftHand
    {

    }


    interface IPersonage : IBody, IModel//, IChangeHealth, IChangeMDamage, IChangeMDefence, ITakeMDamage
    {

    }


}
