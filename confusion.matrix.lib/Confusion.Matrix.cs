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

namespace confusion.matrix.lib
{
    public class ConfusionMatrix
    {
        //get the data
        public List<DataHolder> Data { get; set; }

        public ConfusionMatrix(List<decimal> expected, List<decimal> value, int numberBuckets)
        {
            Data = new List<DataHolder>();
            for (int i = 0; i < expected.Count; i++)
            {
                Data.Add(new DataHolder{Expected = expected[i], Value = value[i]});
            }

            GenerateBuckets(numberBuckets);
        }

        //create the buckets
        private void GenerateBuckets(int numberBuckets)
        {

        }

        //generate output
        public void ToConsole()
        {

        }
    }
}
