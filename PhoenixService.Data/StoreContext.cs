using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoenixService.Data
{
    internal class StoreContext
    {
        private readonly List<Action> actions = new List<Action>();
        private readonly Lazy<DentaSmileContext> lazyDb = new Lazy<DentaSmileContext>(() => new DentaSmileContext());

        public StoreContext()
        {
        }

        public DentaSmileContext Db => lazyDb.Value;

        public void AfterSubmitChanges(Action action)
        {
            actions.Add(action);
        }

        public async Task SubmitChangesAsync()
        {
            await Db.SaveChangesAsync();
            DoActions();
        }

        private void DoActions()
        {
            foreach (var action in actions)
            {
                action.Invoke();
            }
            actions.Clear();
        }
    }
}