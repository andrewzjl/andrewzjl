using GalaSoft.MvvmLight.Ioc;
using LeetCodePractise.Model;
using LeetCodePractise.Model.Extensions;
using LeetCodePractise.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class LetterCombinationsViewModel : PractiseBaseViewModel<string, string>
    {
        private List<Tuple<string, string>> _testCases = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("", ""),
            new Tuple<string, string>("23", "ad,ae,af,bd,be,bf,cd,ce,cf"),
            new Tuple<string, string>("2", "a,b,c"),
            new Tuple<string, string>("203", ""),
            new Tuple<string, string>("12", ""),
            new Tuple<string, string>("79", "pw,px,py,pz,qw,qx,qy,qz,rw,rx,ry,rz,sw,sx,sy,sz"),
            new Tuple<string, string>("777", "ppp,ppq,ppr,pps,pqp,pqq,pqr,pqs,prp,prq,prr,prs,psp,psq,psr,pss,qpp,qpq,qpr,qps,qqp,qqq,qqr,qqs,qrp,qrq,qrr,qrs,qsp,qsq,qsr,qss,rpp,rpq,rpr,rps,rqp,rqq,rqr,rqs,rrp,rrq,rrr,rrs,rsp,rsq,rsr,rss,spp,spq,spr,sps,sqp,sqq,sqr,sqs,srp,srq,srr,srs,ssp,ssq,ssr,sss"),
            };

        protected override void InitialTestCases()
        {
            Title = "Letter Combinations of a Phone Number";
            Requirement = "Given a digit string, return all possible letter combinations that the number could represent.";
            Id = 17;
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => AddTestCases(testCase.Item1, testCase.Item2));
        }

        string ExecuteTestCase(string testCase)
        {
            var result = LetterCombinationsSolution.LetterCombinations(testCase);
            return string.Join(",", result);
        }
    }
}
