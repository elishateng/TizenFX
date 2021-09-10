/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    ///<summary>
    /// Issues a notification upon a condition of the property being met.
    /// See PropertyCondition for available defined conditions.
    ///</summary>
    /// <since_tizen> 4 </since_tizen>
    public class PropertyNotification : BaseHandle
    {
        #region Fields
        private DaliEventHandler<object, NotifyEventArgs> notifiedEventHandler;
        private NotifyEventCallbackDelegate notifySignalCallback;
        #endregion //#region Fields

        #region Constructors
        /// <summary>
        /// Create a instance of PropertyNotification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification() : this(Interop.PropertyNotification.new_PropertyNotification__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create a instance of PropertyNotification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification(PropertyNotification handle) : this(Interop.PropertyNotification.new_PropertyNotification__SWIG_1(PropertyNotification.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyNotification(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PropertyNotification.PropertyNotification_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }
        #endregion //#region Constructors

        #region Distructors
        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (notifySignalCallback != null)
            {
                var signal = NotifySignal();
                if (signal?.SwigCPtr.Handle == IntPtr.Zero) { signal = null; }
                signal?.Disconnect(notifySignalCallback);
                notifySignalCallback = null;
                signal?.Dispose();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }
            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            base.Dispose(type);
        }

        // This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyNotification.delete_PropertyNotification(swigCPtr);
        }
        #endregion //#region Distructors

        #region Delegates
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NotifyEventCallbackDelegate(IntPtr propertyNotification);
        #endregion //#region Delegates

        #region Events
        ///<summary>
        /// Event for Notified signal which can be used to subscribe/unsubscribe the event handler
        /// Notified signal is emitted when the notification upon a condition of the property being met, has occurred.
        ///</summary>
        /// <since_tizen> 4 </since_tizen>
        public event DaliEventHandler<object, NotifyEventArgs> Notified
        {
            add
            {
                if (notifiedEventHandler == null)
                {
                    notifySignalCallback = OnPropertyNotificationNotify;
                    var signal = NotifySignal();
                    if (signal?.SwigCPtr.Handle == IntPtr.Zero) { signal = null; }
                    signal?.Connect(notifySignalCallback);
                    signal?.Dispose();
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                notifiedEventHandler += value;
            }
            remove
            {
                notifiedEventHandler -= value;
                if (notifiedEventHandler == null && notifySignalCallback != null)
                {
                    var signal = NotifySignal();
                    if (signal?.SwigCPtr.Handle == IntPtr.Zero) { signal = null; }
                    signal?.Disconnect(notifySignalCallback);
                    notifySignalCallback = null;
                    signal?.Dispose();
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        ///<summary>
        /// Event arguments that passed via Notify signal
        ///</summary>
        /// <since_tizen> 3 </since_tizen>
        public class NotifyEventArgs : EventArgs
        {
            private PropertyNotification propertyNotification;

            ///<summary>
            /// PropertyNotification - is the PropertyNotification handle that has the notification properties.
            ///</summary>
            /// <since_tizen> 3 </since_tizen>
            public PropertyNotification PropertyNotification
            {
                get
                {
                    return propertyNotification;
                }
                set
                {
                    propertyNotification = value;
                }
            }
        }
        #endregion //#region Events

        #region Enums
        /// <summary>
        /// Enumeration for description of how to check condition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum NotifyMode
        {
            /// <summary>
            /// Don't notify, regardless of result of Condition
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Disabled,
            /// <summary>
            /// Notify whenever condition changes from false to true.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NotifyOnTrue,
            /// <summary>
            /// Notify whenever condition changes from true to false.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NotifyOnFalse,
            /// <summary>
            /// Notify whenever condition changes (false to true, and true to false)
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NotifyOnChanged
        }
        #endregion //#region Enums

        #region Methods
        /// <summary>
        /// Downcast a PropertyNotification instance.
        /// </summary>
        /// <param name="handle">Handle to an object of BaseHandle type.</param>
        /// <returns>Handle to an object of the PropertyNotification type.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyNotification DownCast(BaseHandle handle)
        {
            PropertyNotification ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PropertyNotification;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the condition of this notification.
        /// </summary>
        /// <returns>The condition is returned.</returns>
        /// <since_tizen> 4 </since_tizen>
        public PropertyCondition GetCondition()
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyNotification.PropertyNotification_GetCondition__SWIG_0(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the target handle that this notification is observing.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Animatable GetTarget()
        {
            BaseHandle ret = Registry.GetManagedBaseHandleFromNativePtr(Interop.PropertyNotification.PropertyNotification_GetTarget(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret as Animatable;
        }

        /// <summary>
        /// Gets the target handle's property index that this notification.
        /// </summary>
        /// <returns>The target property index.</returns>
        /// <since_tizen> 4 </since_tizen>
        public int GetTargetProperty()
        {
            int ret = Interop.PropertyNotification.PropertyNotification_GetTargetProperty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the Notification mode.
        /// </summary>
        /// <param name="mode">mode Notification mode (Default is PropertyNotification::NotifyOnTrue).</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetNotifyMode(PropertyNotification.NotifyMode mode)
        {
            Interop.PropertyNotification.PropertyNotification_SetNotifyMode(swigCPtr, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the current Notification mode.
        /// </summary>
        /// <returns>Notification mode.</returns>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification.NotifyMode GetNotifyMode()
        {
            PropertyNotification.NotifyMode ret = (PropertyNotification.NotifyMode)Interop.PropertyNotification.PropertyNotification_GetNotifyMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the result of the last condition check that caused a signal emit,
        /// useful when using NotifyOnChanged mode and need to know what it changed to.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool GetNotifyResult()
        {
            bool ret = Interop.PropertyNotification.PropertyNotification_GetNotifyResult(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get property notification from Intptr.<br/>
        /// This should be internal, please do not use.
        /// </summary>
        /// <param name="cPtr">An object of IntPtr type.</param>
        /// <returns>An object of the PropertyNotification type.</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use Notified event instead!" +
            "IntPtr(native integer pointer) is supposed to be not used in Application!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyNotification GetPropertyNotificationFromPtr(global::System.IntPtr cPtr)
        {
            PropertyNotification ret = new PropertyNotification(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Assign.
        /// </summary>
        /// <param name="rhs">A reference to the copied handle.</param>
        /// <returns>A reference to this.</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification() constructor instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyNotification Assign(PropertyNotification rhs)
        {
            PropertyNotification ret = new PropertyNotification(Interop.PropertyNotification.PropertyNotification_Assign(swigCPtr, PropertyNotification.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Connects to this signal to be notified when the notification has occurred.
        /// </summary>
        /// <returns>A signal object to Connect() with</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyNotifySignal NotifySignal()
        {
            PropertyNotifySignal ret = new PropertyNotifySignal(Interop.PropertyNotification.PropertyNotification_NotifySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyNotification obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        // Callback for PropertyNotification NotifySignal
        private void OnPropertyNotificationNotify(IntPtr propertyNotification)
        {
            NotifyEventArgs e = new NotifyEventArgs();
            e.PropertyNotification = GetPropertyNotificationFromPtr(propertyNotification);

            if (notifiedEventHandler != null)
            {
                //here we send all data to user event handlers
                notifiedEventHandler(this, e);
            }
        }
        #endregion //#region Methods
    }
}