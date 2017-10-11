//Based on http://blog.stephencleary.com/2016/11/streaming-zip-on-aspnet-core.html
//github: https://github.com/StephenClearyExamples/AsyncDynamicZip/tree/core-ziparchive)
//Author: Stephen Cleary
//
//MIT License
//
//Copyright(c) 2016 StephenClearyExamples
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using Microsoft.AspNetCore.Mvc.Internal;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Adeptik.AspNetCore.Mvc.ActionResults;

namespace Adeptik.AspNetCore.Mvc.Internal
{
    /// <summary>
    /// Обработчик результата действия с типом file
    /// </summary>
    internal sealed class FileCallbackResultExecutor : FileResultExecutorBase
    {
        /// <summary>
        /// Создание экземпляра класса <see cref="FileCallbackResultExecutor"/>
        /// </summary>
        /// <param name="loggerFactory"></param>
        public FileCallbackResultExecutor(ILoggerFactory loggerFactory)
            : base(CreateLogger<FileCallbackResultExecutor>(loggerFactory))
        { }

        /// <summary>
        /// Выполнение обработчика
        /// </summary>
        /// <param name="context">Контекст действия</param>
        /// <param name="result">Результат действия</param>
        /// <returns><see cref="Task"/></returns>
        public Task ExecuteAsync(ActionContext context, FileCallbackResult result)
        {
            SetHeadersAndLog(context, result, null);
            return result.Callback(context.HttpContext.Response.Body, context);
        }
    }
}
