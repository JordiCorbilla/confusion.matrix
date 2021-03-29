//MIT License

//Copyright (c) 2020-2021 Jordi Corbilla

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System.Collections.Generic;
using table.lib;

namespace confusion.matrix.lib
{
    public class ConfusionMatrix
    {
        public ConfusionMatrix(IReadOnlyList<decimal> expected, IReadOnlyList<decimal> value, int numberBuckets)
        {
            Data = new List<DataHolder>();
            Matrix = new Dictionary<string, DataBucket>();
            for (var i = 0; i < expected.Count; i++)
                Data.Add(new DataHolder {Expected = expected[i], Value = value[i]});

            GenerateBuckets(numberBuckets);
        }

        public List<DataHolder> Data { get; set; }
        public Dictionary<string, DataBucket> Matrix { get; set; }
        public int NumberBuckets { get; set; }

        //create the buckets
        private void GenerateBuckets(int numberBuckets)
        {
            NumberBuckets = numberBuckets;
            switch (numberBuckets)
            {
                case 2:
                {
                    Matrix.Add("TP", new DataBucket());
                    Matrix.Add("TN", new DataBucket());

                    foreach (var item in Data)
                        if (item.Difference == 0)
                            Matrix["TP"].Counter1++;
                        else
                            Matrix["TN"].Counter2++;

                    break;
                }
                case 7:
                    Matrix.Add("<-0.02", new DataBucket());
                    Matrix.Add("-0.02", new DataBucket());
                    Matrix.Add("-0.01", new DataBucket());
                    Matrix.Add("0", new DataBucket());
                    Matrix.Add("0.01", new DataBucket());
                    Matrix.Add("0.02", new DataBucket());
                    Matrix.Add(">0.02", new DataBucket());

                    foreach (var item in Data)
                        if (item.Difference < -0.02m)
                            Matrix["<-0.02"].Counter1++;
                        else if (item.Difference < -0.01m && item.Difference >= -0.02m)
                            Matrix["-0.02"].Counter2++;
                        else if (item.Difference < 0m && item.Difference >= -0.01m)
                            Matrix["-0.01"].Counter3++;
                        else if (item.Difference == 0)
                            Matrix["0"].Counter4++;
                        else if (item.Difference > 0m && item.Difference <= 0.01m)
                            Matrix["0.01"].Counter5++;
                        else if (item.Difference > 0.01m && item.Difference <= 0.02m)
                            Matrix["0.02"].Counter6++;
                        else if (item.Difference > 0.02m) Matrix[">0.02"].Counter7++;

                    break;
            }
        }

        //generate output
        public void ToConsole()
        {
            switch (NumberBuckets)
            {
                case 2:
                    TableDic<string, DataBucket>.Add(Matrix)
                        .FilterColumns(new[] {"Key_Id", "Counter1", "Counter2"}, FilterAction.Include)
                        .OverrideColumnsNames(new Dictionary<string, string>
                            {{"Key_Id", "_"}, {"Counter1", "TP"}, {"Counter2", "TN"}})
                        .ToConsole();
                    break;
                case 7:
                    TableDic<string, DataBucket>.Add(Matrix)
                        .OverrideColumnsNames(new Dictionary<string, string>
                        {
                            {"Key_Id", "_"},
                            {"Counter1", "<-0.02"},
                            {"Counter2", "-0.02"},
                            {"Counter3", "-0.01"},
                            {"Counter4", "0"},
                            {"Counter5", "0.01"},
                            {"Counter6", "0.02"},
                            {"Counter7", ">0.02"}
                        })
                        .ToConsole();
                    break;
            }
        }
    }
}