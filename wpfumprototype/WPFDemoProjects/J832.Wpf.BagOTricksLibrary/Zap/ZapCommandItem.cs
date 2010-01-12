﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using J832.Common;

namespace Microsoft.Samples.KMoore.WPFSamples.Zap
{
    public class ZapCommandItem : ICommand, INotifyPropertyChanged
    {
        protected internal ZapCommandItem(ZapScroller zapScroller, int index)
        {
            Util.RequireNotNull(zapScroller, "zapScroller");
            Util.RequireArgumentRange(index >= 0, "index");

            m_zapScroller = zapScroller;

            m_zapScroller.CurrentItemChanged += delegate(object sender, RoutedPropertyChangedEventArgs<int> e)
            {
                OnCanExecuteChanged(EventArgs.Empty);
            };

            m_index = index;

            m_content = m_zapScroller.Items[m_index];
        }

        public object Content
        {
            get { return m_content; ; }
            protected internal set
            {
                if (m_content != value)
                {
                    m_content = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Content"));
                }
            }
        }

        public int Index { get { return m_index; } }

        /// <remarks>
        ///     For public use. Most people don't like zero-base indices.
        /// </remarks>
        public int Number { get { return m_index + 1; } }

        public bool CanExecute
        {
            get
            {
                return (m_index != m_zapScroller.CurrentItemIndex);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute;
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs("CanExecute"));

            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void MakeCurrent()
        {
            m_zapScroller.CurrentItemIndex = m_index;
        }

        void ICommand.Execute(object parameter)
        {
            MakeCurrent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public override string ToString()
        {
            string output = (Content == null) ? "*null*" : Content.ToString();

            return string.Format("ZapCommandItem - Index: {0}, Content: {1}", m_index, output);
        }

        #region Implementation

        private object m_content;

        private readonly int m_index;
        private readonly ZapScroller m_zapScroller;

        #endregion

    } //*** class ZapCommandItem
}