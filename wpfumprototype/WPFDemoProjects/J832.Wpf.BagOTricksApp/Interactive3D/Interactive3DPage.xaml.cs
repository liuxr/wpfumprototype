﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using J832.Common;

namespace Microsoft.Samples.KMoore.WPFSamples
{
    public partial class Interactive3DPage : Page
    {
        public Interactive3DPage()
        {
            InitializeComponent();

            m_treeMap3DUserControl.ItemsSource = Agent.GetRandomList(10);
        }
    }

    public class Agent
    {
        public Agent(string firstName, string lastName, string agentId)
        {
            _firstName = firstName;
            _lastName = lastName;
            _agentId = agentId;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string AgentId
        {
            get { return _agentId; }
        }

        public int CustomerCount
        {
            get
            {
                return _customerCount;
            }
        }

        public override string ToString()
        {
            return string.Format("Agent: {0} {1}-{2}", _firstName, _lastName, _agentId);
        }

        public static Agent GetRandom()
        {
            return new Agent(GetRandomString(1, 5), GetRandomString(1, 6), GetRandomString(5, 0));
        }

        public static ReadOnlyCollection<Agent> GetRandomList(int count)
        {
            Util.RequireArgumentRange(count >= 0, "count");

            return Enumerable.Range(0, count).Select(index => GetRandom()).ToReadOnlyCollection();
        }

        #region implementation

        private string _firstName, _lastName, _agentId;

        private int _customerCount = s_random.Next(30) + 5;

        private static string GetRandomString(int upperCount, int lowerCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < upperCount; i++)
            {
                sb.Append(GetRandomChar(true).ToString());
            }
            for (int i = 0; i < lowerCount; i++)
            {
                sb.Append(GetRandomChar(false));
            }
            return sb.ToString();
        }

        private static char GetRandomChar(bool isUpper)
        {
            return GetChar(s_random.Next(26), isUpper);
        }
        private static char GetChar(int index, bool isUpper)
        {
            int a = Convert.ToInt32('a');
            int A = Convert.ToInt32('A');

            return Convert.ToChar(index + (isUpper ? A : a));
        }

        private static readonly Random s_random = new Random();

        #endregion

    }

}