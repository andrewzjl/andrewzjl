using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.ViewModel
{
    public class ShowBusy : IDisposable
    {
        public static Dictionary<string, int> _callCount = new Dictionary<string, int>();
        Action<bool> _onStatusChange;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowBusy"/> class.
        /// Helper class that will run the Action when started and again when  disposed
        /// </summary>
        /// <remarks>
        /// Using this class allows us to do the using pattern to trigger an action in pairs
        /// Example:
        /// using ( new ShowBusy(show => IsLoading = show))
        /// {
        ///     // additional calls info 
        /// }
        /// </remarks>
        /// <param name="onStatusChange">The on status change action, true when starting, false when disposed.</param>
        /// Created By: jarceo
        /// On:12/9/2016
        public ShowBusy(string id, Action<bool> onStatusChange)
        {
            _onStatusChange = onStatusChange;
            _onStatusChange(true);
            _id = id;
            _count += 1;


        }

        string _id = string.Empty;
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {

                _count -= 1;
                if (_count <= 0)
                {
                    _onStatusChange(false);
                    _count = 0;
                }

                disposedValue = true;
            }
        }
        private int _count
        {
            get
            {
                if (!_callCount.ContainsKey(_id))
                {
                    _callCount[_id] = 0;

                }
                return _callCount[_id];
            }
            set
            {
                _callCount[_id] = value;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);

        }
        #endregion
    }
}
