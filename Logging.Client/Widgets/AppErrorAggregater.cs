﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Web;
using System.Threading;

namespace Logging.Client.Widgets
{
    /// <summary>
    /// 聚合未捕获异常
    /// </summary>
    public class AppErrorAggregater
    {
        readonly static ILog logger = LogManager.GetLogger(typeof(AppErrorAggregater));

        private int ReportCount { get;  set; }

        private int ReportElapsed { get;  set; }

        private DateTime LastReportTime { get; set; }

        /// <summary>
        /// 聚合未捕获异常
        /// </summary>
        /// <param name="reportCount">一次上报的数量</param>
        /// <param name="reportElapsed">上报间隔时间。单位：秒</param>
        public AppErrorAggregater(int reportCount, int reportElapsed)
        {
            this.ReportCount = reportCount;
            this.ReportElapsed = reportElapsed;
            this.ErrorCollection = new ConcurrentDictionary<string, Tuple<int, Exception>>();
            this.ErrorCount = 0;
            this.LastReportTime = DateTime.Now;
        }

        private AppErrorAggregater() { }

        private int ErrorCount;

        private ConcurrentDictionary<string, Tuple<int, Exception>> ErrorCollection { get; set; }

        //  readonly  object lockthis = new object();

        public void Aggregate()
        {
            var url = HttpContext.Current.Request.Url;
            Exception ex = HttpContext.Current.Server.GetLastError();
            string key = url.Scheme + "://" + url.Authority + url.AbsolutePath;

            Tuple<int, Exception> item_ex;

            var has = this.ErrorCollection.TryGetValue(key, out item_ex);
            if (has)
            {
                this.ErrorCollection[key] = new Tuple<int, Exception>(item_ex.Item1 + 1, ex);
            }
            else 
            {
                this.ErrorCollection.TryAdd(key, new Tuple<int, Exception>(1, ex));
            }

            Interlocked.Increment(ref this.ErrorCount);
            if (this.ErrorCount >= this.ReportCount || (DateTime.Now - LastReportTime).Seconds >= this.ReportElapsed)
            {
                foreach (var item in this.ErrorCollection)
                {
                    Dictionary<string, string> tags = new Dictionary<string, string>();
                    tags.Add("url", item.Key); 
                    tags.Add("count", item.Value.Item1.ToString());
                    tags.Add("Logging.Client.Widgets", "AppErrorAggregater");
                    logger.Error(item.Value.Item2.Message + "(" + item.Value.Item1.ToString() + ")", item.Value.Item2, tags);
                }
                this.ErrorCollection.Clear();
                Interlocked.Add(ref this.ErrorCount, -this.ErrorCount);
                this.LastReportTime = DateTime.Now;
            }
        }
    }
}