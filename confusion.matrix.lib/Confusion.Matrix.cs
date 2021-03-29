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

        //get the data
        public List<DataHolder> Data { get; set; }
        public Dictionary<string, DataBucket> Matrix { get; set; }

        //create the buckets
        private void GenerateBuckets(int numberBuckets)
        {
            if (numberBuckets == 2)
            {
                Matrix.Add("TP", new DataBucket{Counter1 = 0, Counter2 = 0});
                Matrix.Add("TN", new DataBucket { Counter1 = 0, Counter2 = 0 });

                foreach (var item in Data)
                {
                    if (item.Difference == 0)
                    {
                        Matrix["TP"].Counter1++;
                    }
                    else
                    {
                        Matrix["TN"].Counter2++;
                    }
                }
            }
        }

        //generate output
        public void ToConsole()
        {
            TableDic<string, DataBucket>.Add(Matrix)
                .FilterColumns(new []{"Key_Id", "Counter1", "Counter2"}, FilterAction.Include)
                .OverrideColumnsNames(new Dictionary<string, string>(){ { "Key_Id", "_" }, { "Counter1", "TP"}, {"Counter2", "TN"}})
                .ToConsole();
        }
    }
}