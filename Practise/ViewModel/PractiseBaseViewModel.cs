using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LeetCodePractise.Model;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.ViewModel
{
    /// <summary>
    /// The base view model for all the solutions of algorithm
    /// </summary>
    /// <typeparam name="TestType">The type of the est type.</typeparam>
    /// <typeparam name="ResultType">The type of the esult type.</typeparam>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    abstract public class PractiseBaseViewModel<TestType, ResultType> : ViewModelBase
    {
        public PractiseBaseViewModel()
        {
            Task.Run(() =>
            {
                Stopwatch watch = Stopwatch.StartNew();
                InitialTestCases();
                watch.Stop();
                PerformanceDescription = string.Format("{0}ms costed for running the tests", watch.ElapsedMilliseconds);
            });
            RegisterInstance();
        }

        private void RegisterInstance()
        {
            Messenger.Default.Send<ViewModelBase>(this);
        }

        private string _title;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private string _requirement;

        /// <summary>
        /// Gets or sets the requirement information.
        /// </summary>
        /// <value>
        /// The requirement.
        /// </value>
        public string Requirement
        {
            get { return _requirement; }
            set
            {
                _requirement = value;
                RaisePropertyChanged();
            }
        }

        private string _performanceDescription;

        /// <summary>
        /// Gets or sets the performance description.
        /// </summary>
        /// <value>
        /// The performance description.
        /// </value>
        public string PerformanceDescription
        {
            get { return _performanceDescription; }
            set
            {
                _performanceDescription = value;
                RaisePropertyChanged();
            }
        }

        private TestType _newTestRecord;

        /// <summary>
        /// Gets or sets the new test record.
        /// </summary>
        /// <value>
        /// The new test record.
        /// </value>
        public TestType NewTestRecord
        {
            get { return _newTestRecord; }
            set
            {
                _newTestRecord = value;
                RaisePropertyChanged();
            }
        }

        private ResultType _expectedNewResult;

        /// <summary>
        /// Gets or sets the expected new result.
        /// </summary>
        /// <value>
        /// The expected new result.
        /// </value>
        public ResultType ExpectedNewResult
        {
            get { return _expectedNewResult; }
            set
            {
                _expectedNewResult = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _addNewTestRecordCommand;

        /// <summary>
        /// Gets the AddNewTestRecordCommand.
        /// </summary>
        public RelayCommand AddNewTestRecordCommand
        {
            get
            {
                return _addNewTestRecordCommand
                    ?? (_addNewTestRecordCommand = new RelayCommand(
                    () =>
                    {
                        TestRecords.Add(new TestRecord<TestType, ResultType>(NewTestRecord, ExpectedNewResult, SolutionExecutor(NewTestRecord)));
                        NewTestRecord = default(TestType);
                        ExpectedNewResult = default(ResultType);
                    }));
            }
        }

        private ObservableCollection<TestRecord<TestType, ResultType>> _testRecords = new ObservableCollection<TestRecord<TestType, ResultType>>();

        /// <summary>
        /// Gets or sets the test records.
        /// </summary>
        /// <value>
        /// The test records.
        /// </value>
        public ObservableCollection<TestRecord<TestType, ResultType>> TestRecords
        {
            get { return _testRecords; }
            set
            {
                _testRecords = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand<TestType> _recalculateTestCase;

        public RelayCommand<TestType> ReCalculateCommand
        {
            get
            {
                return _recalculateTestCase ?? (_recalculateTestCase = new RelayCommand<TestType>((testCase) =>
                {
                    SolutionExecutor?.DynamicInvoke(testCase);
                }));
            }
        }


        public delegate ResultType CalculateResult(TestType testCase);

        protected CalculateResult SolutionExecutor;
        abstract protected void InitialTestCases();
    }
}
