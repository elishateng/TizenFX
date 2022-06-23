/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using static Interop;
using System;
using System.IO;

namespace Tizen.MachineLearning.Train
{
    /// <summary>
    /// Constructs the dataset.
    /// </summary>
    /// <remarks>
    /// Use this function to create a dataset. dataset should be released using Dispose().
    /// dataset is available until the model is released.
    /// </remarks>
    /// <since_tizen> 10 </since_tizen>
    public class Dataset: IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        ///  Constructs the dataset.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public Dataset()
        {
            NNTrainerError ret = Interop.Dataset.Create(out handle);
            NNTrainer.CheckException(ret, "Failed to create dataset instance");
            Log.Info(NNTrainer.Tag, "Create Dataset");
        }
        /// <summary>
        /// Frees the neural network dataset.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <remarks>
        /// Use this function to destroy dataset. Fails if dataset is owned by a model.
        /// </remarks>
        ~Dataset()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object including opened handle.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                // release managed object
            }
            // release unmanaged object
            if (handle != IntPtr.Zero)
            {
                // Destroy dataset.
                NNTrainerError ret = Interop.Dataset.Destroy(handle);
                NNTrainer.CheckException(ret, "Failed to destroy dataset instance");
                Log.Info(NNTrainer.Tag, "Destroy Dataset");

                handle = IntPtr.Zero;
            }
            disposed = true;
        }

        /// <summary>
        /// Adds data file to dataset.
        /// </summary>
        /// <remarks>
        /// Use this function to add a data file from where data is retrieved.
        /// If you want to access only internal storage by using this function,
        /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
        /// want to access only external storage by using this function, you should add
        /// privilege %http://tizen.org/privilege/externalstorage. If you can access both
        /// storage, you must add all privilege
        /// </remarks>
        /// <param name="mode">The phase where this generator should be used.</param>
        /// <param name="file">file path.</param>
        /// <since_tizen> 10 </since_tizen>
        public void AddFile(NNTrainerDatasetMode mode, string file)
        {
            if (string.IsNullOrEmpty(file))
                NNTrainer.CheckException(NNTrainerError.InvalidParameter, "file is null");

            NNTrainerError ret = Interop.Dataset.AddFile(handle, mode, file);
            NNTrainer.CheckException(ret, "Failed to add file");
            Log.Info(NNTrainer.Tag, $"Add file{file}");
        }

        internal IntPtr GetHandle()
        {
            return handle;
        }

        /// <summary>
        /// Sets the neural network dataset property.
        /// </summary>
        /// <remarks>
        /// Use this function to set dataset property for a specific mode.
        /// </remarks>
        /// <param name="mode">The mode to set the property.</param>
        /// <param name="property">property for dataset.</param>
        /// <since_tizen> 10 </since_tizen>
        public void SetProperty(NNTrainerDatasetMode mode, params string[] property)
        {
            string propertyParams = null;

            if (property.Length > 0) {
                propertyParams = string.Join("|", property);
                Log.Info(NNTrainer.Tag, "Set property:"+ propertyParams);
            }

            NNTrainerError ret = Interop.Dataset.SetProperty(handle, mode, propertyParams);
            NNTrainer.CheckException(ret, "Failed to set property");
        }
    } 
}
