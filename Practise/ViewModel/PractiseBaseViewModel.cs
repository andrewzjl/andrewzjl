using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LeetCodePractise.ViewModel
{
    /// <summary>
    /// The base view model for all the solutions of algorithm
    /// </summary>
    /// <typeparam name="TestType">The type of the est type.</typeparam>
    /// <typeparam name="ResultType">The type of the esult type.</typeparam>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    abstract public class PractiseBaseViewModel<TestType, ResultType> : ViewModelBase, IPractiseViewModel<TestType, ResultType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PractiseBaseViewModel{TestType, ResultType}"/> class.
        /// We'll raise a task to execute the test cases automatically.
        /// </summary>
        public PractiseBaseViewModel()
        {
            Task.Run((Action)(() =>
            {
                using (new ShowBusy(Guid.NewGuid().ToString(), show => IsLoading = show))
                {
                    Stopwatch watch = Stopwatch.StartNew();
                    InitialTestCases();
                    ExecuteTestCases();
                    watch.Stop();
                    PerformanceDescription = string.Format("{0}ms costed for running the tests", watch.ElapsedMilliseconds);
                }
            }));
            RegisterInstance();
        }

        private void RegisterInstance()
        {
            Messenger.Default.Send<ViewModelBase>(this);
        }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged();
            }
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

        private Difficulty _difficulty;

        /// <summary>
        /// Gets or sets the difficulty.
        /// </summary>
        /// <value>
        /// The difficulty.
        /// </value>
        public Difficulty Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                RaisePropertyChanged();
            }
        }

        private int _id;

        /// <summary>
        /// Gets or sets the problem's identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
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
                        AddTestCases(NewTestRecord, ExpectedNewResult);
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

        private TestRecord<TestType, ResultType> _selectedRecord;

        /// <summary>
        /// Gets or sets the selected record.
        /// </summary>
        /// <value>
        /// The selected record.
        /// </value>
        public TestRecord<TestType, ResultType> SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                _selectedRecord = value;
                RaisePropertyChanged();
            }
        }


        private RelayCommand _recalculateTestCase;

        /// <summary>
        /// Gets the re-calculate command. Used to trigger the calculate again by double click. It's useful for debugging.
        /// </summary>
        /// <value>
        /// The re calculate command.
        /// </value>
        public RelayCommand ReCalculateCommand
        {
            get
            {
                return _recalculateTestCase ?? (_recalculateTestCase = new RelayCommand(() =>
                {
                    if (SelectedRecord != null)
                    {
                        var testCase = SelectedRecord.TestCase;
                        var result = SolutionExecutor?.DynamicInvoke(testCase);
                        SelectedRecord.ActualResult = (ResultType)result;
                    }
                }));
            }
        }


        public delegate ResultType CalculateResult(TestType testCase);

        /// <summary>
        /// The solution executor. It should be set in derived classes.
        /// </summary>
        protected CalculateResult SolutionExecutor;

        /// <summary>
        /// Initials the test cases.
        /// </summary>
        protected virtual void InitialTestCases()
        {
        }

        /// <summary>
        /// Executes the test cases.
        /// </summary>
        /// <exception cref="InvalidOperationException">Solution executor should be set before execute test cases</exception>
        protected virtual void ExecuteTestCases()
        {
            if (SolutionExecutor == null)
            {
                throw new InvalidOperationException("Solution executor should be set before execute test cases");
            }
            var records = new List<TestRecord<TestType, ResultType>>();
            _testCaseCollection.ForEach(testCase => records.Add(new TestRecord<TestType, ResultType>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
            TestRecords = new ObservableCollection<TestRecord<TestType, ResultType>>(records);
        }

        private List<KeyValuePair<TestType, ResultType>> _testCaseCollection = new List<KeyValuePair<TestType, ResultType>>();
        /// <summary>
        /// Adds the test cases into test pool.
        /// </summary>
        /// <param name="testCase">The test case.</param>
        /// <param name="expectedResult">The expected result.</param>
        protected virtual void AddTestCases(TestType testCase, ResultType expectedResult)
        {
            if (IsValidTestCase(testCase))
            {
                _testCaseCollection.Add(new KeyValuePair<TestType, ResultType>(testCase, expectedResult));
            }
        }

        /// <summary>
        /// Determines whether [the specified test case] [is valid test case] .
        /// </summary>
        /// <param name="testCase">The test case.</param>
        /// <returns>
        ///   <c>true</c> if [the specified test case] [is valid test case]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool IsValidTestCase(TestType testCase)
        {
            return true;
        }
    }
}
