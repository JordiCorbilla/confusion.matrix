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
using confusion.matrix.lib;
using NUnit.Framework;

namespace confusion.matrix.tests
{
    public class ConfusionMatrixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var expected = new List<decimal>{0.551581619m,
                0.527355524m,
                0.89960897m  ,
                0.662623599m ,
                0.572634637m ,
                0.936746871m ,
                0.705131996m ,
                0.091190956m ,
                0.32595875m  ,
                0.51333567m  ,
                0.465097235m ,
                0.778253576m ,
                0.774211038m ,
                0.139599905m ,
                0.612401047m ,
                0.255830962m ,
                0.939558049m ,
                0.886963547m ,
                0.145435855m ,
                0.236740103m ,
                0.718521949m ,
                0.621347395m ,
                0.937368448m
                };

            var real = new List<decimal>
            {
                0.074231959m,
                0.191437159m,
                0.603508885m,
                0.43302318m,
                0.91215736m,
                0.693543126m,
                0.581585544m,
                0.445597405m,
                0.980035103m,
                0.843989383m,
                0.751586808m,
                0.831826468m,
                0.381103421m,
                0.627685118m,
                0.409753088m,
                0.511906306m,
                0.874451353m,
                0.224535522m,
                0.10238894m,
                0.83196273m,
                0.55666507m,
                0.479726042m,
                0.132628696m
            };

            var confusion = new ConfusionMatrix(expected, real);
            confusion.ToConsole();
        }
    }
}