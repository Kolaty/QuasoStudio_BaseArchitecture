using System.Collections.Generic;
using UnityEngine;
using R_D_2.Script.Interfaces;

// AQCS : Création de la class qui va se charger de n'importe qu'elle type d'updates sur toutes les intances
// qui en aurait besoin.
// Travail en court : Aucun - Update mardi 14 janvier - Alexandre
// Taff mardi 14 janvier : Le faire via un scriptable objet -> Non doit être une instance obligatoire

namespace R_D_2.Script.Services
{
    public class UpdateService
    {
        private List<IUpdateServices> _updateService = new List<IUpdateServices>();

        private List<IUpdateServiceServices> _updateServiceService = new List<IUpdateServiceServices>();

        private List<IFixedUpdateServices> _fixedUpdateService = new List<IFixedUpdateServices>();
        private List<ILateUpdateServices> _lateUpdateService = new List<ILateUpdateServices>();

        private Queue<IUpdateServices> _updateToAdd = new Queue<IUpdateServices>();
        private Queue<IUpdateServices> _updateToRemove = new Queue<IUpdateServices>();

        private Queue<IUpdateServiceServices> _updateServicesToAdd = new Queue<IUpdateServiceServices>();
        private Queue<IUpdateServiceServices> _updateServicesToRemove = new Queue<IUpdateServiceServices>();

        private Queue<IFixedUpdateServices> _fixedUpdateToAdd = new Queue<IFixedUpdateServices>();
        private Queue<IFixedUpdateServices> _fixedUpdateToRemove = new Queue<IFixedUpdateServices>();

        private Queue<ILateUpdateServices> _lateUpdateToAdd = new Queue<ILateUpdateServices>();
        private Queue<ILateUpdateServices> _lateUpdateToRemove = new Queue<ILateUpdateServices>();

        public UpdateService()
        {

        }

        // Update des managers
        public void RegisterUpdateServiceObserver(IUpdateServiceServices observer)
        {
            _updateServicesToAdd.Enqueue(observer);
        }
        public void UnregisterUpdateServiceObserver(IUpdateServiceServices observer)
        {
            _updateServicesToRemove.Enqueue(observer);
        }

        // Update des interfaces
        public void RegisterUpdateObserver(IUpdateServices observer)
        {
            _updateToAdd.Enqueue(observer);
        }

        public void UnregisterUpdateObserver(IUpdateServices observer)
        {
            _updateToRemove.Enqueue(observer);
        }

        // Fixed Update des interfaces
        public void RegisterFixedUpdateObserver(IFixedUpdateServices observer)
        {
            _fixedUpdateToAdd.Enqueue(observer);
        }

        public void UnregisterFixedUpdateObserver(IFixedUpdateServices observer)
        {
            _fixedUpdateToRemove.Enqueue(observer);
        }

        // Late Update des interfaces
        public void RegisterLateUpdateObserver(ILateUpdateServices observer)
        {
            _lateUpdateToAdd.Enqueue(observer);
        }

        public void UnregisterLateUpdateObserver(ILateUpdateServices observer)
        {
            _lateUpdateToRemove.Enqueue(observer);
        }

        public void Update()
        {
            NotifyUpdateObservers();
            NotifyUpdateManagerObservers();

            ProcessQueues(_updateService, _updateToAdd, _updateToRemove);
            ProcessQueues(_updateServiceService, _updateServicesToAdd, _updateServicesToRemove);
        }


        public void FixedUpdate()
        {
            NotifyFixedUpdateObservers();

            ProcessQueues(_fixedUpdateService, _fixedUpdateToAdd, _fixedUpdateToRemove);
        }

        public void LateUpdate()
        {
            NotifyLateUpdateObservers();

            ProcessQueues(_lateUpdateService, _lateUpdateToAdd, _lateUpdateToRemove);
        }
        private void ProcessQueues<T>(List<T> observers, Queue<T> toAdd, Queue<T> toRemove)
        {
            while (toRemove.Count > 0)
            {
                T item = toRemove.Dequeue();
                if (observers.Contains(item))
                {
                    observers.Remove(item);
                }
            }

            while (toAdd.Count > 0)
            {
                T item = toAdd.Dequeue();
                if (!observers.Contains(item))
                {
                    observers.Add(item);
                }
            }
        }
        private void NotifyUpdateManagerObservers()
        {
            foreach (var observer in _updateServiceService)
            {
                if (observer == null)
                {
                    Debug.LogError("Problème un objet aurait du etre retirer");
                    _updateServicesToRemove.Enqueue(observer);

                }
                if (_updateServicesToRemove.Contains(observer))
                    continue;

                observer?.OnUpdateServices();
            }
        }
        private void NotifyUpdateObservers()
        {
            foreach (var observer in _updateService)
            {
                if (observer == null)
                {
                    Debug.LogError("Problème un objet aurait dû être retirer");
                    _updateToRemove.Enqueue(observer);
                }
                if (_updateToRemove.Contains(observer)) // V�rifie si l'observateur doit �tre retir�
                    continue;

                observer?.OnUpdate();
            }
        }
        public void UnsubscribeAll()
        {
            foreach (IUpdateServices uo in _updateServiceService)
            {
                UnregisterUpdateObserver(uo);
            }

            foreach (IFixedUpdateServices fuo in _fixedUpdateService)
            {
                UnregisterFixedUpdateObserver(fuo);
            }

            foreach (ILateUpdateServices luo in _lateUpdateService)
            {
                UnregisterLateUpdateObserver(luo);
            }
        }
        private void NotifyFixedUpdateObservers()
        {
            foreach (var observer in _fixedUpdateService)
            {
                if (observer == null)
                {
                    Debug.LogError("Problème un objet aurait dû être retirer");
                    _fixedUpdateToRemove.Enqueue(observer);
                }
                if (_fixedUpdateToRemove.Contains(observer)) // V�rifie si l'observateur doit �tre retir�
                    continue;

                observer?.OnFixedUpdate();
            }
        }
        private void NotifyLateUpdateObservers()
        {
            foreach (var observer in _lateUpdateService)
            {
                if (observer == null)
                {
                    Debug.LogError("Problème un objet aurait dû être retirer");
                    _lateUpdateToRemove.Enqueue(observer);
                }
                if (_lateUpdateToRemove.Contains(observer)) 
                    continue;

                observer?.OnLateUpdate();
            }
        }
    }
}