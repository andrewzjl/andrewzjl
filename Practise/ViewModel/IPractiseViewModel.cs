using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using LeetCodePractise.Model;

namespace LeetCodePractise.ViewModel
{
    /// <summary>
    /// The interface for generic practise view model
    /// </summary>
    /// <typeparam name="TestType">The type of the est type.</typeparam>
    /// <typeparam name="ResultType">The type of the esult type.</typeparam>
    public interface IPractiseViewModel<TestType, ResultType>
    {
        #region Dynamic test
        /// <summary>
        /// Gets the command used for how to add new test record.
        /// </summary>
        /// <value>
        /// The add new test record command.
        /// </value>
        RelayCommand AddNewTestRecordCommand { get; }
        /// <summary>
        /// Gets or sets the expected new result.
        /// </summary>
        /// <value>
        /// The expected new result.
        /// </value>
        ResultType ExpectedNewResult { get; set; }
        /// <summary>
        /// Gets or sets the new test record.
        /// </summary>
        /// <value>
        /// The new test record.
        /// </value>
        TestType NewTestRecord { get; set; }
        #endregion
        #region UI
        /// <summary>
        /// Gets or sets the performance description.
        /// </summary>
        /// <value>
        /// The performance description.
        /// </value>
        string PerformanceDescription { get; set; }
        /// <summary>
        /// Gets or sets the requirement.
        /// </summary>
        /// <value>
        /// The requirement.
        /// </value>
        string Requirement { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }
        /// <summary>
        /// Gets or sets the collection of test records.
        /// </summary>
        /// <value>
        /// The test records.
        /// </value>
        ObservableCollection<TestRecord<TestType, ResultType>> TestRecords { get; set; }

        /// <summary>
        /// Gets or sets the selected record.
        /// </summary>
        /// <value>
        /// The selected record.
        /// </value>
        TestRecord<TestType, ResultType> SelectedRecord { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        bool IsLoading { get; set; }

        /// <summary>
        /// Gets or sets the order identifier of problem.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the problem.
        /// </summary>
        /// <value>
        /// The difficulty.
        /// </value>
        Difficulty Difficulty { get; set; }
        #endregion

        /// <summary>
        /// Gets the re-calculate command.
        /// </summary>
        /// <value>
        /// The re-calculate command.
        /// </value>
        RelayCommand ReCalculateCommand { get; }
    }
}